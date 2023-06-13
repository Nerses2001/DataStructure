using System;

// Impalamate ArryList
// Search complexities  is O(1)
// Add complexities  is O(n)
// Delete (removing an element at the end of the list): O(1)
// Delete (removing an element at a specific index): O(n)

namespace DataStructure.Utils
{
    class ArrayListImpl<T>
    {
        private T[] _array;
        private int _count;

        public ArrayListImpl()
        {
            _array = new T[10]; 
            _count = 0;
        }

        public void Add(T item) 
        {
            if(_count == _array.Length)
            {
                _array = new T[_count * 2];
            }
            _array[_count] = item;
            _count++;
        }

        public T GetElement(int index)
        {
            if(index >  0 && index < _count)
            {
                return _array[index];
            }
            throw new IndexOutOfRangeException("Index is out of range !!!");
        }
        
        public int Count()
        {
            return _count;
        }

        public void Print()
        {

            for (int i = 0; i < _count; ++i)
            {
                Console.Write(_array[i] + " ");
            }
            Console.WriteLine();
        }

        public T LastElement()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The ArrayList is empty.");
            }

            return _array[_count - 1];
        }

        public T FirstElement()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The ArrayList is empty.");
            }

            return _array[0];
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(_array, item);

            if (index >= 0)
            {
                for (int i = index; i < _count - 1; ++i)
                {
                    _array[i] = _array[i + 1];
                }

                _count--;
            }
        }

        public T[] SubArrayList(int startIndex = 0, int lastIndex = -1)
        {
            if (startIndex < 0 || startIndex >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Invalid start index.");
            }

            if (lastIndex == -1)
            {
                lastIndex = _count - 1;
            }
            else if (lastIndex < startIndex || lastIndex >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(lastIndex), "Invalid last index.");
            }

            int subArrayLength = lastIndex - startIndex + 1;
            T[] subArray = new T[subArrayLength];

            Array.Copy(_array, startIndex, subArray, 0, subArrayLength);

            return subArray;
        }
    }
}

