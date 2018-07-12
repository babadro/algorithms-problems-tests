using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_SieveOfEratosthenes_00_Theory
{
    class Program
    {
        static bool[] solution(int n)
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
            var primes = solution(30);
            for (var i = 0; i < primes.Length; i++)
                Console.WriteLine($"{i} is prime: {primes[i]}");
            Console.ReadLine();
        }
    }
}
