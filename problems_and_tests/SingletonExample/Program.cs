using System;
using System.Threading;

namespace SingletonExample
{
    internal sealed class Singleton
    {
        private static Singleton s_value = null;

        private Singleton()
        {
            // Код конструктора
        }

        public static Singleton GetSingleton()
        {
            if (s_value != null) return s_value;

            Singleton temp = new Singleton();
            Interlocked.CompareExchange(ref s_value, temp, null);

            return s_value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
