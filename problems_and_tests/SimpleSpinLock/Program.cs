using System;
using System.Threading;

namespace SimpleSpinLock
{
    internal struct SimpleSpinLock
    {
        private Int32 m_ResourceInUse; // 0 = false, 1= true
        public void Enter()
        {
            while (true)
            {
                if (Interlocked.Exchange(ref m_ResourceInUse, 1) == 0) return;
            }
        }

        public void Leave()
        {
            Volatile.Write(ref m_ResourceInUse, 0);
        }
    }

    public sealed class SomeResource
    {
        private SimpleSpinLock m_sl = new SimpleSpinLock();

        public void AccessResource()
        {
            m_sl.Enter();
            // Только один поток в каждый момент времени может находится здесь
            m_sl.Leave();
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
