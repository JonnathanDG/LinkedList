using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        //Class variables
        //private T element;
        private Node<T> previousNode;
        private Node<T> nextNode;

        //Constructor
        public Node(T newElement = default(T), Node<T> previous = null, Node<T> next = null)
        {
            this.Element = newElement;
            this.previousNode = previous;
            this.nextNode = next;
        }

        // Element setter and getters
        public T Element { get; set; }

        // Next node getter and setter
        public Node<T> Next
        {
            get
            {
                return this.nextNode;
            }

            set
            {
                this.nextNode = value;
            }
        }

        //Previous Node getter and setter
        public Node<T> Previous
        {
            get
            {
                return this.previousNode;
            }

            set
            {
                this.previousNode = value;
            }
        }

    }
}
