using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_SieveOfEratosthenes_01_CountSemiprimes
{
    class Program
    {
        public int[] solution(int N, int[] P, int[] Q)
        {
            
            return null;
        }

        static int[] SemiPrimesSum(int N)
        {
            var semiPrimesSum = new int[N + 1];
            return null;
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
                
                if (N)
            }
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
            
        }
    }
}
