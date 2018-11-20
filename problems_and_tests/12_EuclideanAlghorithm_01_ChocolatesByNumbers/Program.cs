using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_EuclideanAlghorithm_01_ChocolatesByNumbers
{
    class Program
    {
        public static int solution(int N, int M) // Good solution
        {
            return N / GreatestCommonDivisor(N, M);
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            if (b > a)
                return GreatestCommonDivisor(b, a);
            if (a % b == 0)
                return b;
            return GreatestCommonDivisor(b, a % b);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(solution(1520, 120));
            Console.ReadLine();
        }
    }
}
