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
    }

    class Program
    {   
        static void Main(string[] args)
        {
            var input = new int[] { 0, 0, 1, 1, 1 };
            Console.WriteLine(Solution.solution(input));
            Console.ReadLine();
        }
    }
}
