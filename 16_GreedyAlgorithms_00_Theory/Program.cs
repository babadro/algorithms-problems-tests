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
            for (var i = n - 1; i > -1; i--)
            {
                var x = M[i];
                var y = k / M[i];
                result.Add(new Tuple<int, int>(M[i], k / M[i]));
                k = k % x;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] M = {1, 2, 5};
            int k = 10;
            var result = GreedyCoinChanging(M, k);
            Console.ReadLine();
        }
    }
}
