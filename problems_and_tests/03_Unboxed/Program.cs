using System;

namespace _03_Unboxed
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 x = 5;
            object o = x;
            Int16 y = (Int16)(Int32)o;
        }
    }
}
