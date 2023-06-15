using System;


namespace DataStructure.Utils.Algorithms
{
    class SearchingAlgorithms
    {
        //O(log n)
        public (bool, int) BinarySearch(int[] inputSortedList, int targetElement)
        {
            return BinarySearchImp(inputSortedList, 0, inputSortedList.Length - 1, targetElement);
        }

        private (bool, int) BinarySearchImp(int[] inputList, int left, int right, int targetElement)
        {
            if (left > right)
            {
                return (false, -1);
            }

            int mid = left + (right - left) / 2;

            if (targetElement == inputList[mid])
            {
                return (true, mid);
            }
            else if (targetElement < inputList[mid])
            {
                return BinarySearchImp(inputList, left, mid - 1, targetElement);
            }
            else
            {
                return BinarySearchImp(inputList, mid + 1, right, targetElement);
            }
        }

        //O(log n)
        public (bool, int) BinarySearchIterative(int[] inputSortedList, int lookingFor)
        {
            int l = 0;
            int r = inputSortedList.Length - 1;

            int mid;
            int midValue;
            while (l <= r)
            {
                mid = l + (r - l) / 2;
                midValue = inputSortedList[mid];
                if (midValue == lookingFor)
                {
                    return (true, mid);
                }
                else if (midValue > lookingFor)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return (false, -1);
        }
    }
}
