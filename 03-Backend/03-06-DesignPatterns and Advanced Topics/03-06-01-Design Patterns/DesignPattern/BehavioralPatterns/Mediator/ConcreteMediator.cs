using System;

namespace DesignPattern.BehavioralPatterns.Mediator
{
    class ConcreteMediator : Mediator
    {
        private Component1 component1;

        private Component2 component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            this.component1 = component1;
            this.component1.setMediator(this);
            this.component2 = component2;
            this.component2.setMediator(this);
        } 

        public void notify(object sender, object ev)
        {
            if(ev == "A")
            {
                Console.Write("Mediator reacts on A and triggers folowing operations:\n");
                this.component2.doC();
            }
            if(ev == "D")
            {
                Console.Write("Mediator reacts on D and triggers following operations:\n");
                this.component1.doB();
                this.component2.doC();
            }
        }
    }
}