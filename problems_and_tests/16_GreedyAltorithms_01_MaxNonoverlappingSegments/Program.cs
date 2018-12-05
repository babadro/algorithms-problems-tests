using System;

namespace _16_GreedyAltorithms_01_MaxNonoverlappingSegments
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {1, 3, 7, 9, 9};
            int[] B = {5, 6, 8, 9, 10};

            var naiveResult = Solution.Solution1(A, B);

            Console.WriteLine(naiveResult);

            int[] A1 = {0, 1, 2, 3, 4, 5};
            int[] B1 = {2, 3, 4, 5, 6, 7};
            var naiveResult1 = Solution.Solution1(A1, B1);
            Console.WriteLine(naiveResult1);

            int[] A2 = {0, 3, 6, 9, 12, 15, 18};
            int[] B2 = {4, 7, 10, 13, 16, 19, 22};
            var naiveResult2 = Solution.Solution1(A2, B2);
            Console.WriteLine(naiveResult2);

            var result2 = Solution.Solution2(A2, B2);
            Console.WriteLine(result2);

            Console.WriteLine(Solution.Solution2(A, B));

            Console.ReadLine();
        }
    }

    static class Solution
    {
        // 50% score/
        static public int Solution1(int[] A, int[] B)
        {
            var totalCount = A.Length;
            if (totalCount == 0)
                return 0;
            if (totalCount == 1)
                return 1;

            var result = 1;
            for (var i = 1; i < totalCount; i++)
            {
                if (A[i] <= B[i-1])
                    continue;
                result += 1;
            }
            return result;
        }

        // Good solution. 100 % score.
        static public int Solution2(int[] A, int[] B)
        {
            var totalCount = A.Length;
            if (totalCount == 0)
                return 0;
            if (totalCount == 1)
                return 1;

            var result = 1;
            var j = 0;
            for (var i = 1; i < totalCount; i++)
            {
                if (A[i] <= B[j])
                    continue;

                result += 1;
                j = i;
            }
            return result;
        }
    }
}
