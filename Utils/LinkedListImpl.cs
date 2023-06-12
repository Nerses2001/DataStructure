using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Print()
        {
            Node<T> currentNode = _head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
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
                if (currentNode != null && currentNode.Next.Value.Equals(value))
                {
                    currentNode.Next = currentNode.Next.Next;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }
        public void DeleteAtIndex(int index)
        {
            if (index == 0)
            {
                _head = _head.Next;
                return;
            }

            Node<T> currentNode = _head;
            Node<T> previousNode = null;
            int currentIndex = 0;

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
