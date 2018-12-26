using System;

namespace _17_DynamicProgramming_00_Theory
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DynamicCoinChanging(new int[] { 1, 3, 4 }, 6);
            foreach (var i in result)
                Console.WriteLine(i);
        }

        public static int[] DynamicCoinChanging(int[] denominations, int amount)
        {
            var outerLen = denominations.Length + 1;
            var innerLen = amount + 1;
            var dp = new int[outerLen][];
            for (var i = 0; i < outerLen; i++) // Filling array with all zeroes
            {
                dp[i] = new int[innerLen];
                for (var j = 0; j < innerLen; j++)
                    dp[i][j] = 0;
            }
                
            for (var i = 1; i < innerLen; i++) // Filling the first inner array with int.MaxValue exept first element (which is still equal zero)
                dp[0][i] = int.MaxValue;

            for (var i = 1; i < outerLen; i++)
            {
                for (var j = 0; j < denominations[i - 1]; j++)
                    dp[i][j] = dp[i - 1][j];
                for (var j = denominations[i - 1]; j < innerLen; j++)
                    dp[i][j] = Math.Min(dp[i][j - denominations[i - 1]] + 1, dp[i - 1][j]);
            }
            return dp[denominations.Length];
        }
    }
}
