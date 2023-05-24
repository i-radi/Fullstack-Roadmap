namespace DesignPattern.CreationalPatterns.Factory_Pattern
{
    public abstract class Shape 
    {
        protected readonly double[] Lengths;

        protected Shape(int numOfSides)
        {
            if (numOfSides > 0)
                Lengths = new double[numOfSides];
        }
        
        public abstract double Area();
    }
}