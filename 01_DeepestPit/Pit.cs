using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DeepestPit
{
    public class PitExplorer
    {
        public int FindDeepestPit(int[] data)
        {
            if (data.Length < 3)
                return 0;

            var downStart = 0;
            var upStart = 0;
            var drop = 0;
            var climb = 0;
            var prevInterval = Func.Unknown;
            var result = 0;
            var weAreInPit = false;

            for (int i = 0; i < data.Length; i++)
            {
                var nextInterval = i + 1 == data.Length ? Func.Unknown : data[i + 1] < data[i] ? Func.Down : data[i + 1] > data[i] ? Func.Up : Func.Unknown;

                if (nextInterval == Func.Down && prevInterval != Func.Down)
                    downStart = i;
                else if (nextInterval == Func.Up && prevInterval != Func.Up)
                    upStart = i;

                if (nextInterval == Func.Up && prevInterval == Func.Down)
                    weAreInPit = true;

                if (nextInterval == Func.Up && prevInterval == Func.Down)
                    drop = data[downStart] - data[i];
                else if (nextInterval != Func.Up && prevInterval == Func.Up)
                {
                    climb = data[i] - data[upStart];
                    if (weAreInPit)
                    {
                        result = Math.Max(result, Math.Min(drop, climb));
                        weAreInPit = false; // pit was measured
                    }
                }

                prevInterval = nextInterval;
            }
            return result;
        }
    }

    public enum Func : byte
    {
        Unknown,
        Down,
        Up
    }
}
