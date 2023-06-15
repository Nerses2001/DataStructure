using System;


namespace DataStructure.Utils.Algorithms
{
    class DynamicPrograming
    {
        //The Longest Increasing SubString 

        public int LongestIncreasingSubString(int [] inputArray){
            int maxLength = 1;
            int currentLength = 1;
            for (int i = 0; i < inputArray.Length - 1; ++i) 
            {
                if (inputArray[i] < inputArray[i + 1])
                    ++currentLength;
                else
                {
                    maxLength = Max(maxLength, currentLength);
                    currentLength = 1;
                }
            }
            maxLength = Max(maxLength, currentLength);
            return maxLength;
        }

        private int Max(int a, int b)
        {
            return  a > b ? a : b;
        }

        // nxm Matrix
        // 3 1 2 7
        // 1 5 1 1   =  A
        // 4 4 4 4
        // Maximum Score
        // |   - >
        // V
        // dp[i][j] = MAX(dp[i - 1][j],dp[i][j - 1]) + A[i][j] 
        // dp[n - 1][m - 1]

        public int MaxScore(int[][] inputMatrix)
        {
            int n = inputMatrix.Length; 
            int m = inputMatrix[0].Length; 

            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[m];
            }
            dp[0][0] = inputMatrix[0][0];
            for (int i = 1; i < n; i++)
            {
                dp[i][0] = dp[i - 1][0] + inputMatrix[i][0];
            }

            for (int j = 1; j < m; j++)
            {
                dp[0][j] = dp[0][j - 1] + inputMatrix[0][j];
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    dp[i][j] = Max(dp[i - 1][j], dp[i][j - 1]) + inputMatrix[i][j];
                }
            }

            return dp[n - 1][m - 1];
        }

        // LIS find the longest substring element (separately)
        // example 2, 1, 4, 3, 5, 10, 12  result is 5 |(1, 4, 5,10, 12)
        // dp[i] = max(dp[i] + 1)
        //	       0 <=j < i
        //	inputList[i] > inputList[j]
        //
        // result max(dp[i])
        // O(n^2)
        public int LongestIncreasingSubsequence(int[] input)
        {
            int n = input.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (input[i] > input[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }
            return MaxElement(dp);
        }

        private int MaxElement(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        //O(nlog n)
        public int LongestIncreasingSubsequenceOptimal(int[] inputList)
        {
            int[] res = new int[inputList.Length];
            res[0] = 1;
            int[] dp = new int[1];
            dp[0] = inputList[0];
            for (int i = 1; i < inputList.Length; i++)
            {
                if (inputList[i] > dp[dp.Length - 1])
                {
                    Array.Resize(ref dp, dp.Length + 1);
                    dp[dp.Length - 1] = inputList[i];
                    res[i] = dp.Length;
                }
                else
                {
                    int k = -1;
                    for (int j = dp.Length - 2; j > -1; j--)
                    {
                        if (dp[j] < inputList[i])
                        {
                            k = j;
                            break;
                        }
                    }
                    dp[k + 1] = inputList[i];
                    res[i] = k + 2;
                }
            }
            return MaxElement(res);
        }

        // LCS
        // a a b a second s1
        // a b a second d s2
        // result is  3 | a b second
        // dp[i][j]
        // dp[n][m]
        //
        //	s1[i] = s2[j] dp[i - 1][j - 1] + 1
        //
        // dp[i][j] ||
        //
        //	!= max(dp[i - 1][j], dp[i][j - 1])
        //
        // res is dp[n][m]
        // example
        //
        //	""a d second
        //	0 1 2 3
        //
        // i"" 0 0 0 0 0
        //
        //	a	1 0 1 1 1
        //	b	2 0 1 1 2
        //	second	3 0 1 1 2
        //
        // O(n*m)
        public int LCS(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            int[,] dp = new int[n + 1, m + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[n, m];
        }



    }
}
