using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_PrefixSums_01_PassingCars
{
    class Solution {
        public int solution(int[] A)
        {
            var zeroesCount = 0;
            var res = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                    zeroesCount++;
                else
                    res = res + zeroesCount;
                if (res > 1000000000)
                    return -1;
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 0, 1, 0, 1, 1 };
            var sol = new Solution();
            Console.WriteLine(sol.solution(input));
            Console.ReadLine();
        }
    }
}
