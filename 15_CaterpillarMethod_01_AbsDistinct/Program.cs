using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CaterpillarMethod_01_AbsDistinct
{
    class Program
    {
        public int solution(int[] A)
        {
            var n = A.Length;
            if (n == 0)
                return 0;
            if (n == 1)
                return
            for (var i = 0; i < A.Length; i++)
                A[i] = Math.Abs(A[i]);
            Array.Sort(A);

            
            var total = 0;
            var front = 1;
            for (var back = 0; back < n; back++)
            {
                total += 1;
                while (front < n && A[front] == A[front - 1])
                {
                    total
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
