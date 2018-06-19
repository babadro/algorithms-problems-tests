using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DeepestPit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = new [] { 7, 3, 3, 1, 7 };
            var result1 = Deepest(input1);
            var input2 = new[] {0, 1, 3, -2, 0, 1, 0, -3, 2, 3};
            var result2 = Deepest(input2);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(Deepest2(input1));
            Console.ReadLine();
        }

        private static int Deepest(int[] data)
        {
            if (data.Length < 1)
                return 0;

            int inflection = 0;
            int max = 0;
            int descent = 0;
            Boolean ascending = true;
            for (int i = 1; i < data.Length; i++)
            {
                bool goingup = data[i] == data[i - 1] ? ascending : data[i] >= data[i - 1];
                if (goingup != ascending)
                {
                    ascending = goingup;
                    descent = ascending ? (data[inflection] - data[i - 1]) : 0;
                    inflection = i - 1;
                }

                max = Math.Max(max, Math.Min(descent, data[i] - data[inflection]));
            }
            return max;
        }

        private static int Deepest2(int[] data)
        {
            if (data.Length < 3)
                return 0;

            var descentStart = 0;
            int leftDrop = 0;
            int rightDrop = 0;
            var ascendStart = 0;
            var prevState = State.Flat;
            int max = 0;

            for (int i = 1; i < data.Length; i++)
            {
                var nextState = i + 1 == data.Length ? State.Flat : data[i + 1] < data[i] ? State.Down : data[i + 1] > data[i] ? State.Climb : State.Flat;
                if (nextState == prevState)
                    continue;
                if (prevState == State.Flat)
                {
                    descentStart = ascendStart = i;
                    prevState = nextState;
                    continue;
                }

                if (prevState == State.Down && nextState == State.Climb)
                {
                    leftDrop = data[i] - data[descentStart];
                    ascendStart = i;
                    prevState = nextState;
                    continue;
                }

                if (prevState == State.Climb && nextState != State.Climb)
                {
                    rightDrop = data[i] - data[ascendStart];
                    max = Math.Max(max, Math.Min(leftDrop, rightDrop));
                }

            }
            return max;
        }

        private enum State : byte
        {
            Down,
            Climb,
            Flat
        }
    }
}
