using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MaximumSliceProblem_01_MaxDoubleSliceSum
{
    class Solution
    {
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] {1, 2, -30, -1, 5, 6, 7};
            Console.WriteLine(Solution.solution(input));
            Console.ReadLine();
        }
    }
}
