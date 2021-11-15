using System;
using System.Collections.Generic;

namespace SinglyLinkedLists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        /* Constructor:
         * [x] LinkedList() Initialises the private fields
         *
         * Private Fields;
         * [x] Node head - referense to the first node in the list.
         * [x] int size - current size of the list.
         *
         * public properties:
         * [x] Empty - if the list is empty
         * [ ] Count - how many items are in the list.
         * [ ] Indexer - access the data like an array in different indexes.
         *
         * Methods:
         * [ ] Add(int index, object o) Add an item to list at a spicified index.
         * [ ] Add(object o) - Add an item to the end of the list.
         * [ ] Remove(int index) - Remove the item in the list at a specified index.
         * [ ] Clear() - CLear the list.
         * [ ] IndexOf(object o) - gets the index of the item in the list, if nothing is found, return -1.
         * [ ] Contains(object o) - return true of false depending if the item is found i list.
         * [ ] Get(int index) Gets item at the specified index.
         * 
         */
        
        private Node<T> current;
        private Node<T> head; //referense to the first node in the list.
        private int count; //current size of the list.
        
        //test//
        private Node<T> _headNode;
        
        public LinkedList(Node<T> current)
        {
            this.current = current;
        }
        
        
        private IEnumerable<Node<T>> Nodes
        {
            get
            {
                Node<T> node = _headNode;
                while (node != null)
                {
                    yield return node;
                    node = node.next;
                }
            }
        }
        
        public LinkedList(IEnumerable<T> Items)
        {
            foreach (T item in Items)
            {
                Add(item);
            }
        }
        
        public void ForEach(Action<T> action) //adds foreach function.
        {
            foreach (Node<T> item in Nodes)
            {
                action(item.data);
            }
        }
        
        public void AddRange(IEnumerable<T> Items)
        {
            foreach (T item in Items)
            {
                Add(item);
            }
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node<T> item in Nodes)
            {
                yield return item.data;
            }
        }
        
        //test

        public LinkedList() //Initialises the private fields.
        {
            //all values are null/0 at the start since list is empty.
            head = null;
            count = 0;
        }

        public bool Empty
        {
            //checks if list is empty by comparing size to 0. If empty bool empty, set bool to true, if 0<, false.
            get { return count == 0; }
        }

        public int Count
        {
            get { return count; } //return the current size of the list.
        }

        public T this[int index]
        {
            get { return this.Get(index); }
        }

        public T Add(int index, T item) //adds to the list.
        {
            if (index < 0) //if index is below 0, an error will be shown.
            {
                throw new ArgumentOutOfRangeException("Index: " + index);
            }
            if(index > count) //if the index is bigge than the size of the list, the index will add to the new size.
            {
                index = count;
            }

            Node<T> current = head; //gets the first node in the list (the head node).

            if (Empty || index == 0) //if the list is empty or index is 0, we create a new node at first index.
            {
                head = new Node<T>(item, head);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }                 

                current.Next = new Node<T>(item, current.Next);
            }               

            count++; //increase count.

                return item; //returns item to the list.
            
        }

        public void Add(T item)
        {
            Add(count, item);
        }
        

        public T Remove(int index) //used for removing at given index location.
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index: " + index);
            }
            if (Empty)
            {
                return default;
            }
               
            if(index >= count)
            {
                index = count -1;
            }

            Node<T> current = head; //gets first node in list.
            T result = default; //object remove method returns.

            if(index == 0)
            {
                result = current.Data;
                head = current.Next; 
            }
            else
            {
                for (int i = 0; i < index -1; i++)
                {
                    current = current.Next;
                }
                result = current.Next.Data; //gets the data from the node which will be removed.

                current.Next = current.Next.Next; //sets referense to the node behind the node that will be removed.
            }

            count--;

            return result;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public int IndexOf(T item)
        {
            Node<T> current = head;

            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(item))
                {
                    return i;
                }
                current = current.Next;                 
            }

            return -1;
        }

       public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public T Get(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index: " + index);
            }
            if(Empty)
            {
                return default;
            }
            if (index >= count)
            {
                index = count - 1;
            }
            Node<T> current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data; //returns data at specified node and index.
        }

    }

}

