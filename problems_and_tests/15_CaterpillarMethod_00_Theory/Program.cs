using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CaterpillarMethod_00_Theory
{
    class Program
    {
        bool CaterpillarMethod(int[] a, int s)
        {
            var n = a.Length;
            var total = 0;
            var front = 0;
            for (var back = 0; back < n; back++)
            {
                while (front < n && total + a[front] <= s)
                {
                    total += a[front];
                    front += 1;
                }
                if (total == s)
                    return true;
                total -= a[back];
            }
            return false;
        }

        
        static int Triangles(int[] a)
        {
            var n = a.Length;
            Array.Sort(a); // a must be a sorted in non-decreasing order array. 1 <= a0 <= a1 <= ... <= an-1 <= 10^9
            var result = 0;
            for (var x = 0; x < n; x++)
            {
                var z = x + 2;
                for (var y = x + 1; y < n; y++)
                {
                    while (z < n && a[x] + a[y] > a[z])
                        z += 1;
                    result += z - y - 1;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            var input = new int[] {2, 2, 1, 1, 1};
            Console.WriteLine(Triangles(input));
            Console.ReadLine();
        }
    }
}
