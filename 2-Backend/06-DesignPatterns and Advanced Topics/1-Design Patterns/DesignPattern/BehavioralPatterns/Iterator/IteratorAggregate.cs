using System.Collections;

namespace DesignPattern.BehavioralPatterns.Iterator
{
    abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}