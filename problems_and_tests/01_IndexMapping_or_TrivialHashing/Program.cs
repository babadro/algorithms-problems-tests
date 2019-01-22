using System;

namespace _01_IndexMapping_or_TrivialHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { -1, 9, -5, -8, -5, -2 };

            var hashTable = new GFG(10);
            int X = -5;

            if (hashTable.Search(X))
                Console.WriteLine("Present");
            else
                Console.WriteLine("Not present");
        }
    }
}
