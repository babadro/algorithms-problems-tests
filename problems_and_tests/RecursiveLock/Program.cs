using System;
using System.Threading;

namespace RecursiveLock
{
    internal class SomeClass : IDisposable
    {
        private readonly Mutex m_lock = new Mutex();

        public void Method1()
        {
            m_lock.WaitOne();
            // Делаем что то
            Method2(); // Рекурсивно берет блокировку
            m_lock.ReleaseMutex();
        }

        public void Method2()
        {
            m_lock.WaitOne();
            // Делаем что-то
            m_lock.ReleaseMutex();
        }

        public void Dispose() { m_lock.Dispose(); }
    }

    internal sealed class RecursiveAutoResetEvent : IDisposable
    {
        private AutoResetEvent m_lock = new AutoResetEvent(true);
        private Int32 m_owningThreadId = 0;
        private Int32 m_recursionCount = 0;

        public void Enter()
        {
            Int32 currentThreadId = Thread.CurrentThread.ManagedThreadId;

            if (m_owningThreadId == currentThreadId)
            {
                m_recursionCount++;
                return;
            }

            m_lock.WaitOne();

            m_owningThreadId = currentThreadId;
            m_recursionCount = 1;
        }

        public void Leave()
        {
            if (m_owningThreadId != Thread.CurrentThread.ManagedThreadId)
                throw new InvalidOperationException();

            if  (--m_recursionCount == 0)
            {
                m_owningThreadId = 0;
                m_lock.Set();
            }
        }

        public void Dispose() { m_lock.Dispose(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
