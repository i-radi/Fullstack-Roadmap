using System;

namespace DesignPattern.BehavioralPatterns.Mediator
{
    class Client
    {
        public static void ClientCode()
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            Mediator mediator = new ConcreteMediator(component1, component2);

            Console.Write("Client triggets operation A.\n");
            component1.doA();

            Console.WriteLine();

            Console.Write("Client triggers operation D.\n");
            component2.doD();
        }
    }
}