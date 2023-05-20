using System;

namespace DesignPattern.BehavioralPatterns.Observer
{
    class ConcreteObserverB : SplObserver
    {
        public void update(SplSubject subject)
        {
            if (!(subject is Subject))
            {
                return;
            }

            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.Write("ConcreteObserverB: Reacted to the event.\n");
            }
        }
    }
}