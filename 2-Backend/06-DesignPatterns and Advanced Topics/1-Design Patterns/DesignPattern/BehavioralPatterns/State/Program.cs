using System;

namespace DesignPattern.BehavioralPatterns.State
{
    class ConcreteStateB : State
    {
        public override void handle1()
        {
            Console.Write("ConcreteStateB handles request1.\n");
        }

        public override void handle2()
        {
            Console.Write("ConcreteStateB handles request2.\n");
            Console.Write("ConcreteStateB wants to change the state of the context.\n");
            this.context.transitionTo(new ConcreteStateA());
        }
    }


    //         Client.ClientCode();
}
