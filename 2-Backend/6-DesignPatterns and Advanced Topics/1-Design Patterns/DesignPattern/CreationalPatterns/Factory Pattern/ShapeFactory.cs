using DesignPattern.CreationalPatterns.AbstractFactory_Pattern;

namespace DesignPattern.CreationalPatterns.Factory_Pattern
{
    public class ShapeFactory:AbstractFactory
    {
        public Shape GetShape(string type)
        {
            return type switch
            {
                "R" => new Rectangle(4, 5),
                "S" => new Square(5),
                "C" => new Circle(3),
                _ => null
            };
        }
    }
}