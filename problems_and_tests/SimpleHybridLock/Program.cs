using System;
using System.Threading;

namespace SimpleHybridLock
{
    internal sealed class SimpleHybridLock : IDisposable
    {
        private Int32 m_waiters = 0;

        private readonly AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        public void Enter()
        {
            // Собираемся взять блокировку.
            if (Interlocked.Increment(ref m_waiters) == 1)
                return; // Нет contention, все свободно.

            // Если другой поток нас опередил
            m_waiterLock.WaitOne(); // Жертвуем performance'м
            // Когда WaitOne пропустит, наш поток завладеет блокировку
        }

        public void Leave()
        {
            // Этот поток освобождает блокировку
            if (Interlocked.Decrement(ref m_waiters) == 0)
                return; // Никто нас не ждал, возвращаемся

            // Другие потоки ждут, пропустим одного из них
            m_waiterLock.Set(); // Жертвуем перформансом.
        }

        public void Dispose() { m_waiterLock.Dispose(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
