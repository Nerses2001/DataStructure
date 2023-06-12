using System;
using DataStructure.Utils;
namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListImpl<int> myFirstList = new LinkedListImpl<int>();
            myFirstList.Add(10);
            myFirstList.Add(20);
            myFirstList.Add(30);
            myFirstList.Print();
            myFirstList.Delete(20);
            myFirstList.Print();
            myFirstList.ChangeValue(0,200);
            myFirstList.Print();
            myFirstList.DeleteAtIndex(0);
            myFirstList.Print();


            LinkedListImpl<String> myList = new LinkedListImpl<String>();
            myList.Add("10");
            myList.Add("20");
            myList.Add("30");
            myList.Reverse();
            myList.Print();
            myList.Delete("20");
            myList.Print();
            myList.ChangeValue(0, "200");
            myList.Print();
            myList.DeleteAtIndex(0);
            myList.Print();
            Console.ReadLine();
        }
    }
}
