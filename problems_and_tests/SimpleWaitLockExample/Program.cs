using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SimpleWaitLockExample
{
    internal sealed class SimpleWaitLock : IDisposable
    {
        private readonly AutoResetEvent m_available;
        public SimpleWaitLock()
        {
            m_available = new AutoResetEvent(true);
        }
        public void Enter()
        {
            m_available.WaitOne();
        }
        public void Leave()
        {
            m_available.Set();
        }
        public void Dispose() { m_available.Dispose(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Int32 x = 0;
            const Int32 iterations = 10000000;

            Stopwatch sw = Stopwatch.StartNew();

            for (Int32 i = 0; i < iterations; i++)
                x++;
            Console.WriteLine("Increamenting x: {0:N0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < iterations; i++)
                M(); x++; M();
            Console.WriteLine("Incrementing x in M: {0:N0}", sw.ElapsedMilliseconds);

            SpinLock sl = new SpinLock(false);
            sw.Restart();
            for (var i = 0; i < iterations; i++)
            {
                bool taken = false; sl.Enter(ref taken); x++; sl.Exit();
            }
            Console.WriteLine("Incrementing x in SpinLock: {0:N0}", sw.ElapsedMilliseconds);

            using (SimpleWaitLock swl = new SimpleWaitLock())
            {
                sw.Restart();
                for (var i = 0; i < iterations; i++)
                    swl.Enter(); x++; swl.Leave();
                Console.WriteLine("Incrementinx x in SimpleWaitLock: {0:N0}", sw.ElapsedMilliseconds);
            }

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void M() { /* Ничего не делаем */ }
    }
}
