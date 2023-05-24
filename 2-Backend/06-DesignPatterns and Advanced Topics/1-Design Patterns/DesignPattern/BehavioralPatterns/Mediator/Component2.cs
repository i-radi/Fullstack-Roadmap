using System;

namespace DesignPattern.BehavioralPatterns.Mediator
{
    class Component2 : BaseComponent
    {
        public void doC()
        {
            Console.Write("Component 2 does C.\n");

            this.mediator.notify(this, "C");
        }

        public void doD()
        {
            Console.Write("Component 2 does D.\n");

            this.mediator.notify(this, "D");
        }
    }
}