using System;

namespace DesignPattern.BehavioralPatterns.Memento
{
    class ConcreteMemento : Memento
    {
        private string _state;

        private DateTime _date;

        public ConcreteMemento(string state)
        {
            this._state = state;
            this._date = DateTime.Now;
        }

        public string getState()
        {
            return this._state;
        }

        public string getName()
        {
            return this._date + " / (" + _state.Substring(0, 9) + "...)";
        }

        public DateTime getDate()
        {
            return this._date;
        }
    }
}