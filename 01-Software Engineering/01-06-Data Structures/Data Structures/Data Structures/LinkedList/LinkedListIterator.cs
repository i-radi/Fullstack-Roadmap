namespace Data_Structures.LinkedList
{
    public class LinkedListIterator
    {
        private LinkedListNode currentNode;

        // default constructor for the iterator
        public LinkedListIterator()
        {
            this.currentNode = null;
        }

        // constructor for the iterator with a starting node
        public LinkedListIterator(LinkedListNode node)
        {
            this.currentNode = node;
        }

        // return the current node's data
        public int data()
        {
            return this.currentNode.data;
        }

        // advance to the next node and return the iterator
        public LinkedListIterator next()
        {
            this.currentNode = this.currentNode.next;
            return this;
        }

        // return the current node
        public LinkedListNode current()
        {
            return this.currentNode;
        }
    }
}
