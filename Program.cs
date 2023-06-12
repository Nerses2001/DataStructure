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
            Console.ReadLine();

            
        }
    }
}
