using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BlockingCollectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bl = new BlockingCollection<Int32>(new ConcurrentQueue<Int32>());
            ThreadPool.QueueUserWorkItem(ConsumeItems, bl);

            for (int item = 0; item < 5; item++)
            {
                Console.WriteLine("Producing: " + item);
                bl.Add(item);
            }

            // Говорим консьюмеру, что больше в коллекцию ничего добавлять не будем.
            bl.CompleteAdding();

            Console.ReadLine(); // Для тестов
        }

        private static void ConsumeItems(Object o)
        {
            var bl = (BlockingCollection<Int32>) o;

            foreach (var item in bl.GetConsumingEnumerable())
                Console.WriteLine("Consuming: " + item);

            Console.WriteLine("All items have been consumed");
        }
    }
}
