using System;

namespace Bev.Bev3Dlib
{
    public class Vector : Element
    {
        public Vector() : base() { }
        public Vector(double x, double y, double z) : base(x, y, z) { }
        public Vector(Point p, Point q) : base(q.X - p.X, q.Y - p.Y, q.Z - p.Z) { }

        public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public static double Length(Vector v) => v.Length();

        public Vector Normalize() => (1.0 / Length()) * this;

        public static Vector Normalize(Vector v) => v.Normalize();

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Vector operator *(double c, Vector v) => new Vector(c * v.X, c * v.Y, c * v.Z);

    }
}
