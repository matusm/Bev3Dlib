namespace Bev.Bev3Dlib
{
    public abstract class Element
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Element(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Element() : this(0, 0, 0) { }

        public override string ToString()
        {
            return string.Format($"{nameof(Element)}: X={X} Y={Y} Z={Z}");
        }

    }
}
