using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Utils;


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
            Console.WriteLine(myStack.Peek());

            Console.WriteLine("Size: " + myStack.Size());  

            Console.WriteLine(myStack.Pop());  
            Console.WriteLine(myStack.Pop());  

            Console.WriteLine("Is Empty: " + myStack.IsEmpty());  

            Console.WriteLine(myStack.Peek());  

            Console.WriteLine("Size: " + myStack.Size());
            Console.ReadLine();
        }
    }
}
