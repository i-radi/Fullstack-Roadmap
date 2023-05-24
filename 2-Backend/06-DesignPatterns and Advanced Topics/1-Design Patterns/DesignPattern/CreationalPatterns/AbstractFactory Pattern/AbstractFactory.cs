using DesignPattern.CreationalPatterns.Factory_Pattern;

namespace DesignPattern.CreationalPatterns.AbstractFactory_Pattern
{
    public interface AbstractFactory
    {
        public Shape GetShape(string type);
    }
}