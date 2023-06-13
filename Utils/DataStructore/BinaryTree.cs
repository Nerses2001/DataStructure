using System;
using System.Collections.Generic;
using System.Xml.Linq;

// Access O(log n)
// Search O(log n)
// Insert Delete O(log n)

namespace DataStructure.Utils.DataStructures
{
    class Node<T>
    {
        private T _data;
        private Node<T> _left;
        private Node<T> _right;

        public Node(T item)
        {
            _data = item;
            _left = _right = null;
        }

        public Node<T> Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Node<T> Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    class BinaryTree<T>
    {
        private Node<T> root;

        public Node<T> Root
        {
            get { return root; }
        }

        public BinaryTree()
        {
            root = null;
        }

        private void InorderTraversal(Node<T> node)
        {
            if (node == null)
                return;

            InorderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InorderTraversal(node.Right);
        }

        public void InorderTraversal()
        {
            InorderTraversal(root);
        }

        public void AddNode(T data)
        {
            root = AddNodeRecursive(root, data);
        }

        private Node<T> AddNodeRecursive(Node<T> current, T data)
        {
            if (current == null)
                return new Node<T>(data);

            if (Comparer<T>.Default.Compare(data, current.Data) < 0)
                current.Left = AddNodeRecursive(current.Left, data);
            else if (Comparer<T>.Default.Compare(data, current.Data) > 0)
                current.Right = AddNodeRecursive(current.Right, data);

            return current;
        }

        public void DeleteNode(T data)
        {
            root = DeleteNodeRecursive(root, data);
        }

        private Node<T> DeleteNodeRecursive(Node<T> current, T data)
        {
            if (current == null)
                return null;

            bool currentValue = Convert.ToBoolean(current.Data);
            bool deleteData = Convert.ToBoolean(data);

            if (deleteData.CompareTo(currentValue) < 0)
            {
                current.Left = DeleteNodeRecursive(current.Left, data);
            }
            else if (deleteData.CompareTo(currentValue) > 0)
            {
                current.Right = DeleteNodeRecursive(current.Right, data);
            }
            else
            {
                if (current.Left == null && current.Right == null)
                {
                    return null;
                }
                else if (current.Left == null)
                {
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    return current.Left;
                }
                else
                {
                    bool minValue = FindMinValue(current.Right);
                    current.Data = (T)Convert.ChangeType(minValue, typeof(T));
                    current.Right = DeleteNodeRecursive(current.Right, (T)Convert.ChangeType(minValue, typeof(T)));
                }
            }

            return current;
        }

        private bool FindMinValue(Node<T> node)
        {
            bool minValue = Convert.ToBoolean(node.Data);
            while (node.Left != null)
            {
                minValue = Convert.ToBoolean(node.Left.Data);
                node = node.Left;
            }
            return minValue;
        }

      
    }
}
