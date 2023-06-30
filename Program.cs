using static System.Console;

namespace Task_Test
{
    internal class Program
    {
        static ConsoleColor playerColor = ConsoleColor.Green;
        static ConsoleColor playerDirectionColor = ConsoleColor.Blue;
        static ConsoleColor bulletColor = ConsoleColor.Red;

        static Pixel player = new Pixel(10, 10, playerColor);
        static Pixel playerDirectionViev = new Pixel(player.X, player.Y, playerDirectionColor);
        static Pixel bullet = new Pixel(playerDirectionViev.X, playerDirectionViev.Y, bulletColor, '*');

        static Direction shootDirection = Direction.Right;

        static void Main()
        {
            CursorVisible = false;
            SetWindowSize(40, 40);
            SetBufferSize(40, 40);

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
                        Task.Run(() => Shoot(shootDirection, 100, player, bullet));
                        break;
                }

                player.Draw();
                playerDirectionViev.Draw();
            }

            ReadKey();
        }

        static public void Shoot(Direction directionShoot, int delayMs, Pixel player, Pixel bullet)
        {
            Console.Beep(200, 200);

            switch (directionShoot)
            {
                case Direction.Up:
                    bullet = new Pixel(player.X, player.Y - 2, bulletColor);

                    for (int i = 0; i < 10; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X, bullet.Y - 1, bulletColor, '*');

                        if (bullet.Y <= 0)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;
                case Direction.Down:
                    bullet = new Pixel(player.X, player.Y + 2, bulletColor);


                    for (int i = 0; i < 10; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X, bullet.Y + 1, bulletColor, '*');

                        if (bullet.Y >= 39)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;
                case Direction.Right:
                    bullet = new Pixel(player.X + 2, player.Y, bulletColor);

                    for (int i = 0; i < 10; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X + 1, bullet.Y, bulletColor, '*');

                        if (bullet.X >= 39)
                        {
                            break;
                        }

                        bullet.Draw();
                        Thread.Sleep(delayMs);
                    }
                    break;
                case Direction.Left:
                    bullet = new Pixel(player.X - 2, player.Y, bulletColor);

                    for (int i = 0; i < 10; i++)
                    {
                        bullet.Clear();
                        bullet = new Pixel(bullet.X - 1, bullet.Y, bulletColor, '*');

                        if (bullet.X <= 0)
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