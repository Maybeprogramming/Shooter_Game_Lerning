using System.Text;
using static System.Console;

namespace Task_Test
{
    internal class Program
    {
        #region Shooter Game
        static ConsoleColor playerColor = ConsoleColor.Green;
        static ConsoleColor playerDirectionColor = ConsoleColor.Blue;
        static ConsoleColor bulletColor = ConsoleColor.Red;
        static Pixel player = new Pixel(10, 10, playerColor);
        static Pixel playerDirectionViev = new Pixel(player.X, player.Y, playerDirectionColor);
        static Pixel bullet = new Pixel(playerDirectionViev.X, playerDirectionViev.Y, bulletColor, '*');
        static Direction shootDirection = Direction.Right;
        #endregion


        static void Main()
        {
            //PrintObject3D();
            StartGameShooter();
        }

        private static void PrintObject3D()
        {
            StringBuilder screenBuild = new StringBuilder();
            CursorVisible = false;
            int width = 120;
            int heigh = 30;
            SetWindowSize(width, heigh);
            SetBufferSize(120, 30);
            float aspect = (float)width / heigh;
            float pixelAspect = 7f / 14.0f;
            char[] gradient = { ' ', '.', ':', '!', '/', 'r', '(', 'l', '1', 'Z', '4', 'H', '9', '@', '8', '$', '@' };
            int gradientSize = gradient.Length - 2;
            char[] screen = new char[width * heigh + 1];
            screen[width * heigh] = '\0';

            ReadKey();

            for (int t = 0; t < 10000; t++)
            {
                screenBuild.Clear();
                Vector3D light = FVec.Norm(new Vector3D((float)Math.Sin(t * 0.001f), (float)Math.Cos(t * 0.001), -1.0f));

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < heigh; j++)
                    {
                        Vector2D uv = new Vector2D(i, j) / new Vector2D(width, heigh) * 2.0f - 1.0f;
                        Vector3D ro = new Vector3D(-2, 0, 0);
                        Vector3D rd = FVec.Norm(new Vector3D(1, uv));
                        uv = new Vector2D(uv.X * aspect * pixelAspect, uv.Y);
                        uv = new Vector2D((float)(uv.X + Math.Sin(t * 0.001f)));
                        char pixel = ' ';
                        int color = 0;
                        Vector2D intersection = FVec.Sphere(ro, rd, 1);

                        if (intersection.X > 0)
                        {
                            Vector3D itPoint = ro + rd * intersection.X;
                            Vector3D n = FVec.Norm(itPoint);
                            float diff = FVec.Dot(n, light);
                            color = (int)(diff * 20);
                        }

                        color = (Int32)FVec.Clamp(color, 0, gradientSize);
                        pixel = gradient[color];
                        screen[i + j * width] = pixel;
                    }
                }

                //Thread.Sleep(10);
                screenBuild.Append(screen);
                Write(screenBuild);
            }
        }

        private static void StartGameShooter()
        {
            int height = 30;
            int width = 50;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;

            while (true)
            {
                player.Draw();

                ConsoleKey key = ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        player.Clear();
                        playerDirectionViev.Clear();
                        player = new Pixel(player.X + 1, player.Y, playerColor);
                        playerDirectionViev = new Pixel(player.X + 1, player.Y, playerColor, '-');
                        shootDirection = Direction.Right;
                        break;

                    case ConsoleKey.LeftArrow:
                        player.Clear();
                        playerDirectionViev.Clear();
                        player = new Pixel(player.X - 1, player.Y, playerColor);
                        playerDirectionViev = new Pixel(player.X - 1, player.Y, playerColor, '-');
                        shootDirection = Direction.Left;
                        break;

                    case ConsoleKey.UpArrow:
                        player.Clear();
                        playerDirectionViev.Clear();
                        player = new Pixel(player.X, player.Y - 1, playerColor);
                        playerDirectionViev = new Pixel(player.X, player.Y - 1, playerColor, '|');
                        shootDirection = Direction.Up;
                        break;

                    case ConsoleKey.DownArrow:
                        player.Clear();
                        playerDirectionViev.Clear();
                        player = new Pixel(player.X, player.Y + 1, playerColor);
                        playerDirectionViev = new Pixel(player.X, player.Y + 1, playerColor, '|');
                        shootDirection = Direction.Down;
                        break;

                    case ConsoleKey.Spacebar:
                        if (player.X >= 3 && player.X <= width - 3 && player.Y >= 3 && player.Y <= height - 3)
                            Task.Run(() => Shoot(shootDirection, 50, player, bullet));
                        break;
                }

                SetCursorPosition(0, 0);
                Write($"X: {player.X}|Y: {player.Y}   ");
                player.Draw();
                playerDirectionViev.Draw();
            }
        }


        static public void Shoot(Direction directionShoot, int delayMs, Pixel player, Pixel bullet)
        {
            Console.Beep(200, 200);

            switch (directionShoot)
            {
                case Direction.Up:
                    bullet = new Pixel(player.X, player.Y - 2, bulletColor);

                    for (int i = 0; i < 30; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X, bullet.Y - 1, bulletColor, '*');

                        if (bullet.Y <= 3)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;
                case Direction.Down:
                    bullet = new Pixel(player.X, player.Y + 2, bulletColor);


                    for (int i = 0; i < 30; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X, bullet.Y + 1, bulletColor, '*');

                        if (bullet.Y >= 30 - 3)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;
                case Direction.Right:
                    bullet = new Pixel(player.X + 2, player.Y, bulletColor);

                    for (int i = 0; i < 30; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X + 1, bullet.Y, bulletColor, '*');

                        if (bullet.X >= 50 - 3)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;
                case Direction.Left:
                    bullet = new Pixel(player.X - 2, player.Y, bulletColor);

                    for (int i = 0; i < 30; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X - 1, bullet.Y, bulletColor, '*');

                        if (bullet.X <= 3)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;

            }

            bullet.Clear();
        }

    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}
