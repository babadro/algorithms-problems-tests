using System;

namespace _05_InterfaceBoxing
{
    internal struct Point : IComparable
    {
        private readonly Int32 m_x, m_y;

        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }

        // Переопределяем метод, унаследованный от System.ValueType
        public override string ToString()
        {
            return String.Format("({0}, {1},", m_x.ToString(), m_y.ToString());
        }

        // Наш метод сравнения
        public Int32 CompareTo(Point other)
        {
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y) -
                Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
        }

        // Реализация метода сравнения, который определяется интерфейсом IComparable
        public Int32 CompareTo(Object o)
        {
            if (GetType() != o.GetType())
                throw new ArgumentException("o is not a Point");

            return CompareTo((Point)o);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Два инстанца в стеке
            Point p1 = new Point(10, 10);
            Point p2 = new Point(20, 20);

            // Нет boxing, потому что метод виртуальный (переопределен нами)
            Console.WriteLine(p1.ToString()); // "(10, 10)"

            // Есть boxing, потому что GetType - невиртуальный метод от родителя
            Console.WriteLine(p1.GetType());// "Point"

            // Нет боксинга для р1 - потому что CompareTo - наш невиртуальный метод
            // Нет боксинга для р2, потому что CompareTo принимает Point
            Console.WriteLine(p1.CompareTo(p2));// "-1"

            // Происходит боксинг, потому что интерфейс - ссылочный тип
            IComparable c = p1;
            Console.WriteLine(c.GetType());// "Point"

            // Нет боксинга для р1
            // Нет для с, потому что вызвался CompareTo(object), а с - уже является ссылкой
            Console.WriteLine(p1.CompareTo(c));//"0"

            // с - уже ссылка, поэтому боксинга нет
            // А для p2 есть боксинг, потому что вызвался CompareTo(object)
            Console.WriteLine(c.CompareTo(p2));//"-1"

            p2 = (Point)c; // с - unboxed, поля копируются в р2

            Console.WriteLine(p2.ToString()); //"(10, 10)"
        }
    }
}
