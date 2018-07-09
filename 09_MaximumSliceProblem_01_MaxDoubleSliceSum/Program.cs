using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MaximumSliceProblem_01_MaxDoubleSliceSum
{
    class Solution
    {
        #region bad
        public static int solution(int[] A)
        {
            if (A.Length <= 3)
                return 0;

            var maxResLeft = 0;
            var maxResIdxLeft = 1;
            var prefixSums = PrefixSums(A);
            var maxRightValue = prefixSums[prefixSums.Length - 2];
            for (var i = 1; i < prefixSums.Length - 3; i++)
            {
                var res = maxRightValue - prefixSums[i];
                if (res > maxResLeft)
                {
                    maxResLeft = res;
                    maxResIdxLeft = i;
                }
            }
            var idxLeft = maxResIdxLeft - 1;

            // Make revertA
            var revertA = new int[A.Length];
            A.CopyTo(revertA, 0);
            Array.Reverse(revertA);
            // End make revertA



            return 0;
        }

        public static int[] PrefixSums(int[] A)
        {
            var n = A.Length;
            var P = new int[n + 1];
            for (var k = 1; k < n + 1; k++)
                P[k] = P[k - 1] + A[k - 1];
            return P;
        }

        #endregion

        public static int solution2(int[] A)
        {
            if (A.Length <= 3)
                return 0;


            var maxEnding = 0;
            var maxSlice = 0;
            var minValue = A[1];
            var separatorExists = false;
            var rightHalfSum = 0;
            var endIdx = -1;
            var minValueIdx = -1;

            for (var i = 1; i < A.Length - 1; i++)
            {
                //maxEnding = Math.Max(0, maxEnding + A[i]);
                if (maxEnding + A[i] <= 0)
                {
                    if (!separatorExists)
                    {
                        separatorExists = true;
                    }
                    else
                    {
                        maxEnding = rightHalfSum;
                        rightHalfSum = 0;
                    }

                }
                else
                {
                    if (A[i] < minValue)
                    {
                        minValue = A[i];
                        minValueIdx = i;
                    }
                    //minValue = Math.Min(minValue, A[i]);
                    maxEnding += A[i];
                    if (separatorExists)
                        rightHalfSum += A[i];
                }
                    
                if (maxEnding > maxSlice)
                {
                    maxSlice = maxEnding;
                    endIdx = i;
                    
                }
                //maxSlice = Math.Max(maxSlice, maxEnding);
            }
            if (!separatorExists && (endIdx == A.Length - 2 || minValue < 0) && minValueIdx < endIdx)
            {
                maxSlice = maxSlice - minValue;
            }
                
            return maxSlice;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] {1, 2, -30, -1, 5, 6, 7};
            var input2 = new[] {3, 1, 1, -2, 2, 1, -5, 2, 1, 1, -8, -5, 1, 2};
            var input3 = new[] {1, 2, 3, 4, 5, 6 };
            var input4 = new[] {0, 10, -5, -2, 0};
            var input5 = new[] {3, 2, 6, -1, 4, 5, -1, 2};
            //Console.WriteLine(Solution.solution2(input2));
            Console.WriteLine(Solution.solution2(input4));
            Console.WriteLine(Solution.solution2(input5));
            Console.ReadLine();
        }
    }
}
