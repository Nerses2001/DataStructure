using System;
using System.Collections.Generic;

// Add Operation Complexity : O(1)
// Remove  Operation Complexity : O(1)
// Search  Operation Complexity : O(n)


namespace DataStructure.Utils
{
    public class HashSetOptimalImp<T>
    {
        private HashMapImp<T, bool> hashMap;

        public HashSetOptimalImp()
        {
            hashMap = new HashMapImp<T, bool>();
        }

        public void Add(T item)
        {
            hashMap.Put(item, true);
        }

        public bool Contains(T item)
        {
            return hashMap.ContainsKey(item);
        }

        public bool Remove(T item)
        {
            return hashMap.Remove(item);
        }

        public void Clear()
        {
            hashMap.Clear();
        }

        public int Count
        {
            get { return hashMap.Count(); }
        }

        public IEnumerable<T> Items
        {
            get { return hashMap.AllKey(); }
        }

        public void Print()
        {
            Console.Write("Items in the set: ");
            foreach (var item in Items)
            {
                Console.Write(item);
            }
            Console.WriteLine();    
        }
    }


}
