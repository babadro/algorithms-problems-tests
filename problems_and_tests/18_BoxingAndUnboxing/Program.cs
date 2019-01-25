using System;

namespace _18_BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 123;
            object myObj = a;

            int unboxed = (int)myObj;

            Console.WriteLine("Hello World!");
        }
    }
}
