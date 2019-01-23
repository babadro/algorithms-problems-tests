using System;

namespace _05_PassTypeAsParameter
{
    class Program
    {
        public static bool IsInt(Type type)
        {
            if (type == typeof(int))
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(IsInt(typeof(int))); // True
            Console.WriteLine(IsInt(typeof(object))); // False
        }
    }
}
