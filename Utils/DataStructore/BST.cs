using System;
using System.Collections.Generic;

// Used when need searching, adding, deleting, fiend min or max element, next ellement, previous element


namespace DataStructure.Utils.DataStructore
{
    

    public class BST<T>
    {
        private BSTNode<T> root;

        public BST()
        {
            root = null;
        }

        public void PrintBFS()
        {
            Console.WriteLine("BFS traversal");
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            if (root != null)
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                BSTNode<T> current = queue.Dequeue();
                Console.Write(current.Data + " ");

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right!= null)
                    queue.Enqueue(current.Right);
            }
            Console.WriteLine();
        }

        public T Min()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            BSTNode<T> tmp = root;
            while (tmp.Left!= null)
            {
                tmp = tmp.Right;
            }
            return tmp.Data;
        }

        public T Max()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            BSTNode<T> tmp = root;
            while (tmp.Right!= null)
            {
                tmp = tmp.Right;
            }
            return tmp.Data;
        }

        public bool Insert(T obj)
        {
            if (root == null)
            {
                root = new BSTNode<T>(obj);
                return true;
            }

            BSTNode<T> tmpNode = root;
            BSTNode<T> tmpParent = null;

            while (tmpNode != null)
            {
                if (obj.Equals(tmpNode.Data))
                {
                    return false;
                }
                if (Comparer<T>.Default.Compare(obj, tmpNode.Data) < 0)
                {
                    tmpParent = tmpNode;
                    tmpNode = tmpNode.Left;
                }
                else
                {
                    tmpParent = tmpNode;
                    tmpNode = tmpNode.Right;
                }
            }

            BSTNode<T> newNode = new BSTNode<T>(obj);
            if (Comparer<T>.Default.Compare(tmpParent.Data, obj) < 0)
            {
                tmpParent.Right = newNode;
            }
            else
            {
                tmpParent.Left = newNode;
            }
            newNode.Parent = tmpParent;
            return true;
        }

        public bool Erase(T obj)
        {
            BSTNode<T> element = FindHelper(obj);
            if (element == null)
            {
                return false;
            }

            // Case 1: No children
            if (element.Left == null && element.Right == null)
            {
                if (element.Parent != null)
                {
                    if (Comparer<T>.Default.Compare(element.Parent.Data, element.Data) < 0)
                    {
                        element.Parent.Right = null;
                    }
                    else
                    {
                        element.Parent.Left = null;
                    }
                }
                else
                {
                    root = null;
                }
                return true;
            }

            // Case 2: Only left child
            if (element.Left != null && element.Right == null)
            {
                if (element.Parent != null)
                {
                    if (Comparer<T>.Default.Compare(element.Parent.Data, element.Data) < 0)
                    {
                        element.Parent.Right = element.Left;
                    }
                    else
                    {
                        element.Parent.Right = element.Left;
                    }
                }
                else
                {
                    root = element.Left;
                }   
                element.Parent.Right = element.Left;
                return true;
            }

            // Case 3: Only right child
            if (element.Left == null && element.Right != null)
            {
                if (element.Parent != null)
                {
                    if (Comparer<T>.Default.Compare(element.Parent.Data, element.Data) < 0)
                    {
                        element.Parent.Right = element.Left;
                    }
                    else
                    {
                        element.Parent.Right = element.Left;
                    }
                }
                else
                {
                    root = element.Right;
                }
                element.Parent.Right = element.Left;
                return true;
            }

            // Case 4: Both left and right children
            BSTNode<T> nextNode = NextNodeHelper(element.Data);
            if (nextNode.Right == null)
            {
                // nextNode is a leaf
                T tmpData = nextNode.Data;
                if (nextNode.Parent != null)
                {
                    if (Comparer<T>.Default.Compare(nextNode.Parent.Data, nextNode.Data) < 0)
                    {
                        nextNode.Parent.Right = null;
                    }
                    else
                    {
                        nextNode.Parent.Left= null;
                    }
                }
                else
                {
                    root = null;
                }
                element.Data= tmpData;

                return true;
            }
            else
            {
                T tmpData = nextNode.Data;
                if (nextNode.Parent != null)
                {
                    if (Comparer<T>.Default.Compare(nextNode.Parent.Data, nextNode.Data) < 0)
                    {
                        nextNode.Parent.Right = nextNode.Right;
                    }
                    else
                    {
                        nextNode.Parent.Right = nextNode.Right;
                    }
                }
                nextNode.Parent.Right = nextNode.Right;
                element.Data = tmpData;
                return true;
            }
        }

        public bool Find(T obj)
        {
            return FindHelper(obj) != null;
        }

        public T NextNode(T obj)
        {
            BSTNode<T> next = NextNodeHelper(obj);
            if (next != null)
            {
                return next.Data;
            }
            throw new InvalidOperationException("There is no next element");
        }

        private BSTNode<T> FindHelper(T obj)
        {
            if (root == null)
            {
                return null;
            }

            BSTNode<T> tmpNode = root;
            while (tmpNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(tmpNode.Data, obj))
                {
                    return tmpNode;
                }
                if (Comparer<T>.Default.Compare(obj, tmpNode.Data) > 0)
                {
                    tmpNode = tmpNode.Right;
                }
                else
                {
                    tmpNode = tmpNode.Left;
                }
            }
            return null;
        }

        private BSTNode<T> NextNodeHelper(T obj)
        {
            BSTNode<T> objPointer = FindHelper(obj);
            if (objPointer == null)
            {
                return null;
            }

            if (objPointer.Right != null)
            {
                BSTNode<T> tmpNode = objPointer.Right;
                BSTNode<T> tmpParent = null;
                while (tmpNode != null)
                {
                    tmpParent = tmpNode;
                    tmpNode = tmpNode.Left;
                }
                return tmpParent;
            }

            BSTNode<T> tmp = objPointer;
            while (objPointer != null)
            {
                if (objPointer.Parent == null)
                {
                    return null;
                }
                if (Comparer<T>.Default.Compare(objPointer.Data, objPointer.Parent.Data) < 0)

                {
                    return objPointer.Parent;
                }
                objPointer = objPointer.Parent;
            }

            return null;
        }
    }



}
