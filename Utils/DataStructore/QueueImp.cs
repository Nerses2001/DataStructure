using System;

// Queue FIFO
// Access O(n)
// Search O(n)
// Insert Delete O(1)


namespace DataStructure.Utils
{
    class QueueImp<T>
    {
        private T[] _queueArray;
        private int _front;
        private int _rear;
        private int _count;

        public QueueImp(int capacity)
        {
            _queueArray = new T[capacity];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _queueArray.Length;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new Exception("Queue is full");
            }

            _rear = (_rear + 1) % _queueArray.Length;
            _queueArray[_rear] = item;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            T item = _queueArray[_front];
            _front = (_front + 1) % _queueArray.Length;
            _count--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            return _queueArray[_front];
        }

        public int Size()
        {
            return _count;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Console.WriteLine("Queue contents:");
            int index = _front;
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_queueArray[index]);
                index = (index + 1) % _queueArray.Length;
            }
        }
    }
}
