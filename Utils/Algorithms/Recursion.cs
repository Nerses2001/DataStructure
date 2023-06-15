using System;
using System.Collections.Generic;


namespace DataStructure.Utils.Algorithms
{
    class Recursion
    {

        // O(2^n)
       public int Fib(uint n )
        { 

            if ( n == 1 || n == 0) 
                return 1;

        return Fib(n - 2) + Fib(n - 1);
        }


        // O(n)
        public int FibOptimal(uint n)
        {
            int[] fb = new int[n + 1];
            if (n == 1 || n == 0) 
            {
                fb[n] = 1;
                return fb[n];
            }

            if(fb[n] != 0)
            {
                return fb[n];
            }
            fb[n] = FibOptimal(n - 1) + FibOptimal(n - 2);
            return fb[n];
        }


        // O(log(min(A, B)) = O(log n)
        public int Gcd(int a , int b)
        {
            if (a == b)
                return a;
            else if(a > b)
                return Gcd(a - b, b);
            else return Gcd(a, b - a);
        }

        public int Hcf(int a, int b)
        {
            if (b != 0)
                return Hcf(b,a % b);
            else return a;
        }

        public int Icm(int a, int b)
        {
            return a / Hcf(a, b) * b;
        }

        //O((logN)^2)
        public int BinaryGCD(int a, int b)
        {
            if (b == 0) return a;
            if (a == 0) return b;

            if ((a & 1) == 0 && (b & 1) == 0)
                return BinaryGCD(a >> 1, b >> 1) << 1;

            else if ((a & 1) == 0)
                return BinaryGCD(a >> 1, b);

            else if ((b & 1) == 0)
                return BinaryGCD(a, b >> 1);

            else if (a >= b)
                return BinaryGCD((a - b) >> 1, b);

            else
                return BinaryGCD(a, (b - a) >> 1);
        }

    }
}
