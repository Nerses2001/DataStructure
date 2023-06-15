using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Utils;
using DataStructure.Utils.Algorithms;
using DataStructure.Utils.DataStructore;
using DataStructure.Utils.DataStructures;


namespace DataStructure
{
     class Program
    {
        static void Main()
        {
            Console.WriteLine("****************************** Linked List ******************************");
            LinkedListImpl<int> myFirstList = new LinkedListImpl<int>();
            
            myFirstList.Add(10);
            myFirstList.Add(20);
            myFirstList.Add(30);

            List<int> collection = new List<int> {5,88,22,33};
            myFirstList.AddAll(collection);

            Console.Write("My Linked List<int> is ");
            myFirstList.Print();

            myFirstList.ChangeValue(0, 1000);
            Console.Write("My Linked List<int> chnageing ");
            myFirstList.Print();

            myFirstList.DeleteAtIndex(3);
            Console.Write("My Linked List<int> delet ");
            myFirstList.Print();


            myFirstList.Delete(33);
            Console.Write("My Linked List<int> delet element ");
            myFirstList.Print();

            myFirstList.Reverse();
            Console.Write("My Linked List<int> reverse ");
            myFirstList.Print();

            Console.WriteLine();

            Console.WriteLine("****************************** Array List ******************************");
            ArrayListImpl<int> myArrayList = new ArrayListImpl<int>();
            
            myArrayList.Add(10);
            myArrayList.Add(20);
            myArrayList.Add(30);
            myArrayList.Add(50);
             

            Console.Write("My ArryList is ");
            myArrayList.Print();

            int secondElemend = myArrayList.GetElement(1);
            Console.Write("Element of 1 index ");
            Console.WriteLine(secondElemend);

            int lengtArryList = myArrayList.Count();
            Console.Write("Length is ");
            Console.WriteLine(lengtArryList);

            int fIrstArryList = myArrayList.FirstElement();
            Console.Write("First Element is ");
            Console.WriteLine(fIrstArryList);

            int lastArryList = myArrayList.LastElement();
            Console.Write("Last Element is ");
            Console.WriteLine(lastArryList);


            int[] subArray = myArrayList.SubArrayList(0,3);
            Console.Write("Last Element is ");

            Console.WriteLine("Elements in the sub-array:");
            foreach (int element in subArray)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();

            Console.WriteLine("****************************** HashSet ******************************");
            HashSetImpl<int> myHashSet = new HashSetImpl<int>();

            // Add elements to the set
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);

            Console.Write("My HashSet is ");
            myHashSet.Print();  

            ;
            Console.Write("My HashSet Lnegth " + myHashSet.Count());

            Console.WriteLine("****************************** HashMap ******************************");
            HashMapImp<string, int> myDictionary = new HashMapImp<string, int>();

            myDictionary.Add("One", 1);
            myDictionary.Add("Two", 2);
            myDictionary.Add("Three", 3);

            Console.WriteLine(myDictionary.ContainsKey("Two")); 
            Console.WriteLine(myDictionary.ContainsKey("Four"));

            bool removed = myDictionary.Remove("Two");
            Console.WriteLine($"Key 'Two' removed: {removed}"); 

            int value;
            bool found = myDictionary.TryGetValue("Three", out value);
            if (found)
            {
                Console.WriteLine($"Value for key 'Three': {value}"); 
            }
            else
            {
                Console.WriteLine("Key not found.");
            }

            myDictionary.Print();


            Console.WriteLine("****************************** HashSet Optimal ******************************");

            HashSetOptimalImp<string> myHashSetOpt = new HashSetOptimalImp<string>();

            myHashSetOpt.Add("Apple");
            myHashSetOpt.Add("Banana");
            myHashSetOpt.Add("Orange");
            myHashSetOpt.Add("Apple");
            myHashSetOpt.Add("Banana");
            myHashSetOpt.Add("Orange");
            myHashSetOpt.Print();
            Console.WriteLine(myHashSetOpt.Contains("Apple"));
            Console.WriteLine(myHashSetOpt.Contains("Grape"));

            bool removedSet = myHashSetOpt.Remove("Banana");
            Console.WriteLine($"Item 'Banana' removed: {removedSet}");

            myHashSetOpt.Clear();

            int count = myHashSetOpt.Count;
            Console.WriteLine($"Number of items in the set: {count}");

            myHashSetOpt.Add("Mango");
            myHashSetOpt.Add("Pineapple");

            myHashSetOpt.Print();


            Console.WriteLine("****************************** Stack ******************************");
            StackImp<int> myStack = new StackImp<int>(5);

            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Print();