struct Pixel
{
    private char PixelChar { get; }
    private const char PixelEmpty = ' ';

    public Pixel(int x, int y, ConsoleColor color, char drowSymbol = '@') : this()
    {
        X = x;
        Y = y;
        Color = color;
        PixelChar = drowSymbol;
    }

    public int X { get; }
    public int Y { get; }
    public ConsoleColor Color { get; }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y);
        Console.Write(PixelChar);
    }
    public void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(PixelEmpty);
    }
}

//static void Main()
//{
//    CursorVisible = false;

//    int width = 120;
//    int height = 30;
//    SetWindowSize(width, height);
//    SetBufferSize(120, 30);
//    float aspect = (float)width / height;
//    //соотношение сторон символа:
//    float pixelAspect = 7.0f / 14.0f;
//    char[] gradient = { ' ', '.', ':', '!', '/', 'r', '(', 'l', '1', 'Z', '4', 'H', '9', '@', '8', '$', '@' };
//    int gradientSize = gradient.Length - 2;

//    char[] screen = new char[width * height];

//    for (int t = 0; t < 10000; t++)
//    {
//        Vector3D light = FVec.Norm(new Vector3D(-0.5f, 0.5f, -1.0f));
//        Vector3D spherePos = new Vector3D(0f, 3f, 0f);
//        for (int i = 0; i < width; i++)
//        {
//            for (int j = 0; j < height; j++)
//            {
//                Vector2D uv = new Vector2D(i, j) / new Vector2D(width, height) * 2.0f - 1.0f;
//                uv = new Vector2D(uv.X * aspect * pixelAspect, uv.Y);
//                Vector3D ro = new Vector3D(-6f, 0f, 0f);
//                Vector3D rd = FVec.Norm(new Vector3D(2f, uv));
//                ro = FVec.RotateY(ro, 0.25f);
//                rd = FVec.RotateY(rd, 0.25f);
//                ro = FVec.RotateZ(ro, t * 0.01f);
//                rd = FVec.RotateZ(rd, t * 0.01f);
//                float diff = 1;
//                for (int k = 0; k < 5; k++)
//                {
//                    float minIt = 99999;
//                    Vector2D intersection = FVec.Sphere(ro - spherePos, rd, 1);
//                    Vector3D n = new Vector3D(0f);
//                    float albedo = 1;
//                    if (intersection.X > 0)
//                    {
//                        Vector3D itPoint = ro - spherePos + rd * intersection.X;
//                        minIt = intersection.X;
//                        n = FVec.Norm(itPoint);
//                    }
//                    Vector3D boxN = new Vector3D(0f);
//                    intersection = FVec.Box(ro, rd, new Vector3D(1f), ref boxN);
//                    if (intersection.X > 0 && intersection.X < minIt)
//                    {
//                        minIt = intersection.X;
//                        n = boxN;
//                    }
//                    intersection = new Vector2D(FVec.Plane(ro, rd, new Vector3D(0f, 0f, -1f), 1f));
//                    if (intersection.X > 0 && intersection.X < minIt)
//                    {
//                        minIt = intersection.X;
//                        n = new Vector3D(0f, 0f, -1f);
//                        albedo = 0.5f;
//                    }
//                    if (minIt < 99999)
//                    {
//                        diff *= (FVec.Dot(n, light) * 0.5f + 0.5f) * albedo;
//                        ro = ro + rd * (minIt - 0.01f);
//                        rd = FVec.Reflect(rd, n);
//                    }
//                    else break;
//                }
//                int color = (int)(diff * 20);
//                color = (Int32)FVec.Clamp(color, 0f, gradientSize);
//                char pixel = gradient[color];
//                screen[i + j * width] = pixel;
//            }
//        }
//        screen[width * height - 1] = '\0';
//        Write(screen);
//        ReadKey();
//    }
//}