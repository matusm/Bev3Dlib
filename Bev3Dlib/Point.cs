using System;
using MathematicalServices.Geometry;

namespace Bev.Bev3Dlib
{
    public class Point : Element
    {
        public Point() : base() { }
        public Point(double x, double y, double z) : base(x, y, z) { }

        public double Distance(Point p)
        {
            double dx = X - p.X;
            double dy = Y - p.Y;
            double dz = Z - p.Y;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static double Distance(Point a, Point b) => a.Distance(b);

        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static implicit operator Point3D(Point p) => new Point3D(p.X, p.Y, p.Z);

        public static implicit operator Point(Point3D p) => new Point(p[0], p[1], p[2]);
    }
}
