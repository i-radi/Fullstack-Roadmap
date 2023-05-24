namespace DesignPattern.BehavioralPatterns.Visitor
{
    interface Component
    {
        void accept(Visitor visitor);
    }
}