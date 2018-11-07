using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CaterpillarMethod_01_AbsDistinct
{
    class Program
    {
        // 100 % Score. Good solution
        public static int solution(int[] A)
        {
            long[] a = A.Select(item => (long) item).ToArray();
            var n = a.Length;
            
            for (var i = 0; i < n; i++)
                a[i] = Math.Abs(a[i]);
            Array.Sort(a);
            
            var result = 0;
            var front = 0;
            var back = 0;
            while (back < n)
            {
                result += 1;
                while (front < n - 1 && a[front] == a[front + 1])
                    front += 1;
                back = front + 1;
                front = back;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] input = {-5, -3, -1, 0, 3, 6};
            Console.WriteLine(solution(input));
            Console.ReadLine();
        }
    }
}