            Console.WriteLine("Size: " + myStack.Size());  

            Console.WriteLine(myStack.Pop());  
            Console.WriteLine(myStack.Pop());  

            Console.WriteLine("Is Empty: " + myStack.IsEmpty());  

            Console.WriteLine(myStack.Peek());  

            Console.WriteLine("Size: " + myStack.Size());

            Console.WriteLine("****************************** Queue ******************************");
            QueueImp<int> myQueue = new QueueImp<int>(5);

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);

            Console.WriteLine("Size of the queue: " + myQueue.Size());
            Console.WriteLine("Front item: " + myQueue.Peek());

            while (!myQueue.IsEmpty())
            {
                Console.WriteLine("Dequeued item: " + myQueue.Dequeue());
            }

            Console.WriteLine("Is the queue empty? " + myQueue.IsEmpty());


            Console.WriteLine("****************************** Bynery Tree ******************************");

            BinaryTree<int> tree = new BinaryTree<int>();

            tree.AddNode(4);
            tree.AddNode(2);
            tree.AddNode(6);
            tree.AddNode(1);
            tree.AddNode(3);
            tree.AddNode(5);

            Console.Write("\nInorder traversal of binary tree is: ");
            tree.InorderTraversal();

            Console.Write("\nDeleting node 2 from the binary tree... ");
            tree.DeleteNode(2);

            Console.Write("\nInorder traversal after deletion is: ");
            tree.InorderTraversal();


            // Create BST
            BST<int> bst = new BST<int>();
            bst.Insert(1);
            bst.Insert(2);
            bst.Insert(3);
            bst.Insert(-1);
            bst.Insert(0);

            bst.PrintBFS();

            Console.WriteLine("Min element = " + bst.Min());
            Console.WriteLine("Max element = " + bst.Max());
            int number = 3;
            if (bst.Find(number))
            {
                Console.WriteLine(number + " is in the tree");
            }
            else
            {
                Console.WriteLine(number + " is not in the tree");
            }

            try
            {
                Console.WriteLine(bst.NextNode(0));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            bst.Erase(1);
            bst.PrintBFS();

            
            Console.WriteLine("****************************** Red Black Tree ******************************");
            RedBlackTree rbTree= new RedBlackTree();
            rbTree.Insert(5);
            rbTree.Insert(3);
            rbTree.Insert(7);
            rbTree.Insert(1);
            rbTree.Insert(9);
            rbTree.Insert(-1);
            rbTree.Insert(11);
            rbTree.Insert(6);
            rbTree.DisplayTree();

            Console.WriteLine("****************************** Recursion ******************************");
            Recursion recursion = new Recursion();
            
            int fib15 = recursion.Fib(15);
            Console.WriteLine("FIb 15 number is " + fib15);
            
            int fib10 = recursion.FibOptimal(10);
            Console.WriteLine("FIb 10 number is " + fib10);

            Console.WriteLine("10 and 5 GCD is " + recursion.Gcd(5,10));
            Console.WriteLine("10 and 5 Hsf is " + recursion.Hcf(5, 10));
            Console.WriteLine("10 and 5 Lcm is " + recursion.Icm(5, 10));
            Console.WriteLine("10 and 5 ByneryGCD is " + recursion.BinaryGCD(5, 10));

            Console.WriteLine("****************************** Algoritms ******************************");
            Algorithms algorithms = new Algorithms();
            List<int> primNumber = algorithms.GetPrimeNumbers(10);
            primNumber.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
            List<int> primNumberOptimalResualt = algorithms.GetPrimeNumbers(10);
            primNumberOptimalResualt.ForEach(n => Console.Write(n + " "));

            Console.WriteLine("****************************** Sorting Algoritms ******************************");
            int[] arrayBubleSort = {1,5,2,8,5,6,6,6,0,9,-5,8,22,8888,2,4,2,};
            SortingAlgorithms sorting = new SortingAlgorithms();
            sorting.BubllSort(ref arrayBubleSort);
            for(int i = 0; i < arrayBubleSort.Length; ++i)
            {
                Console.Write(arrayBubleSort[i] + " ");
            }

            Console.WriteLine();
            int[] arrayMergeSort = {5,8,6,8,2,8,2,2,0,-1,0,-1,1,-1,1,0,1,10,5,5,-22,9,2,4,5};
            sorting.MergeSort(ref arrayMergeSort);

            Console.Write("Merge Sort working ");
            for (int i = 0;i < arrayMergeSort.Length; ++i)
            {
                Console.Write(arrayMergeSort[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
