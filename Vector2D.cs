namespace Task_Test
{
    internal struct Vector2D
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2D(float value)
        {
            X = value;
            Y = value;
        }

        public static Vector2D operator +(Vector2D vectorA, Vector2D vectorB)
        {
            return new Vector2D(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y);
        }

        public static Vector2D operator -(Vector2D vectorA, Vector2D vectorB)
        {
            return new Vector2D(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y);
        }

        public static Vector2D operator *(Vector2D vectorA, Vector2D vectorB)
        {
            return new Vector2D(vectorA.X * vectorB.X, vectorA.Y * vectorB.Y);
        }

        public static Vector2D operator /(Vector2D vectorA, Vector2D vectorB)
        {
            return new Vector2D(vectorA.X / vectorB.X, vectorA.Y / vectorB.Y);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
