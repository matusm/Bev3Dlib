using System.Collections.Generic;
using MathematicalServices.Geometry;

namespace Bev.Bev3Dlib
{
    public class FitSphere
    {
        private readonly Sphere3D sphere = new Sphere3D();
        private readonly List<double> residuals;

        public int NumberPoints { get; private set; }
        public bool FitSuccess { get; private set; }
        public Point SphereCenter { get; private set; }
        public double SphereDiameter => 2.0 * sphere.Radius;
        public double RMSError => sphere.RMSError; 
        public double MaxError => sphere.MaxError;
        public double[] Residuals => residuals.ToArray();

        public FitSphere(Point[] dataPoints, bool[] mask)
        {
            // translate the Point classes
            if (mask == null || mask.Length<dataPoints.Length)
            {
                mask = new bool[dataPoints.Length];
                for (int i = 0; i < mask.Length; i++)
                    mask[i] = true;
            }
            List<Point3D> dataList = new List<Point3D>();
            for(int i = 0; i < dataPoints.Length; i++) 
                if(mask[i])
                    dataList.Add(dataPoints[i]);

            NumberPoints = dataList.Count;

            Point3DArray observation = new Point3DArray(dataList.ToArray(), dataList.Count);

            // fit the sphere
            FitSuccess = DoTheFit(observation);

            // generate residuals
            if(FitSuccess)
            {    
                residuals = new List<double>();
                foreach (var p in dataPoints)
                    residuals.Add(Residual(sphere, p));
            }
        }

        public FitSphere(Point[] dataPoints) : this(dataPoints, null) {}

        private bool DoTheFit(Point3DArray points)
        {
            if(sphere.Fit(points) == 1) 
            {
                SphereCenter = (Point)sphere.Center;
                return true;
            }
            return false;
        }

        private double Residual(Sphere3D s, Point3D p) => p.DistanceTo(s.Center) - s.Radius;

    }
}
