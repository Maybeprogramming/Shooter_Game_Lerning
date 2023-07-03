namespace Task_Test
{
    internal static class FVec
    {
        public static float Clamp(float value, float min, float max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        public static float Sign (double a)
        {
            return Convert.ToInt32((0 < a)) - Convert.ToInt32((a < 0));
        }

        public static float Step (double edge, double x)
        {
            return Convert.ToInt32(x > edge);
        }

        public static float Length (Vector2D vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static float Length(Vector3D vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
        }

        public static Vector3D Norm(Vector3D vector)
        {
            return vector / Length(vector);
        }

        public static float Dot (Vector3D vector1, Vector3D vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static Vector3D Abs (Vector3D vector)
        {
            return new Vector3D(Math.Abs(vector.X), Math.Abs(vector.Y), Math.Abs(vector.Z));
        }

        public static Vector3D Sign (Vector3D vector)
        {
            return new Vector3D(Sign(vector.X), Sign(vector.Y), Sign(vector.Z));
        }

        public static Vector3D Step (Vector3D edge, Vector3D vector)
        {
            return new Vector3D(Step(edge.X, vector.X), Step(edge.Y, vector.Y), Step(edge.Z, vector.Z));
        }

        public static Vector3D Reflect (Vector3D vectorRD, Vector3D vectorN)
        {
            return vectorRD - vectorN * (2 * Dot(vectorN, vectorRD));
        }

        public static Vector3D RotateX(Vector3D vector, float angle)
        {
            float pointZ = (float)(vector.Z * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float pointY = (float)(vector.Z * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            Vector3D vector2 = new Vector3D(vector.X, pointZ, pointY);
            return vector2;
        }

        public static Vector3D RotateY(Vector3D vector, float angle)
        {
            float pointZ = (float)(vector.Z * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float pointY = (float)(vector.Z * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            Vector3D vector2 = new Vector3D(vector.X, pointZ, pointY);
            return vector2;
        }

        public static Vector3D RotateZ(Vector3D vector, float angle)
        {
            float pointZ = (float)(vector.Z * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float pointY = (float)(vector.Z * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            Vector3D vector2 = new Vector3D(vector.X, pointZ, pointY);
            return vector2;
        }


    }
}
