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
        static void Main(string[] args)
        {
        }
    }
}
