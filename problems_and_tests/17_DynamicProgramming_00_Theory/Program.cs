using System;

namespace _17_DynamicProgramming_00_Theory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int[] DynamicCoinChanging(int[] C, int k)
        {
            var outerLen = C.Length + 1;
            var innerLen = k + 1;
            var dp = new int[outerLen][];
            for (var i = 0; i < outerLen; i++) // Filling array with all zeroes
                for (var j = 0; j < innerLen; j++)
                    dp[i][j] = 0;
            for (var i = 1; i < innerLen; i++) // Filling the first inner array with int.MaxValue exept first element (which is still equal zero)
                dp[0][i] = int.MaxValue;

            for (var i = 1; i < outerLen; i++)
            {
                for (var j = 0; j < C[i - 1]; j++)
                    dp[i][j] = dp[i - 1][j];
                for (var j = C[i - 1]; j < innerLen; j++)
                    dp[i][j] = Math.Min(dp[i][j - C[i - 1]] + 1, dp[i - 1][j]);
            }
            return dp[C.Length];
        }
    }
}
