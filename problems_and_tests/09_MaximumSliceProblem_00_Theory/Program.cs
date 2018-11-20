using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MaximumSliceProblem_00_Theory
{
    class Program
    {
        static int SlowMaxSlice(int[] A) // O(N^3)
        {
            var n = A.Length;
            var result = 0;
            for (var p = 0; p < n; p++)
            {
                for (var q = p; q < n; q++)
                {
                    var sum = 0;
                    for (var i = p; i < q + 1; i++)
                        sum += A[i];
                    result = Math.Max(result, sum);
                }
            }
            
            return result;
        }

        static int QuadraticMaxSlice(int[] A, int[] pref) // O(N^2)
        {
            var n = A.Length;
            var result = 0;
            for (var p = 0; p < n; p++)
            {
                for (var q = p; q < n; q++)
                {
                    var sum = pref[q + 1] - pref[p];
                    result = Math.Max(result, sum);
                }
            }
            return result;
        }

        static int QuadraticMaxSlice(int[] A) // O(N^2)
        {
            var n = A.Length;
            var result = 0;
            for (var p = 0; p < n; p++)
            {
                var sum = 0;
                for (var q = p; q < n; q++)
                {
                    sum += A[q];
                    result = Math.Max(result, sum);
                }
            }
            return result;
        }

        static int GoldenMaxSlice(int[] A)
        {
            var maxEnding = 0;
            var maxSlice = 0;

            foreach (var i in A)
            {
                maxEnding = Math.Max(0, maxEnding + i);
                maxSlice = Math.Max(maxSlice, maxEnding);
                Console.WriteLine($"MaxEnding: {maxEnding}");
                Console.WriteLine($"MaxSlice: {maxSlice}");
            }
            return maxSlice;
        }

        static int[] PrefixSum(int[] A)
        {
            var n = A.Length;
            var P = new int[n + 1];
            for (var k = 1; k < n + 1; k++)
                P[k] = P[k - 1] + A[k - 1];
            return P;
        }
        static void Main(string[] args)
        {
            var input1 = new int[] {5, -7, 3, 5, -2, 4, -1};
            var input2 = new int[] { -5, -7, -3, -5, -2, -4, -1 };
            Console.WriteLine(SlowMaxSlice(input1));
            Console.WriteLine(QuadraticMaxSlice(input1, PrefixSum(input1)));
            Console.WriteLine(GoldenMaxSlice(input1));
            Console.ReadLine();
        }
    }
}
