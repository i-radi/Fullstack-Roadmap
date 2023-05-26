namespace DesignPattern.BehavioralPatterns.State
{
    class Client
    {
        public static void ClientCode()
        {
            var context = new Context(new ConcreteStateA());
            context.request1();
            context.request2();
        }
    }
}