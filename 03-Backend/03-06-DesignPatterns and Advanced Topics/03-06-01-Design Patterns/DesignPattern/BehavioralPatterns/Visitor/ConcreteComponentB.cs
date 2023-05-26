namespace DesignPattern.BehavioralPatterns.Visitor
{
    public class ConcreteComponentB : Component
    {
        public void accept(Visitor visitor)
        {
            visitor.visitConcreteComponentB(this);
        }

        public string specialMethodOfConcreteComponentB()
        {
            return "B";
        }
    }
}