using System;
using System.Collections.Generic;


namespace DataStructure.Utils.Algorithms
{
    class SortingAlgorithms
    {
        //O(n^2)
        public void BubllSort(ref int[] inputArray) 
        {
            for (int i = 0; i < inputArray.Length; ++i)
            {
                bool isSorted = true;
                for (int j = 0; j < inputArray.Length - 1; ++j)
                {
                    if (inputArray[j] > inputArray[j + 1]) {

                        (inputArray[j + 1], inputArray[j]) = (inputArray[j], inputArray[j + 1]);
                        isSorted = false;
                    } 
                }
                if (isSorted)
                {
                    break;
                }
            }
            Console.Write("Buble Sort working ");
        }


        // O(log n! = n*log n)
        public void MergeSort(ref int[] inputArray)
        {
            if (inputArray.Length <= 1)
            {
                
                return;
            }

            int mid = inputArray.Length / 2;
            int[] leftArray = new int[mid];
            Array.Copy(inputArray, leftArray, mid);

            int[] rightArray = new int[inputArray.Length - mid];
            Array.Copy(inputArray, mid, rightArray, 0, inputArray.Length - mid);

            MergeSort(ref leftArray);
            MergeSort(ref rightArray);
            Merge(ref inputArray, ref leftArray, ref rightArray);
        
        }

        private void Merge(ref int[] mergedArray, ref int[] leftArray, ref int[] rightArray)
        {
            int[] result = new int[mergedArray.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftArray.Length && j < rightArray.Length)
            {
                if (leftArray[i] < rightArray[j])
                {
                    result[k++] = leftArray[i++];
                }
                else
                {
                    result[k++] = rightArray[j++];
                }
            }

            while (i < leftArray.Length)
            {
                result[k++] = leftArray[i++];
            }

            while (j < rightArray.Length)
            {
                result[k++] = rightArray[j++];
            }

            mergedArray = result;
        }
        // CountingSort O(n + k) k = maxElement - minElement | don't work in double or string only working integers
        public void CountingSort(ref int[] inputArray) 
        { 
            if(inputArray.Length <= 1)
            {
                return;
            }

            int max = FindMaxElement(inputArray);
            int min = FindMinElement(inputArray);
            int[] counts = new int[max - min + 1];
            int[] res = new int[inputArray.Length];

            for(int i = 0; i < inputArray.Length; ++i)
            {
                ++counts[inputArray[i] - min];
            }
            int k = 0;
            for(int i = 0; i < counts.Length; ++i)
            {
                while (counts[i] != 0)
                {
                    res[k++] = i + min;
                    --counts[i];
                }
            }
            inputArray = res;
            Console.Write("Counting Sort working ");
        }


        private int FindMaxElement(int[] inputArray)
        {
            int max = inputArray[0];
            for(int i = 1; i < inputArray.Length; ++i)
            {
                if(inputArray[i] > max )
                    max = inputArray[i];
            }
            return max;
        }
        private int FindMinElement(int[] inputArray)
        {
            int min = inputArray[0];
            for (int i = 1; i < inputArray.Length; ++i)
            {
                if (inputArray[i] < min)
                    min = inputArray[i];
            }
            return min;
        }


        //O(n log n)
        //worst case, QuickSort's time complexity can be O(n^2),
        public void QuickSort(ref int[] inpputArray)
        {
            QuickSortImp(ref inpputArray,0, inpputArray.Length);
        }
        private void QuickSortImp(ref int[] inpputArray, int left, int right)
        {
            if(right - left <= 0)
                return;

            int pi = Partition(inpputArray,left,right);
            QuickSortImp(ref inpputArray, left, pi);
            QuickSortImp(ref inpputArray, pi + 1, right);
        }
        private int Partition(int[] inputArray, int left, int right)
        {
            int pivot = inputArray[right - 1];
            int pivotIndex = left;

            for(int i = left; i < right - 1; ++i)
            {
                if(pivot > inputArray[i])
                {
                    (inputArray[pivotIndex], inputArray[i]) = (inputArray[i], inputArray[pivotIndex]);
                    ++pivotIndex;
                }
            }
            (inputArray[pivotIndex], inputArray[right - 1]) = (inputArray[right - 1], inputArray[pivotIndex]);

            return pivotIndex;
        }
    }
}
