using System;
using System.Collections.Generic;

namespace DataStructure.Utils.Algorithms
{
    class Algorithms
    {
        // O(n * sqrt(n))
        public List<int> GetPrimeNumbers(int n)
        {
            List<int> result = new List<int>();
            if(n == 1)
            {
                return result;

            }
            if (n == 2)
            {
                result.Add(2);
                return result;

            }

            for(int i = 2; i <= n; ++i)
            {
                bool isPrime = true;
                for(int j = 2; j * j <= i; ++j) 
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime)
                {
                    result.Add(i);
                }
            
            }
            Console.Write("Prim Numbers is ");
            return result;
        }

        //O(n * log(log n))
        public List<int> GetPrimNumbersOptimal(int n)
        {
            bool[] isPrime = new bool[n + 1];
            isPrime[0] = true;
            isPrime[1] = true;
            for(int i = 2;i < n; ++i)
            {
                if (isPrime[i] == false)
                {
                    for(int j = i*i; j < isPrime.Length; j += i)
                    {
                        isPrime[j] = true;
                    }
                }
            }
            List<int> result = new List<int>(); 
            for(int i = 0; i < isPrime.Length; ++i)
            {
                if (isPrime[i] == false)
                    result.Add(i);
               
            }
            Console.Write("Prime Numbers is ");
            return result;
        }
    

    }
}
