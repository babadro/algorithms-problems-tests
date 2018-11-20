using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_PrefixSums_00_Theory
{
    class Program
    {
        public static int[] PrefixSums(int[] A)
        {
            var n = A.Length;
            var P = new int[n + 1];
            for (var k = 1; k < n + 1; k++)
                P[k] = P[k - 1] + A[k - 1];
            return P;
        }
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            var res = PrefixSums(input);
            foreach (var j in res)
                Console.WriteLine(j);
            Console.ReadLine();
        }
    }
}
