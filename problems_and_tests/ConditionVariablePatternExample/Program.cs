using System;
using System.Threading;

namespace ConditionVariablePatternExample
{
    internal sealed class CondiitonVariablePattern
    {
        private readonly object m_lock = new object();
        private bool m_condition = false;

        public void Thread1()
        {
            Monitor.Enter(m_lock);

            // Внутри блокировки тестируем сложно услоовие "атомно"
            while (!m_condition)
            {
                Monitor.Wait(m_lock); // Временно освободили блокировку, так, что другие
            }                         // потоки могут взять ее 

            // Условие выполнилось, начинается какая-то работа кода с данными

            Monitor.Exit(m_lock); // Постоянно сняли блокировку.
        }

        public void Thread2()
        {
            Monitor.Enter(m_lock);

            m_condition = true;

            // Monitor.Pulse(m_lock);   // Будем ОДИН ожидающий поток после того, как снимется блокировка
            Monitor.PulseAll(m_lock);   // Будем ВСЕ ожидающие потоки послет ого, как снимается блокировка.

            Monitor.Exit(m_lock);       // Release lock
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
