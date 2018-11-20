using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_TimeComplexity_01_FrogJmp
{
    class Solution
    {
        public int solution(int X, int Y, int D)
        {
            return ((Y - X) % D) > 0 ? ((Y - X) / D) + 1 : (Y - X) / D;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
