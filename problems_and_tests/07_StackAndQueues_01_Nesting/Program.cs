using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_StackAndQueues_01_Nesting
{
    class Solution
    {
        public static int solution(string S)
        {
            var stack = new Stack<char>(); // too complicated
            foreach (var i in S)
            {
                stack.Push(i);
                if (stack.Count < 2)
                    continue;
                var first = stack.Pop();
                var second = stack.Pop();
                if (!(first == ')' && second == '('))
                {
                    stack.Push(second);
                    stack.Push(first);
                }
            }
            return stack.Count == 0 ? 1 : 0;
        }

        public static int solution2(string S) // Good solution
        {
            var counter = 0;
            foreach (var i in S)
            {
                if (i == '(')
                    counter++;
                else
                    counter--;
                if (counter < 0)
                    return 0;
            }
            return counter == 0 ? 1 : 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution2("(()(())())"));
            Console.ReadLine();
        }
    }
}
