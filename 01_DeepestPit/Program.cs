using System;

namespace _01_DeepestPit
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[][]{
                //new int[] { 0, 11, 3, -2, 0, 1, 0, -3, 2, 3 },
                //new int[] {},
                //new int[] {1},
                //new int[] {1, 10},
                //new int[] {10, 1},
                //new int[] {2, 0, 1 },
                //new int[] {1, 0, 0, 0, 0, 0, 10, 20},
                //new int[] {-1, 0, 0, 0, 0, 0, -10, -20},
                //new int[] {0, 1, 3, -2, 0, 1, 0, -3, 2, 3},
                //new int[] { 7, 3, 3, 1, 7 },
                new int[] {4, 2, 0, 1, 1, 3}
            };

            var pitExplorer = new PitExplorer();

            foreach (var arr in data)
                Console.WriteLine(pitExplorer.FindDeepestPit(arr));

            Console.ReadLine();
        }
    }
}
