using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Arrays_01_CyclingRotation
{
    class Solution
    {
        public int[] solution(int[] A, int K)
        {
            var res = new int[A.Length];
            for (var i = 0; i < A.Length; i++)
                res[(i + K) % A.Length] = A[i];
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new [] { 3, 8, 9, 7, 6 };
            var K = 3;
            var sol = new Solution();
            var result = sol.solution(input, K);
            foreach (var i in result)
                Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
