using System;
using System.Collections.Generic;
using System.Threading;

namespace DesignPattern.BehavioralPatterns.Observer
{
    public class Subject : SplSubject
    {
        public int State { get; set; } = -0;

        private List<SplObserver> _observers = new List<SplObserver>();

        public void attach(SplObserver observer)
        {
            Console.Write("Subject: Attached an observer.\n");
            this._observers.Add(observer);
        }

        public void detach(SplObserver observer)
        {
            foreach(var elem in _observers)
            {
                if(elem == observer)
                {
                    _observers.Remove(observer);
                    Console.Write("Subject: Detached an observer.\n");
                    break;
                }
            }
        }

        public void notify()
        {
            Console.Write("Subject: Notifying observers...\n");

            foreach(var observer in _observers)
            {
                observer.update(this);
            }
        }

        public void someBusinessLogic()
        {
            Console.Write("\nSubject: I'm doing something important.\n");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.Write("Subject: My state has just changed to: " + this.State + "\n");
            this.notify();
        }
    }

    //         Client.ClientCode();

}
