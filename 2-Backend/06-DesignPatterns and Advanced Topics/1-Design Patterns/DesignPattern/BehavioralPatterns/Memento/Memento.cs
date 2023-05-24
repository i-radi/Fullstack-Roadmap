using System;

namespace DesignPattern.BehavioralPatterns.Memento
{
    interface Memento
    {
        string getName();

        string getState();

        DateTime getDate();
    }
}