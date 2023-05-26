using System;

namespace DesignPattern.BehavioralPatterns.Strategy
{
    class Client
    {
        public static void ClientCode()
        {
            var context = new Context();

            Console.Write("Client: Strategy is set to normal sorting.\n");
            context.setStrategy(new ConcreteStrategyA());
            context.doSomeBusinessLogic();
            Console.Write("\n");
            Console.Write("Client: Strategy is set to reverse sorting.\n");
            context.setStrategy(new ConcreteStrategyB());
            context.doSomeBusinessLogic();

            Console.Write("\n");
        }
    }

    //         Client.ClientCode();

}
