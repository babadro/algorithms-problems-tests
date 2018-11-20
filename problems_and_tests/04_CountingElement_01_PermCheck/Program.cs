using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CountingElement_01_PermCheck
{
    class Solution
    {
        public int solution(int[] A) // Naive
        {
            Array.Sort(A);
            if (A.First() != 1)
                return 0;
            if (A.Last() - A.First() != A.Length - 1)
                return 0;

            var set = new HashSet<int>(A);
            if (set.Count != A.Length)
                return 0;

            return 1;
        }
    }

    class Solution2 // Good solution
    {
        public int solution(int[] A)
        {
            var newArr = new int[100000];

            foreach (var i in A)
            {
                if (i > 100000)
                    return 0;
                else
                    newArr[i - 1] = 1;
            }

            for (var j = 0; j < A.Length; j++)
                if (newArr[j] == 0)
                    return 0;
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
