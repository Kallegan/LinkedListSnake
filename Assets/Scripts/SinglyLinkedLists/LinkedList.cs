using System;

namespace SinglyLinkedLists
{
    public class LinkedList<T> //very basic singly link list with generic type.
    {
        private Node<T> current;
        private Node<T> head;
        private Node<T> previous;

        //referense to the first node in the list.
        public int count; //current size of the list.


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

        public T Add(int index, T item) //adds to the list at specific index location.
        {
            if (index < 0) //if index is below 0, an error will be shown.
            {
                throw new ArgumentOutOfRangeException("Index: " + index);
            }
            if(index > count) //if the index is bigger than the size of the list, the index will add to the new size.
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

        public void Add(T item) //adds to the list at the current count/tail.
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

        public void Clear() //sets the list head to null, and count back to 0.
        {
            head = null;
            count = 0;
        }

        public int IndexOf(T item) //gets the index of the item in the list, if nothing is found, return -1.
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

       public bool Contains(T item) //return true of false depending if the item is found i list.
        {
            return IndexOf(item) >= 0;
        }

       private T Get(int index) //Gets item at the specified index.
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

