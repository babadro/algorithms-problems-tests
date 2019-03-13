using System;

namespace _04_ThreeBoxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 v = 5;
            Object o = v;
            v = 123;

            Console.WriteLine(v + ", " + (Int32)o); // Выведет "123, 5"
        }
    }
}
