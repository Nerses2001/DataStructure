using System;
using System.Collections.Generic;


// Ading an item (Add method) | Complexity: O(1)(average case), O(n)(worst case)
// Checking if a key exists (ContainsKey method) | Complexity: O(1)
//Retrieving Complexity: O(1)
//Changing Complexity: O(1)

namespace DataStructure.Utils
{
    public class HashMapImp<TKey, TValue>
    {
        private List<TKey> _keys;
        private List<TValue> _values;

        public HashMapImp()
        {
            _keys = new List<TKey>();
            _values = new List<TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            //foreach (var item in _keys)
            //{
            //    if (key.Equals(item)){
            //        throw new ArgumentException("An element with the same key already exists in the dictionary.");
            //        
            //    }
            //}
            if (ContainsKey(key))
            {
                throw new ArgumentException("An element with the same key already exists in the dictionary.");
            }

            _keys.Add(key);
            _values.Add(value);
        }

        public bool ContainsKey(TKey key)
        {
            return _keys.Contains(key);

        }
        public bool Remove(TKey key)
        {
            int index = _keys.IndexOf(key);
            if (index >= 0)
            {
                _keys.RemoveAt(index);
                _values.RemoveAt(index);
                return true;
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = _keys.IndexOf(key);
            if (index >= 0)
            {
                value = _values[index];
                return true;
            }

            value = default(TValue);
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                Console.WriteLine($"Key: {_keys[i]}, Value: {_values[i]}");
            }
        }

        public List<TKey> AllKey()
        {
            return new List<TKey>(_keys);
        }

        public List<TValue> AllValue()
        {
            return new List<TValue>(_values);
        }

        public void Put(TKey key, TValue value)
        {
            int index = _keys.IndexOf(key);
            if (index >= 0)
            {
                _values[index] = value; 

            }
            else
            {
                _keys.Add(key);
                _values.Add(value);
            }
        }

        public int Count()
        {
            return _keys.Count;
        }

        public void Clear()
        {
            _keys.Clear();
            _values.Clear();
        }

    }
}
