using Algorithms;
using System;

namespace ForDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 4, 3, 2, 5};
            MergeSort.Start(input, 1, 3);
            foreach (var i in input)
                Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
