using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.BehavioralPatterns.Memento
{
    class Caretaker
    {
        private List<Memento> _mementos = new List<Memento>();

        private Originator originator = null;

        public Caretaker(Originator originator)
        {
            this.originator = originator;
        }

        public void backup()
        {
            Console.Write("\nCaretaker: Saving Originator's state...\n");
            this._mementos.Add(this.originator.save());
        }

        public void undo()
        {
            if (_mementos.Count == 0)
            {
                return;
            }

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            Console.Write("Caretaker: Restoring state to: " + memento.getName() + "\n");

            try
            {
                this.originator.restore(memento);
            }
            catch(Exception ex)
            {
                this.undo();
            }
        }

        public void showHistory()
        {
            Console.Write("Caretaker: Here's the list of mementos:\n");

            foreach (var memento in _mementos)
            {
                Console.Write(memento.getName() + "\n");
            }
        }
    }
}