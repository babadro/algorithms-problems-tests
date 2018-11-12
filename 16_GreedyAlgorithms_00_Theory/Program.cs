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

        public static int GreedyCanoeistA(int[] w, int k)
        {
            var n = w.Length;
            var skinny = new List<int>();
            var fatso = new List<int>();

            for (var i = 0; i < n; i++)
            {
                if (w[i] + w.Last() <= k)
                    skinny.Append(w[i]);
                else
                    fatso.Append(w[i]);
            }
            fatso.Append(w.Last());
            var canoes = 0;
            while (skinny.Count > 0 || fatso.Count > 0)
            {
                if (skinny.Count > 0)
                    skinny.RemoveAt(skinny.Count - 1);
                fatso.RemoveAt(fatso.Count - 1);
                canoes += 1;
                if (fatso.Count == 0 && skinny.Count != 0)
                {
                    fatso.Append(skinny.Last());
                    skinny.RemoveAt(skinny.Count - 1);
                }
                while (fatso.Count > 1 && fatso.Last() + fatso[0] <= k)
                {
                    skinny.Append(fatso[0]);
                    fatso.RemoveAt(0);
                }
            }
            return canoes;
        }

        public static int GreedyCanoeistB(int[] w, int k)
        {
            var canoes = 0;
            var j = 0;
            var i = w.Length - 1;
            while (i >= j)
            {
                if (w[i])
            }
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
