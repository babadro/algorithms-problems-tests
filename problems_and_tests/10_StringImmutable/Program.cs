using System;

namespace _10_StringImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello";
            string s2 = s1;
            s2 += "User";

            Console.WriteLine("Actual data of string are equal ? " + (s1 == s2 ? true : false) + Environment.NewLine);

            Console.WriteLine("Are the Values(pointer to data) of string same ? " + (object.ReferenceEquals(s1, s2)));

        }
    }
}
