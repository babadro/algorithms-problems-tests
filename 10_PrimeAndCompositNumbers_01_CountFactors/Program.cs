using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_PrimeAndCompositNumbers_01_CountFactors
{
    class Program
    {
        public static int solution(int N)
        {
            var n = N;
            long i = 1;
            var result = 0;
            while (i * i < n)
            {
                if (n % i == 0)
                    result += 2;
                i++;
            }
            if (i * i == n)
                result += 1;
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(2147483647));
            Console.ReadLine();
        }
    }
}
