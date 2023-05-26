using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.BehavioralPatterns.Iterator
{
   
    //         Client client = new Client();
    //         client.ClientCode();


    class WordsCollection : IteratorAggregate
    {
        List<string> _collection = new List<string>();
		
        bool _direction = false;
        
        public void ReverseDirection()
        {
            _direction = !_direction;
        }
		
        public List<string> getItems()
        {
            return _collection;
        }
		
        public void AddItem(string item)
        {
            this._collection.Add(item);
        }
		
        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction);
        }
    }
}
