using System;

namespace _06_ChangingFieldsInBoxed
{
    // Point is a value type.
    internal struct Point
    {
        private Int32 m_x, m_y;
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
        public void Change(Int32 x, Int32 y)
        {
            m_x = x; m_y = y;
        }
        public override String ToString()
        {
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1, 1);
            Console.WriteLine(p);
            p.Change(2, 2);
            Console.WriteLine(p);
            Object o = p;
            Console.WriteLine(o);
            ((Point)o).Change(3, 3);
            Console.WriteLine(o);
        }
    }
}
