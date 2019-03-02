using System;
using System.Threading;

namespace DoubleCheckLockingTechnique
{
    internal sealed class Singleton
    {
        private static readonly Object s_lock = new Object();

        // Ссылка на единственный Синглтон объект
        private static Singleton s_value = null;

        private Singleton()
        {
            // Инициализируем единственный Синглтон объект здесь.
        }

        public static Singleton GetSingleton()
        {
            if (s_value != null) return s_value;

            Monitor.Enter(s_lock); // Если синглтон еще не создан - сюда проходит только один поток
            if (s_value == null)
            {
                Singleton temp = new Singleton();

                Volatile.Write(ref s_value, temp);
            }
            Monitor.Exit(s_lock);

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
