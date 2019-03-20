using System;
using System.Threading;
//#define CompilerImplementedEventMethods

namespace _11_MailManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    private static void TypeWithLotsOfEventsTest()
    {
        
    }

    internal sealed class NewMailEventArgs : EventArgs
    {
        private readonly String m_from, m_to, m_subject;

        public NewMailEventArgs(string from, string to, string subject)
        {
            m_from = from; m_to = to; m_subject = subject;
        }

        public String From { get { return m_from; } }
        public String To { get { return m_to; } }
        public String Subject { get { return m_subject; } }
    }

    internal class MailManager
    {
        public static void Go()
        {
            MailManager mm = new MailManager();

            Fax fax = new Fax(mm);

            Pager pager = new Pager(mm);

            mm.SimulateNewMail("Jeffrey", "Kristin", "Tra tata");

            fax.Unregister(mm);

            mm.SimulateNewMail("Jeffrey", "Mom & Dad", "Happy Birthday.");
        }

#if CompilerImplementEventMethods
        public event EventHandler<NewMailEventArgs> NewMail;
#else
        // Приватное поле, где будет "голова" связанного списка делегатов
        private EventHandler<NewMailEventArgs> m_NewMail;

        // Добавляем эвент в класс
        public event EventHandler<NewMailEventArgs> NewMail
        {
            add // Явно реализуем метод add
            {
                // Без потокобезопасности! Добавляем обработчик события в связанный список делегатов
                m_NewMail += value;
            }

            remove
            {
                // Без потокобезопасности! Удаляем обработчик события из связанного списка делегатов
                m_NewMail -= value;
            }
        }

#endif

        // Тот самый метод, который возбуждает событие. Можно сделать private virtual, если бы наш MailManager был sealed
        protected virtual void OnNewMail(NewMailEventArgs e)
        {
#if CompilerImplementedEventMethods
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
#else
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref m_NewMail);
#endif

            // Если кто-то подписался на эвент - уведомим их
            if (temp != null) temp(this, e);
        }

        public void SimulateNewMail(String from, String to, String subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);

            OnNewMail(e);
        }
    }

    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate)
        {
            // Копируем ссылку на делегат во временное поле для потокобезопасности.
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);

            if (temp != null) temp(sender, e);
        }
    }

    internal sealed class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(Object sender, NewMailEventArgs e)
        {
            // 'sender' нам нужен, если хотим с ним еще пообщаться.
            // 'e' доп инфо для нас

            // Типа отправка факса
            Console.WriteLine("Faxing mail message: ");
            Console.WriteLine("    From=_{0}, To={1}, Subject={2}", e.From, e.To, e.Subject);
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }

    internal sealed class Pager
    {
        public Pager(MailManager mm)
        {
            mm.NewMail += SendMsgToPager;
        }

        private void SendMsgToPager(Object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Sending mail message to pager:");
            Console.WriteLine("     From={0}, To={1}, Subject={2}", e.From, e.To, e.Subject);
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= SendMsgToPager;
        }
    }
}
