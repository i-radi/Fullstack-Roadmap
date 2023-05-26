using System;

namespace DesignPattern.BehavioralPatterns.State
{
    class Context
    {
        private State _state = null;

        public Context(State state)
        {
            this.transitionTo(state);
        }

        public void transitionTo(State state)
        {
            Console.Write("Context: Transition to " + state.ToString() + ".\n");
            this._state = state;
            this._state.setContext(this);
        }

        public void request1()
        {
            this._state.handle1();
        }

        public void request2()
        {
            this._state.handle2();
        }
    }
}