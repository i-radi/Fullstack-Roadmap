using System;
using System.Threading;

namespace DesignPattern.BehavioralPatterns.Memento
{
    class Originator
    {
        string _state;

        public Originator(string state)
        {
            this._state = state;
            Console.Write("Originator: My initial state is: " + _state + "\n");
        }

        public void doSomething()
        {
            Console.Write("Originator: I'm doing something important.\n");
            this._state = this.generateRandomString(30);
            Console.Write($"Originator: and my state has changed to: {_state}\n");
        }

        private string generateRandomString(int length = 10)
        {
            string allowedSymbs = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string result = string.Empty;

            while(length > 0)
            {
                result += allowedSymbs[new Random().Next(0, allowedSymbs.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        public Memento save()
        {
            return new ConcreteMemento(this._state);
        }

        public void restore(Memento memento)
        {
            if(!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._state = memento.getState();
            Console.Write($"Originator: My state has changed to: {_state}");
        }
    }


    //         Client.ClientCode();
}
