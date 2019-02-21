using System;

// https://leetcode.com/problems/reverse-bits/
namespace _190_ReverseBits
{
    class Program
    {
        public class Solution
        {
            // Doesn't work
            public uint reverseBits(uint n)
            {
                var str = n.ToString().ToCharArray();
                Array.Reverse(str);
                var resStr = string.Concat(str);
                var res = UInt32.Parse(resStr);
                return res;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
