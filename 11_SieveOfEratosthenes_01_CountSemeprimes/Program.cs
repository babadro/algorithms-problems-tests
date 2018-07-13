using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_SieveOfEratosthenes_01_CountSemiprimes
{
    class Program
    {
        public static int[] solution(int N, int[] P, int[] Q)
        {
            var result = new int[P.Length];
            var primes = Primes(N);
            var semiPrimesSums = SemiPrimesSums(N, primes);
            for (var i = 0; i < P.Length; i++)
                result[i] = semiPrimesSums[Q[i]] - semiPrimesSums[P[i] - 1];

            return result;
        }

        static int[] SemiPrimesSums(int N, bool[] primes)
        {
            var semiPrimesSums = new int[N + 1];
            for (var i = 1; i < semiPrimesSums.Length; i++)
            {
                if (SemiPrimeCheck(i, primes))
                    semiPrimesSums[i] = semiPrimesSums[i - 1] + 1;
                else
                    semiPrimesSums[i] = semiPrimesSums[i - 1];
            }
            return semiPrimesSums;
        }

        static bool SemiPrimeCheck(int N, bool[] primes)
        {
            if (N < 4)
                return false;

            for (var i = 2; i < primes.Length; i++)
            {
                if (i * i > N)
                    break;
                if (!primes[i])
                    continue;

                if (N % i == 0 && primes[N / i])
                    return true;
            }
            return false;
        }

        static bool[] Primes(int n)
        {
            var sieve = new bool[n + 1];
            for (var j = 2; j < sieve.Length; j++)
                sieve[j] = true;

            var i = 2;
            while (i * i <= n)
            {
                if (sieve[i])
                {
                    var k = i * i;
                    while (k <= n)
                    {
                        sieve[k] = false;
                        k += i;
                    }
                }
                i++;
            }
            return sieve;
        }
        static void Main(string[] args)
        {
            //var primes = Primes(26);/*
            //for (var i = 0; i <= 26; i++)
            //    if (SemiPrimeCheck(i, primes))
            //        Console.WriteLine(i);*/
            //
            //var semiPrimesSums = SemiPrimesSums(26, primes);
            //for (var i = 0; i < semiPrimesSums.Length; i++)
            //    Console.WriteLine(semiPrimesSums[i]);

            var N = 26;
            var P = new [] {1, 4, 16};
            var Q = new[] {26, 10, 20};

            var result = solution(N, P, Q);
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
