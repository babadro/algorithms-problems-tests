using System;
using System.Threading;

namespace ReadWriterLockSlimExample
{
    internal sealed class Transaction : IDisposable
    {
        private readonly ReaderWriterLockSlim m_lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private DateTime m_timeOfLastTrans;

        public void PerformTransaction()
        {
            m_lock.EnterWriteLock();
            // Эксклюзивный доступ
            m_timeOfLastTrans = DateTime.Now;
            m_lock.ExitWriteLock();
        }

        public DateTime LastTransaction
        {
            get
            {
                m_lock.EnterReadLock();
                // This code has shared
                DateTime temp = m_timeOfLastTrans;
                m_lock.ExitReadLock();
                return temp;
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
