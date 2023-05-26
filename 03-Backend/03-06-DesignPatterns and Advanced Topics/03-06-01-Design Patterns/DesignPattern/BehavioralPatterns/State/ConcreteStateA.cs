using System;

namespace DesignPattern.BehavioralPatterns.State
{
    class ConcreteStateA : State
    {
        public override void handle1()
        {
            Console.Write("ConcreteStateA handles request1.\n");
            Console.Write("ConcreteStateA wants to change the state of the context.\n");
            this.context.transitionTo(new ConcreteStateB());
        }

        public override void handle2()
        {
            Console.Write("ConcreteStateA handles request2.\n");
        }
    }
}