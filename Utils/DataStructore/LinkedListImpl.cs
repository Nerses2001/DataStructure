using System;
using System.Collections.Generic;

// Implementation Linked List 
//Adding elemet at the head: complexity is O(1) 
//Adding elemet at the tail:complexity is O(1) 
//Adding elemet at a specific position:is O(n) 

//Delete elemet at the head: complexity is O(1) 
//Delete elemet at the tail:complexity is O(1) 
//Delete elemet at a specific position:is O(n) 

//Search elemet complexity  is O(n)

//Change elemet complexity  is O(n)



namespace DataStructure.Utils
{
    

    class  Node<T>
    {
        private T _value;
        private Node<T> _next;
        public T Value 
        { 
            get { return _value; } 
            set { _value = value; }
        }
        public Node<T> Next { 
            get { return _next; }
            set { _next = value; }
        }

    }
    class LinkedListImpl<T>
    {
        private Node<T> _head;

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = value;

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node<T> currentNode = _head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
        }
        public void AddAll(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }
        public void Print()
        {
            Node<T> currentNode = _head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Value + " ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }
        public void Delete(T value)
        {
            if (_head == null)
            {
                return;
            }

            if (_head != null && _head.Value.Equals(value))
            {
                _head = _head.Next;
                return;
            }

            Node<T> currentNode = _head;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    currentNode.Next = currentNode.Next.Next;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }
        public void DeleteAtIndex(int index)
        {

            if (index < 0 || index >= GetLength())
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                _head = _head.Next;
                return;
            }

            Node<T> currentNode = _head;
            Node<T> previousNode = null;
            int currentIndex = 1;

            while (currentNode != null && currentIndex != index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                previousNode.Next = currentNode.Next;
            }
        }
        public void ChangeValue(int index, T newValue)
        {
            Node<T> currentNode = _head;
            int currentIndex = 0;
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    currentNode.Value = newValue;
                    return;
                }
                currentNode = currentNode.Next;
                currentIndex++;
            }
        }
        private int GetLength()
        {
            int length = 0;
            Node<T> currentNode = _head;
            while (currentNode != null)
            {
                length++;
                currentNode = currentNode.Next;
            }
            return length;
        }
        public void Reverse()
        {
            Node<T> previousNode = null;
            Node<T> currentNode = _head;
            Node<T> nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.Next;  
                currentNode.Next = previousNode;  

                previousNode = currentNode;
                currentNode = nextNode;
            }

            _head = previousNode;          }
    }
}
