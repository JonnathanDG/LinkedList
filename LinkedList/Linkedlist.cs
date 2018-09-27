using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T> where T : IComparable<T>
    {
        //class variables
        private Node<T> head;
        private Node<T> tail;
        private int _size;

        //LinkedList contructor
        public LinkedList()
        {
            this.head = this.tail = null;
            _size = 0;
        }

        //Returns the size of the linked list
        public int GetSize()
        {
            return _size;
        }

        //Returns the head of the linkedlist
        public Node<T> GetHead()
        {
            return this.head;
        }

        //Gets the tail of the constructor
        public Node<T> GetTail()
        {
            return this.tail;

            ////Checks if there are nodes in the list
            //if (this.head == null)
            //{
            //    this.tail = null;
            //}

            ////Sets the node as the head
            //Node<T> node = this.head;

            ////The loop only runs if the node(head) exist
            //while (node != null)
            //{
            //    //If the current node returns null to the next element 
            //    if (node.Next == null)
            //    {
            //        //Then the tail was found
            //        this.tail = node;
            //    }

            //    //Updates the current node to the next node
            //    node = node.Next;
            //}

            //return this.tail;
        }

        //Returns true if the linkedlist is empty
        public bool IsEmpty()
        {
            return GetSize() == 0;// ? true : false;
        }

        //Adds the node as the first one of the element
        public void AddFirst(T element)
        {

            //Creates a new node
            Node<T> newHead = new Node<T>(element);

            //If there aren't nodes then the head is set
            if (this.head == null)
            {
                this.head = newHead;
                this.tail = head;
            }
            else
            {

                // if there are nodes then we make a reference to the head
                Node<T> oldHead = this.head;

                //Set the new element as the new head
                this.head = newHead;

                //Connects the oldhead to the new head
                oldHead.Previous = this.head;

                //make a pointer to the old head so the nodes are not lost
                this.head.Next = oldHead;

            }

            this._size++;

        }

        //Returns the first element of the list
        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            //The first element is always the head
            return this.head.Element;


        }

        //Return the last node in the linked list
        public T GetLast()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            //The first element is always the head
            return this.tail.Element;


            ////I know there is a better way...
            //Node<T> node = this.head;


            ////In case of no nodes
            //if(node == null)
            //{
            //    //tail = this.head.Element;

            //    throw new ApplicationException();
            //}

            //T tail = node.Element;

            //while (node != null)
            //{ 

            //    //If the next pointer returns a null
            //    //means we got the tail
            //    if (node.Next == null)
            //    {
            //        tail = node.Element;
            //    }

            //    //updates the node in order to look for the tail
            //    node = node.Next;
            //}

            //return tail;

        }

        //Clears the linkedlist
        public void Clear()
        {
            //Set the head to null and resets the counter
            this.head = null;
            this._size = 0;
        }



        //Add the element to the tail
        public void AddLast(T element)
        {
            // means a tail was found
            if (!IsEmpty())
            {

                //creates a new tail, with a pointer back to the oldTail
                Node<T> newTail = new Node<T>(element, this.tail, null);

                Node<T> oldTail = this.tail;

                // then just set the next property 
                // and a new tail is created
                oldTail.Next = newTail;

                this.tail = newTail;
            }
            else
            {
                //otherwise create the head
                this.head = new Node<T>(element);
                this.tail = head;
            }

            //updates the size of the list
            this._size++;

        }

        //Removes the first element of the list
        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            //Reduce the size of the list
            this._size--;

            //Holds the old head
            Node<T> oldHead = this.head;

            if (this.head.Next != null)
            {
                //Gets the new head
                Node<T> newHead = this.head.Next;

                //Sets the new head
                this.head = newHead;
                this.head.Previous = null;

            }
            else
            {
                //If there was only one element
                //and now is removed then the vars are set it
                this.head = null;
                this.tail = this.head;
                this._size = 0;
            }

            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            //Reduce the size of the list
            this._size--;

            //Holds the old head
            Node<T> oldTail = this.tail;

            if (this.tail.Previous != null)
            {
                //Gets the new tail
                Node<T> newTail = this.tail.Previous;

                //Sets the new tail
                this.tail = newTail;
                this.tail.Next = null;
            }
            else
            {
                //If there was only one element
                //and now is removed then the vars are set it to
                this.head = null;
                this.tail = this.head;
                this._size = 0;
            }

            return oldTail.Element;
        }

        //Sets the element as the first in the list
        public T SetFirst(T element)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }

            T oldValue = this.head.Element;

            this.head.Element = element;

            return oldValue;

            ////Holds the old head
            //Node<T> oldHead = this.head;

            //this.AddFirst(element);

            //return oldHead.Element;
        }

        //Sets the elements as the last one in the list
        public T SetLast(T element)
        {
            if (IsEmpty())
            {
                throw new ApplicationException();
            }
            T oldValue = this.tail.Element;
            this.tail.Element = element;
            return oldValue;

            ////Holds the old tail
            //Node<T> oldTail = this.tail;

            //this.AddLast(element);

            //return oldTail.Element;
        }


        //Gets an element from the position requested
        public T Get(int position)
        {
            return GetNodeByPosition(position).Element;

            ////Gets the size of the list
            //int listSize = GetSize();

            //if (IsEmpty() || position < 1 || position > listSize)
            //{
            //    throw new ApplicationException();
            //}

            //Node<T> elementToReturn = new Node<T>();

            ////If the position is equal to one then 
            //// the first node is being called which is the head
            //if (position == 1)
            //{
            //    elementToReturn = this.head;
            //}
            //else if (position == listSize)
            //{
            //    //If the position is equal to the size of the list
            //    // then the tail is returned
            //    elementToReturn = this.tail;
            //}
            //else
            //{
            //    //Look for the element in position between head and tail

            //    //Sets the node
            //    Node<T> node = this.head.Next;

            //    //sets the counter
            //    int counter = 2;

            //    //The loop only runs if the node exist
            //    while (node != null)
            //    {
            //        if (counter == position)
            //        {
            //            elementToReturn = node;
            //            break;
            //        }

            //        node = node.Next;

            //        //Updates the counter
            //        counter++;
            //    }
            //}

            //return elementToReturn.Element;
        }

        //Removes an element in the given position
        public T Remove(int position)
        {
            Node<T> node = GetNodeByPosition(position);

            return Remove(node);

            ////Gets the size of the list
            //int listSize = GetSize();

            //if (IsEmpty() || position < 1 || position > listSize)
            //{
            //    throw new ApplicationException();
            //}

            //Node<T> elementToReturn = new Node<T>();

            //if (position == 1)
            //{
            //    //Removes the head
            //    elementToReturn.Element = RemoveFirst();
            //}
            //else if (position == listSize)
            //{
            //    // Removes the tail
            //    elementToReturn.Element = RemoveLast();
            //}
            //else
            //{
            //    //Look for the element in position between head and tail

            //    //Sets the node
            //    Node<T> node = this.head.Next;

            //    //sets the counter
            //    int counter = 2;

            //    //The loop only runs if the node(head) exist
            //    while (node != null)
            //    {
            //        if (counter == position)
            //        {
            //            elementToReturn = node;

            //            Node<T> previous = elementToReturn.Previous;

            //            previous.Next = previous.Next.Next;

            //            //Reduce the size of the list
            //            this._size--;

            //            break;
            //        }

            //        node = node.Next;

            //        //Updates the counter
            //        counter++;
            //    }
            //}

            //return elementToReturn.Element;
        }

        //Set a new element in the node that is in the given position
        public T Set(T element, int position)
        {
            Node<T> node = GetNodeByPosition(position);

            T oldElement = node.Element;

            node.Element = element;

            return oldElement;

            ////Gets the size of the list
            //int listSize = GetSize();

            //if (IsEmpty() || position < 1 || position > listSize)
            //{
            //    throw new ApplicationException();
            //}

            //Node<T> oldElement = new Node<T>(element);

            //if (position == 1)
            //{
            //    oldElement.Element = this.head.Element;
            //    this.head.Element = element;

            //}
            //else if (position == listSize)
            //{
            //    oldElement.Element = this.tail.Element;

            //    //If the position is equal to the size of the list
            //    // then the tail is returned
            //    this.tail.Element = element;
            //}
            //else
            //{
            //    //Look for the element in position between head and tail

            //    //Sets the node as the head
            //    Node<T> node = this.head.Next;

            //    //sets the counter
            //    int counter = 2;

            //    //The loop only runs if the node exist
            //    while (node != null)
            //    {
            //        if (counter == position)
            //        {
            //            oldElement.Element = node.Element;

            //            node.Element = element;

            //            break;
            //        }

            //        node = node.Next;

            //        //Updates the counter
            //        counter++;
            //    }
            //}

            //return oldElement.Element;
        }



        //Sets the element in after the given position
        public void AddAfter(T element, int position)
        {
            Node<T> node = GetNodeByPosition(position);

            if (node == tail)
            {
                AddLast(element);
            }
            else
            {
                Node<T> newNode = new Node<T>(element, node, node.Next);

                node.Next = newNode;

                newNode.Next.Previous = newNode;

                _size++;
            }


            ////Gets the size of the list
            //int listSize = GetSize();

            //if (IsEmpty() || position < 1 || position > listSize)
            //{
            //    throw new ApplicationException();
            //}

            //Node<T> newElement = new Node<T>(element);

            //if (position == 1)
            //{
            //    if(this.head.Next != null)
            //    {
            //        Node<T> nodesAfterHead = this.head.Next;

            //        this.head.Next = newElement;
            //        this.head.Next.Next = nodesAfterHead;
            //    }
            //    else
            //    {
            //        this.head.Next = newElement;
            //    }

            //}
            //else if (position == listSize)
            //{

            //    //If the position is equal to the size of the list
            //    // then the tail is returned
            //    SetLast(newElement.Element);

            //    //Sets will update the size... which is done later in the method...
            //    //so I took care of that error here... :) ... I know...
            //    this._size--;
            //}
            //else
            //{
            //    //Look for the element in position between head and tail

            //    //Sets the node as the head
            //    Node<T> node = this.head.Next;

            //    //sets the counter
            //    int counter = 2;

            //    //The loop only runs if the node exist
            //    while (node != null)
            //    {
            //        if (counter == position)
            //        {
            //            Node<T> nodesAfterCurrentNode = node.Next;

            //            node = newElement;

            //            node.Next = nodesAfterCurrentNode;

            //            break;
            //        }

            //        node = node.Next;

            //        //Updates the counter
            //        counter++;
            //    }
            //}

            //this._size++;
        }

        //Sets the element before the given position
        public void AddBefore(T element, int position)
        {
            Node<T> node = GetNodeByPosition(position);

            if (node == head)
            {
                AddFirst(element);
            }
            else
            {

                Node<T> prev = node.Previous;

                Node<T> newNode = new Node<T>(element, prev, node);

                node.Previous = newNode;

                prev.Next = newNode;

                _size++;
            }

            //    //Gets the size of the list
            //    int listSize = GetSize();

            //    if (IsEmpty() || position < 1 || position > listSize)
            //    {
            //        throw new ApplicationException();
            //    }

            //    Node<T> newElement = new Node<T>(element);

            //    if (position == 1)
            //    {
            //        if (this.head.Next != null)
            //        {
            //            Node<T> nodesToSave = this.head;

            //            SetFirst(newElement.Element);

            //            this.head.Next = nodesToSave;

            //            this._size--;
            //        }
            //        else
            //        {
            //            this.head = newElement;
            //        }

            //    }
            //    else if (position == listSize)
            //    {

            //        //If the position is equal to the size of the list

            //        Node<T> nodeBeforeTail = this.tail.Previous;

            //        nodeBeforeTail.Next = newElement;

            //        newElement.Previous = nodeBeforeTail;

            //        this.tail.Previous = newElement;

            //    }
            //    else
            //    {
            //        //Look for the element in position between head and tail

            //        //Sets the node as the head
            //        Node<T> node = this.head.Next;

            //        //sets the counter
            //        int counter = 2;

            //        //The loop only runs if the node exist
            //        while (node != null)
            //        {
            //            if (counter == position)
            //            {
            //                Node<T> nodeBeforeCurrent = node.Previous;

            //                newElement.Next = node;

            //                nodeBeforeCurrent.Next = newElement;

            //                break;
            //            }

            //            node = node.Next;

            //            //Updates the counter
            //            counter++;
            //        }
            //    }

            //    this._size++;
        }

        //Returns the node 
        public T Get(T node)
        {
            return GetNodeByElement(node).Element;
        }

        //Sets the element in after the given element
        public void AddAfter(T element, T oldElement)
        {
            //Sets a node to work with usign the old element passed in the parameter
            Node<T> node = GetNodeByElement(oldElement);

            // if the node is equal to the tail then the new node
            // is added as the last node in the list
            if (node == tail)
            {
                AddLast(element);
            }
            else
            {
                //Creates a new node using the element in the parameter
                // the previous pointer is set to the oldElement(see parameter) and the next pointer
                // to the next element of the old node
                Node<T> newNode = new Node<T>(element, node, node.Next);

                //Sets the pointer of the node
                node.Next = newNode;

                //Makes sure the list does not break
                // by setting the previous node (Next property) to point to the new node
                newNode.Next.Previous = newNode;

                //updates the list size
                _size++;
            }

        }

        //Sets the element before the given position
        public void AddBefore(T element, T oldElement)
        {
            Node<T> node = GetNodeByElement(oldElement);

            if (node == head)
            {
                AddFirst(element);
            }
            else
            {
                Node<T> prev = node.Previous;
                Node<T> newNode = new Node<T>(element, prev, node);
                node.Previous = newNode;
                prev.Next = newNode;
                _size++;
            }

        }

        //Removes an element in the given old element
        public T Remove(T element)
        {
            Node<T> node = GetNodeByElement(element);

            return Remove(node);
        }

        //Set a new element in the node that is in the given old element
        public T Set(T element, T oldElement)
        {
            Node<T> node = GetNodeByElement(oldElement);
            T oldElementFound = node.Element;
            node.Element = element;
            return oldElementFound;

        }

        public void Insert(T element)
        {
            T elementToInsert = element;

            Node<T> current = head;

            if (IsEmpty())
            {
                AddFirst(element);
            }
            else
            {

                while (current != null && elementToInsert.CompareTo(current.Element) < 0)
                {
                    current = current.Next;
                }

                //If the element to insert is equal to the head
                // then is inserted next to the head
                if (elementToInsert.CompareTo(head.Element) == 0)
                {
                    AddAfter(elementToInsert, head.Element);
                }
                else if (elementToInsert.CompareTo(head.Element) < 0)
                {
                    // If is not greater then the element is inserted before the element
                    AddBefore(elementToInsert, head.Element);
                }
                else if (elementToInsert.CompareTo(tail.Element) > 0)
                {
                    //If the element is gretaer than the tail then is inserted after
                    AddAfter(elementToInsert, tail.Element);
                }
                else
                {
                    // else the element is inserted after the current element(which is smaller than the one inserted)
                    AddAfter(elementToInsert, current.Element);
                }
            }
        }

        //sorts the list in ascending order
        public void SortAscending()
        {
            for (int i = 0; i < _size; i++)
            {
                Node<T> currentElement = head;

                //The minus one is there because usually the list and arrays
                // have an index of zero so even if the list has 3 elements ... the index is equal 2
                for (int j = 0; j < (_size - i - 1); j++)
                {
                    //Compares the current element on the list with the next one
                    if (currentElement.Element.CompareTo(currentElement.Next.Element) > 0)
                    {
                        //If the current element is greater then the next element is smaller
                        T smallerElement = currentElement.Next.Element;

                        //We set the current element as greater 
                        currentElement.Next.Element = currentElement.Element;

                        //The current element is now the smaller found before.
                        currentElement.Element = smallerElement;
                    }

                    currentElement = currentElement.Next;
                }
            }

        }


        /////////////////////////////////////
        /// METHODS 
        /// 
        // Gets the element that is equal to the parameter
        private Node<T> GetNodeByElement(T element)
        {

            if (this._size <= 0)
            {
                throw new ApplicationException();
            }
            else if (element == null)
            {
                throw new ArgumentNullException();
            }

            T nodeToBeFound = element;

            Node<T> current = head;
            bool isFound = false;

            //Loops until the elemtn in parameter is equal 
            // to the current one in the loop
            while (current != null && !isFound)
            {

                if (nodeToBeFound.CompareTo(current.Element) == 0)
                {
                    isFound = true;
                }
                else
                {
                    current = current.Next;
                }

            }

            if (current == null)
            {
                throw new ApplicationException();
            }

            return current;
        }

        //Get the node by position
        private Node<T> GetNodeByPosition(int position)
        {
            //Only triggers if the parameter is out of range
            if (position <= 0 || position > _size)
            {
                throw new ApplicationException();
            }

            Node<T> curr = head;

            int currPos = 1;

            bool isFound = false;

            //Runs until current node is null and current position is not equal
            // to the position passed in the parameter
            while (curr != null && !isFound)
            {
                if (currPos == position)
                {
                    isFound = true;
                }
                else
                {
                    curr = curr.Next;//updates the node
                    currPos++; //updates de current position
                }

            }

            return curr;
        }

        //Removes a node between head and tail
        private T RemoveBetween(Node<T> node)
        {
            Node<T> prev = node.Previous; //Set previous node
            Node<T> next = node.Next; // Set next node

            // Now the previou node points to the node after the one that is being removed
            prev.Next = next;

            // Now the next node point to the previous node (the one before of the removed one)
            next.Previous = prev;

            //Updates the list size
            _size--;

            return node.Element;
        }

        //Removes a node
        private T Remove(Node<T> node)
        {
            //Sets the old element 
            T oldElement = node.Element;

            //Checks for the head
            if (node.Previous == null)
            {
                oldElement = RemoveFirst();
            }
            else if (node.Next == null)//Checks for the tail
            {
                oldElement = RemoveLast();
            }
            else
            {
                //Removes the node between the head and tail
                oldElement = RemoveBetween(node);
            }

            return oldElement;
        }

    }
}
