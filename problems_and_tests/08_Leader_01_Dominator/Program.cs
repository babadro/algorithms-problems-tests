using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Leader_01_Dominator
{
    class Solution // Naive, but score is 100%.
    {
        public static int solution(int[] A)
        {
            if (A.Length == 0)
                return -1;

            var newArr = new int[A.Length];
            A.CopyTo(newArr, 0);
            Array.Sort(newArr);
            var counter = 1;
            var max = 1;
            var dominator = newArr.First();
            for (var i = 1; i < newArr.Length; i++)
            {
                if (newArr[i] == newArr[i - 1])
                    counter++;
                else
                {
                    if (counter > max)
                    {
                        dominator = newArr[i - 1];
                        max = counter;
                    }
                    counter = 1;
                }
                    
            }
            if (counter > max)
            {
                dominator = newArr.Last();
                max = counter;
            }
                

            if (max > newArr.Length / 2)
                return Array.IndexOf(A, dominator);

            return -1;
        }

        public static int solution2(int[] A) // Better, but still N*Log(N)
        {
            if (A.Length == 0)
                return -1;
            var origData = new int[A.Length];
            A.CopyTo(origData, 0);
            var n = A.Length;
            int? leader = null;
            Array.Sort(A);
            var candidate = A[n / 2];
            var count = 0;
            for (var i = 0; i < n; i++)
                if (A[i] == candidate)
                    count += 1;
            if (count > n / 2)
                leader = candidate;

            if (leader != null)
                return Array.IndexOf(origData, leader);
            return -1;
        }

        public static int solution3(int[] A) // Good solution - O(N)
        {
            var n = A.Length;
            if (n == 0)
                return -1;

            var size = 0;
            int? value = null;
            var valueIdx = -1;
            for (var i = 0; i < n; i++)
            {
                if (size == 0)
                {
                    size++;
                    value = A[i];
                    valueIdx = i;
                }
                else
                {
                    if (value != A[i])
                        size--;
                    else
                        size++;
                }
            }

            if (size <= 0)
                return -1;

            var count = 0;
            for (var j = 0; j < n; j++)
                if (A[j] == value)
                    count++;
            if (count > n / 2)
                return valueIdx;
            return -1;
        }
    }

    class Program
    {   
        static void Main(string[] args)
        {
            var input = new int[] { 2, 1, 1, 3, 4 };
            Console.WriteLine(Solution.solution3(input));
            Console.ReadLine();
        }
    }
}
