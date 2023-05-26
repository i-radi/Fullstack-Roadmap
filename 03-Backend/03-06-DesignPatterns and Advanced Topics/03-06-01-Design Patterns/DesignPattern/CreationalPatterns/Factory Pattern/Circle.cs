using System;

namespace DesignPattern.CreationalPatterns.Factory_Pattern
{
    public class Circle:Shape
    {
        private double Raduis { get; set; }
        public Circle(double r) : base(0)
        {
            Raduis = r;
        }

        public override double Area()
        {
            return Math.PI * Raduis * Raduis;
        }

    }
}