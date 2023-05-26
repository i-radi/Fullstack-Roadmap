namespace DesignPattern.BehavioralPatterns.Visitor
{
    public class ConcreteComponentA : Component
    {
        public void accept(Visitor visitor)
        {
            visitor.visitConcreteComponentA(this);
        }

        public string exclusiveMethodOfConcreteComponentA()
        {
            return "A";
        }
    }
}