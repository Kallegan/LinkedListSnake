

namespace SinglyLinkedLists
{
    public class Node<T>
    {
        /*constructor:
         * [ ] Node(object data, Node next)
         *
         * private Fields;
         * object data - contains data of the node, what we want to store in the list
         * Node next - referense to the next node in the list
         *
         * public Properties:
         * [ ] data, get and set data field
         * [ ] next, get and set the next field   
         */
        //private fields   
        public T data;
        public Node<T> next; //made public so I can access in linked list.

        public Node(T data, Node<T> next) //constructor
        {
            //assigning arguments passed in the constructor into the private fields.
            this.data = data;
            this.next = next;
        }

        //implementing public properties
        public T Data
        {
            get { return data; } //gets data
            set { data = value; } //sets data, pass value to the setter
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }

        }
    }
    
    
}
    
