using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactories
{
    class Program
    {
        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();

                checked { sum += n; }
            }
            return sum;

        }
        static void Main(string[] args)
        {
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<Int32>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                var childTasks = new[]
                {
                    tf.StartNew(() => Sum(cts.Token, 10000)),
                    tf.StartNew(() => Sum(cts.Token, 20000)),
                    tf.StartNew(() => Sum(cts.Token, Int32.MaxValue))
                };

                for (Int32 task = 0; task < childTasks.Length; task++)
                    childTasks[task].ContinueWith(
                        t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                tf.ContinueWhenAll(
                    childTasks,
                    completedTasks => completedTasks.Where(t => t.Status == TaskStatus.RanToCompletion).Max(t => t.Result),
                    CancellationToken.None)
                            .ContinueWith(t => Console.WriteLine("The maximum is: " + t.Result),
                            TaskContinuationOptions.ExecuteSynchronously);
            });

            parent.ContinueWith(p =>
            {
                StringBuilder sb = new StringBuilder(
                    "The following exception(s) occured:" + Environment.NewLine);

                foreach (var e in p.Exception.Flatten().InnerExceptions)
                    sb.AppendLine(" " + e.GetType().ToString());
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();
        }
    }
}
