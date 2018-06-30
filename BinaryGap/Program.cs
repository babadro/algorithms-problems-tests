using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryGap
{
    class Solution
    {
        public int solution(int N) // Naive
        {
            string s = Convert.ToString(N, 2);
            var maxZeroesNum = s.Length - 2;
            for (var i = maxZeroesNum; i > 0; i--)
                if (s.Contains(BuiltGap(i)))
                    return i;
            return 0;
        }

        public string BuiltGap(int zeroesNum)
        {
            var builder = new StringBuilder();
            builder.Append("1");
            for (var i = 1; i <= zeroesNum; i++)
                builder.Append("0");
            builder.Append("1");
            return builder.ToString();
        }
    }

    class Solution2
    {
        public int solution(int N) // Good solution
        {
            string s = Convert.ToString(N, 2);
            var counting = false;
            int result = 0;
            int tempResult = 0;
            foreach (var ch in s)
            {
                if (ch == '1')
                {
                    counting = true;
                    result = Math.Max(result, tempResult);
                    tempResult = 0;
                } else if (counting)
                    tempResult++;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sol2 = new Solution();
            Console.WriteLine(sol2.solution(1376796946));
            Console.ReadLine();
        }
    }
}
