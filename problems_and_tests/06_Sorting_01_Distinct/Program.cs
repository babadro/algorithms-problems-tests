using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Sorting_01_Distinct
{
    class Solution { // Naive. Low performance
        public static int solution(int[] A)
        {
            var newArr = new int?[A.Length];
            var res = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if (!newArr.Contains(A[i]))
                {
                    res++;
                    newArr[i] = A[i];
                }
            }
            return res;
        } 
    }

    class Solution2 // Good solution
    {
        public static int solution(int[] A)
        {
            Array.Sort(A);
            var res =  A.Length > 0 ? 1 : 0;
            for (var i = 1; i < A.Length; i++)
                if (A[i] != A[i - 1])
                    res++;
            
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] {0, 1, 2, 1, 0, 0};
            Console.WriteLine(Solution2.solution(input));
            Console.ReadLine();
        }
    }
}
