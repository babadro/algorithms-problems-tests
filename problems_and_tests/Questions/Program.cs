using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    class Program
    {
        public class Palindrome
        {
            public static bool IsPalindrome(string word)
            {
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray).ToLower() == word.ToLower();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Palindrome.IsPalindrome("Deleveled"));
            Console.ReadLine();
        }
    }
}
