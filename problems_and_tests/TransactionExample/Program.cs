using System;
using System.Threading;

namespace TransactionExample
{
    internal sealed class Transaction
    {
        private DateTime m_timeOfLastTrans;

        public void PerformTransaction()
        {
            Monitor.Enter(this);
            // Эксклюзивный доступ к данным
            m_timeOfLastTrans = DateTime.Now;
            Monitor.Exit(this);
        }

        public DateTime LastTransaction
        {
            get
            {
                Monitor.Enter(this);
                // Эксклюзивный доступ к данным
                DateTime temp = m_timeOfLastTrans;
                Monitor.Exit(this);
                return temp;
            }
        }
    }

    internal sealed class TransactionPrivateLock
    {
        private readonly object m_lock = new object();

        private DateTime m_timeOfLastTrans;

        public void PerformTransaction()
        {
            Monitor.Enter(this);
            // Эксклюзивный доступ к данным
            m_timeOfLastTrans = DateTime.Now;
            Monitor.Exit(this);
        }

        public DateTime LastTransaction
        {
            get
            {
                Monitor.Enter(this);
                // Эксклюзивный доступ к данным
                DateTime temp = m_timeOfLastTrans;
                Monitor.Exit(this);
                return temp;
            }
        }
    }

    class Program
    {
        public static void SomeMethod()
        {
            var t = new Transaction();
            Monitor.Enter(t); // Поток берет публичное поле для индекса sync block в массиве блокировок.

            // Тред в тред пулле блокируется до тех пор, пока SomeMethod не вызовет Monitor.Exit!
            ThreadPool.QueueUserWorkItem(o => Console.WriteLine(t.LastTransaction));

            // Тут некий другой код как будто

            Monitor.Exit(t);
            a = TransactionPrivateLock.m_lock;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
