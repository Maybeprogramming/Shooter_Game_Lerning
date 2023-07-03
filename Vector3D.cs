namespace Task_Test
{
    internal struct Vector3D
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3D(float value, Vector2D vector)
        {
            X = value;
            Y = vector.X;
            Z = vector.Y;
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }

        public static Vector3D operator *(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X * vector2.X, vector1.Y * vector2.Y, vector1.Z * vector2.Z);
        }

        public static Vector3D operator *(Vector3D vector1, float value)
        {
            return new Vector3D(vector1.X * value, vector1.Y * value, vector1.Z * value);
        }

        public static Vector3D operator /(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X / vector2.X, vector1.Y / vector2.Y, vector1.Z * vector2.Z);
        }
        public static Vector3D operator /(Vector3D vector1, float length)
        {
            return new Vector3D(vector1.X / length, vector1.Y / length, vector1.Z * length);
        }

        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(-vector.X, -vector.Y, -vector.Z);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }
    }
}
