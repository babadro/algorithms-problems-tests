using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_FibonacciNumbers_01_FibFrog
{
    class Program
    {
        public static int solution(int[] A)
        {

            return 0;
        }

        public static int[] Fibonacci(int n)
        {
            var fib = new int[n + 1];
            fib[1] = 1;
            for (var i = 2; i < fib.Length; i++)
                fib[i] = fib[i - 1] + fib[i - 2];
            return fib;
        }
        static void Main(string[] args)
        {
            var fib = Fibonacci(31);
            foreach (var num in fib)
                Console.WriteLine(num);
            Console.ReadLine();
        }
    }
}
