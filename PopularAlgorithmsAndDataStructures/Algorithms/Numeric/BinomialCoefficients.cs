using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Numeric
{
    public static class BinomialCoefficients
    {
        public static int CalcRecursive(int n, int k)
        {
            if (k == 0 || k == n)
                return 1;

            return CalcRecursive(n - 1, k - 1) + CalcRecursive(n - 1, k);
        }

        //Time Complexity: O(n*k)
        //Auxiliary Space: O(n*k)
        public static int CalcDynamic(int n, int k)
        {
            int[,] C = new int[n + 1, k + 1];
            int i, j;

            for (i = 0; i <= n; i++)
            {
                for (j = 0; j <= Math.Min(i, k); j++)
                {
                    if (j == 0 || j == i)
                        C[i, j] = 1;
                    else
                        C[i, j] = C[i - 1, j - 1] + C[i - 1, j];
                }
            }

            return C[n, k];
        }
    }
}
