using System;


namespace DataStructure.Utils
{
     class HashSetImpl<T>
    {
        private T[] _set;
        private int _count;

        public HashSetImpl()
        {
            _set = new T[10]; 
            _count = 0;
        }

        public void Add(T item) 
        {
            bool isElement = false;

            for (int i = 0; i < _count; ++i)
            {
                if (_set[i].Equals(item))
                {
                    isElement = true;
                    break;
                }
            }

            if (!isElement)
            {
                if (_count == _set.Length)
                {
                    _set = new T[_count * 2];
                }
                _set[_count] = item;
                _count++;
            }
        }

      
        public int Count()
        {
            return _count;
        }

        public void Print()
        {

            for (int i = 0; i < _count; ++i)
            {
                Console.Write(_set[i] + " ");
            }
            Console.WriteLine();
        }




    }
}
