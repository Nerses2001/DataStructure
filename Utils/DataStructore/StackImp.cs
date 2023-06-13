using System;
using System.Collections.Generic;

// Stack LIFO
// Access O(n)
// Search O(n)
// Insert Delete O(1)

namespace DataStructure.Utils
{
    class StackImp<T>
    {
        private T[] _stackArray;
        private int _top;

        public StackImp(int capacity)
        {
            _stackArray = new T[capacity];
            _top = -1;
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public bool IsFull()
        {
            return _top == _stackArray.Length - 1;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                throw new Exception("Stack is full");
            }

            _stackArray[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            return _stackArray[_top--];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            return _stackArray[_top];
        }

        public int Size()
        {
            return _top + 1;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.WriteLine("Stack contents:");
            for (int i = _top; i >= 0; i--)
            {
                Console.Write(_stackArray[i] + " ");
            }
            Console.WriteLine();    
        }
    
    }
}
