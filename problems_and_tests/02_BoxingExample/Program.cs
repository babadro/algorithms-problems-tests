using System;
using System.Collections;

namespace _02_BoxingExample
{
    struct Point
    {
        public Int32 x, y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList();
            Point p;
            p.x = 1;
            for (Int32 i = 0; i < 10; i++)
            {
                p.x = p.y = i;
                a.Add(p);
            }
        }
    }
}
