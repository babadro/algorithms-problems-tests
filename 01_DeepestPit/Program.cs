using System;

namespace _01_DeepestPit
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[][]{
                new int[] { 0, 11, 3, -2, 0, 1, 0, -3, 2, 3 },
                new int[] {},
                new int[] {1},
                new int[] {1, 10},
                new int[] {10, 1},
                new int[] {1, 0, 0, 0, 0, 0, 10, 20},
                new int[] {-1, 0, 0, 0, 0, 0, -10, -20},
                new int[] {0, 1, 3, -2, 0, 1, 0, -3, 2, 3},
                new int[] { 7, 3, 3, 1, 7 }
            };


            foreach (var arr in data)
                Console.WriteLine(DeepestPit(arr));

            Console.ReadLine();
        }

        private static int DeepestPit(int[] data)
        {
            if (data.Length < 3)
                return 0;

            var downStart = 0;
            var upStart = 0;
            var drop = 0;
            var climb = 0;
            var prevInterval = Func.Unknown;
            var max = 0;

            for (int i = 0; i < data.Length; i++)
            {
                var nextInterval = i + 1 == data.Length ? Func.Unknown : data[i + 1] < data[i] ? Func.Down : data[i + 1] > data[i] ? Func.Up : Func.Unknown;

                if (nextInterval == Func.Down && prevInterval != Func.Down)
                    downStart = i;

                if (nextInterval == Func.Up && prevInterval != Func.Up)
                    upStart = i;

                if (nextInterval == Func.Up && prevInterval == Func.Down)
                    drop = data[downStart] - data[i];

                if (nextInterval != Func.Up && prevInterval == Func.Up)
                {
                    climb = data[i] - data[upStart];
                    max = Math.Max(max, Math.Min(drop, climb));
                }

                prevInterval = nextInterval;
            }
            return max;
        }

        private enum Func : byte
        {
            Unknown,
            Down,
            Up
        }
    }
}
