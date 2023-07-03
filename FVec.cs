namespace Task_Test
{
    internal static class FVec
    {
        public static float Clamp(float value, float min, float max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        public static float Sign(double a)
        {
            return Convert.ToInt32((0 < a)) - Convert.ToInt32((a < 0));
        }

        public static float Step(double edge, double x)
        {
            return Convert.ToInt32(x > edge);
        }

        public static float Length(Vector2D vector)
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

        public static float Dot(Vector3D vector1, Vector3D vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static Vector3D Abs(Vector3D vector)
        {
            return new Vector3D(Math.Abs(vector.X), Math.Abs(vector.Y), Math.Abs(vector.Z));
        }

        public static Vector3D Sign(Vector3D vector)
        {
            return new Vector3D(Sign(vector.X), Sign(vector.Y), Sign(vector.Z));
        }

        public static Vector3D Step(Vector3D edge, Vector3D vector)
        {
            return new Vector3D(Step(edge.X, vector.X), Step(edge.Y, vector.Y), Step(edge.Z, vector.Z));
        }

        public static Vector3D Reflect(Vector3D vectorRD, Vector3D vectorN)
        {
            return vectorRD - vectorN * (2 * Dot(vectorN, vectorRD));
        }

        public static Vector3D RotateX(Vector3D vector, float angle)
        {
            float pointZ = (float)(vector.Z * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float pointY = (float)(vector.Z * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            return vector = new Vector3D(vector.X, pointY, pointZ);
        }

        public static Vector3D RotateY(Vector3D vector, float angle)
        {
            float pointX = (float)(vector.X * Math.Cos(angle) - vector.Z * Math.Sin(angle));
            float pointY = (float)(vector.X * Math.Sin(angle) + vector.Z * Math.Cos(angle));
            return vector = new Vector3D(pointX, pointY, vector.Z);
        }

        public static Vector3D RotateZ(Vector3D vector, float angle)
        {
            float pointZ = (float)(vector.X * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            float pointY = (float)(vector.X * Math.Sin(angle) + vector.Y * Math.Cos(angle));
            return vector = new Vector3D(vector.X, pointY, pointZ);
        }

        public static float Plane(Vector3D ro, Vector3D rd, Vector3D p, float w)
        {
            return -(Dot(ro, p) + w) / Dot(rd, p);
        }

        public static Vector2D Sphere(Vector3D ro, Vector3D rd, float r)
        {
            float b = Dot(ro, rd);
            float c = Dot(ro, ro) - r * r;
            float h = b * b - c;

            if (h < 0.0f)
            {
                return new Vector2D(-1.0f);
            }

            h = (float)Math.Sqrt(h);
            return new Vector2D(-b - h, -b + h);
        }

        public static Vector2D Box(Vector3D ro, Vector3D rd, Vector3D boxSize, ref Vector3D OutNormal)
        {
            Vector3D m = new Vector3D(1.0f) / rd;
            Vector3D n = m * ro;
            Vector3D k = Abs(m) * boxSize;
            Vector3D t1 = -n - k;
            Vector3D t2 = -n + k;
            float tN = Math.Max(Math.Max(t1.X, t1.Y), t1.Z);
            float tF = Math.Min(Math.Min(t2.X, t2.Y), t2.Z);

            if (tN > tF || tF < 0.0f)
            {
                return new Vector2D(-1.0f);
            }

            Vector3D yzx = new Vector3D(t1.Y, t1.Z, t1.X);
            Vector3D zxy = new Vector3D(t1.Z, t1.X, t1.Y);
            OutNormal = -Sign(rd) * Step(yzx, t1) * Step(zxy, t1);
            return new Vector2D(tN, tF);
        }


    }
}
