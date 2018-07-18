using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_FibonacciNumbers_01_FibFrog
{
    class Program
    {
        public static int solution(int[] A) //Bad solution. Naive. 33% score. Timeout errors + wrong answer errors
        {
            if (A.Length == 0)
                return 1;
            var fib = Fibonacci(31);
            if (fib.Contains(A.Length + 1))
                return 1;

            for (var i = 2; i <= A.Length + 1; i++)
            {
                for (var j = 0; j < A.Length; j++)
                {
                    if (leapSequence(i, A, j, fib, -1))
                        return i;
                }
            }

            return -1;
        }

        public static bool leapSequence(int leapCount, int[] arr, int firstLeaf, int[] fib, int start)
        {
            if (arr[firstLeaf] == 0)
                return false;
            if (leapCount > 2)
                for (var i = firstLeaf + 1; i < arr.Length; i++)
                    if (leapSequence(leapCount - 1, arr, i, fib, firstLeaf))
                        return true;
                
            if (fib.Contains(firstLeaf - start) && fib.Contains(arr.Length - firstLeaf))
                return true;
            return false;
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
            /*
            var fib = Fibonacci(31);
            foreach (var num in fib)
                Console.WriteLine(num);
                */
            var input = new [] {0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0};
            Console.WriteLine(solution(input));
            var input2 = new[] {0, 0, 1, 1, 0, 1};
            Console.WriteLine(solution(input2));
            var input3 = new int[100000];
            Console.WriteLine(solution(input3));
            Console.ReadLine();
        }
    }
}
