using System;
using System.Threading;

namespace _01_BackgroundThread
{
    class Program
    {
        public static void Func1()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Func1 completed!");
        }
        static void Main(string[] args)
        {
            var t = new Thread(new ThreadStart(() => Func1()));

            t.IsBackground = false; // If isBackground = false, you can see "Func1 completed!", else you will see "Main Thread completed!" only
            t.Start();

            Console.WriteLine("Main Thread completed!");

        }
    }
}
