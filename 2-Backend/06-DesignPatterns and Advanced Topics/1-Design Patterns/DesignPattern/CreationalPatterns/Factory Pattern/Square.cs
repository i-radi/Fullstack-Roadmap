namespace DesignPattern.CreationalPatterns.Factory_Pattern
{
    public class Square:Rectangle
    {
        public double Length => Lengths[0];
        public Square(double l) : base(l, l) { }
    }
}