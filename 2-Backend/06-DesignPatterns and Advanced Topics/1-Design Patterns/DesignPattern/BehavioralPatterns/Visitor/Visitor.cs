namespace DesignPattern.BehavioralPatterns.Visitor
{
    public interface Visitor
    {
        void visitConcreteComponentA(ConcreteComponentA el);

        void visitConcreteComponentB(ConcreteComponentB el);
    }
}