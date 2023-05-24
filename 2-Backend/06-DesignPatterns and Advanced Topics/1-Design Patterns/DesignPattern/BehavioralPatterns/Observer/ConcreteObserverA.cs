using System;

namespace DesignPattern.BehavioralPatterns.Observer
{
    class ConcreteObserverA : SplObserver
    {
        public void update(SplSubject subject)
        {
            if(!(subject is Subject))
            {
                return;
            }
            
            if((subject as Subject).State < 3)
            {
                Console.Write("ConcreteObserverA: Reacted to the event.\n");
            }
        }
    }
}