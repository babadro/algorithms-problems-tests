using System;
using System.Threading;

namespace InterlockedMaximumExample
{
    
    class Program
    {
        public static Int32 Maximum(ref Int32 target, Int32 value)
        {
            Int32 currentVal = target, startVal, desiredVal;

            do
            {
                startVal = currentVal;

                desiredVal = Math.Max(startVal, value);

                currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);
            } while (startVal != currentVal);

            return desiredVal;
        }

        static void Main(string[] args)
        {
            var first = 1;
            //var result = Maximum(ref firstVal)
        }
    }
}
