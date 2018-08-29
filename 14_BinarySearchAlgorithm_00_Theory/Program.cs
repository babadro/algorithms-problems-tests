using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_BinarySearchAlgorithm_00_Theory
{
    class Program
    {
        public static int BinarySearch(int[] A, int x)
        {
            var n = A.Length;
            var beg = 0;
            var end = n - 1;
            var result = -1;
            while (beg <= end)
            {
                var mid = (beg + end) / 2;
                if (A[mid] <= x)
                {
                    beg = mid + 1;
                    result = mid;
                }
                else
                    end = mid - 1;
            }

            return result;
        }
        static void Main(string[] args)
        {
            var result = BinarySearch(new[] { 1, 2, 3, 4, 6 }, 5);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
