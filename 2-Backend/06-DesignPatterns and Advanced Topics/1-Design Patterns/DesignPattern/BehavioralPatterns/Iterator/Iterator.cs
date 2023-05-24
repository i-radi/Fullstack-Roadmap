using System.Collections;

namespace DesignPattern.BehavioralPatterns.Iterator
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract int Key();
		
        public abstract object Current();
		
        public abstract bool MoveNext();
		
        public abstract void Reset();
    }
}