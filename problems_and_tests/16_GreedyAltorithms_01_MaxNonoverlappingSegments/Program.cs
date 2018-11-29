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

        //ToDo
        static public int solution(int[] A, int[] B)
        {
            return 0;
        }
    }
}
