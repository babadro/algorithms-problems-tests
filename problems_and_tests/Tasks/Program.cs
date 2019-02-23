using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n> 0; n--)
                checked { sum += n; }
            return sum;
        }

        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n >0; n--)
            {
                ct.ThrowIfCancellationRequested();

                checked { sum += n; }
            }
            return sum;

        }

        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            //new Task(ComputeBoundOp, 5).Start();
            //Task.Run(() => ComputeBoundOp(5));

            // Create a Task (it does not start running now)
            Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000000000);

            t.Start();

            t.Wait();

            // You can get the result (the Result property internally calls Wait)
            Console.WriteLine("The Sum is: " + t.Result); // An Int32 value

            Task<Int32> t2 = Task.Run(() => Sum(CancellationToken.None, 10000));
            Task cst = t2.ContinueWith(task => Console.WriteLine("The sum is : " + task.Result));
        }
    }
}
