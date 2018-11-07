using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GreedyAlgorithms_00_Theory
{
    class Program
    {
        public static List<Tuple<int, int>> GreedyCoinChanging(int[] M, int k)
        {
            var n = M.Length;
            var result = new List<Tuple<int, int>>();
            for (var i = n - 1; n > -1; n--)
            {
                result.Add(new Tuple<int, int>(M[i], k / M[i]));
                k %= M[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] M = {1, 2, 5};
            int k = 6;
            var result = GreedyCoinChanging(M, k);
            Console.ReadLine();
        }
    }
}
