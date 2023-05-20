namespace DesignPattern.CreationalPatterns.Factory_Pattern
{
    public class Rectangle:Shape
    {
        public double Width => Lengths[0];
        public double Height => Lengths[1];

        public Rectangle(double w, double h) : base(4)
        {
            Lengths[0] = Lengths[2] = w;
            Lengths[1] = Lengths[3] = h;
        }

        public override double Area()
        {
            return Width * Height;
        }
    }
}