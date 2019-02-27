using System;
using System.Threading;

namespace SimpleWaitLockBySemaphore
{
    public sealed class SimpleWaitLock : IDisposable
    {
        private readonly Semaphore m_available;

        public SimpleWaitLock(Int32 maxConcurrent)
        {
            m_available = new Semaphore(maxConcurrent, maxConcurrent);
        }

        public void Enter()
        {
            m_available.WaitOne();
        }

        public void Leave()
        {
            m_available.Release(1);
        }

        public void Dispose() { m_available.Close(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
