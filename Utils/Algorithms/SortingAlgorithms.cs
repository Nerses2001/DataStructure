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

    }
}
