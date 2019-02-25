using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiWebRequestsSample
{
    internal sealed class MultiWebRequests
    {
        private AsyncCoordinator m_ac = new AsyncCoordinator();

        private Dictionary<String, Object> m_servers = new Dictionary<String, Object>
        {
            { "http://Wintellect.com/", null },
            { "http://Microsoft.com/", null },
            { "http://1.1.1.1/", null }
        };

        public MultiWebRequests(Int32 timeout = Timeout.Infinite)
        {
            var httpClient = new HttpClient();
            foreach (var server in m_servers.Keys)
            {
                m_ac.AboutToBegin(1);
                httpClient.GetByteArrayAsync(server)
                    .ContinueWith(task => ComputeResult(server, task));
            }

            m_ac.AllBegun(AllDone, timeout);
        }

        private void ComputeResult(String server, Task<Byte[]> task)
        {
            Object result;
            if (task.Exception != null)
                result = task.Exception.InnerException;
            else
                result = task.Result.Length;

            m_servers[server] = result;
            m_ac.JustEnded();
        }

        public void Cancel() { m_ac.Cancel(); }

        private void AllDone(CoordinationStatus status)
        {
            switch (status)
            {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("Operation canceled");
                    break;
                case CoordinationStatus.Timeout:
                    Console.WriteLine("Operation timed-out");
                    break;
                case CoordinationStatus.AllDone:
                    Console.WriteLine("Operation completed; results below:");
                    foreach (var server in m_servers)
                    {
                        Console.Write("{0} ", server.Key);
                        Object result = server.Value;
                        if (result is Exception)
                            Console.WriteLine("failed dut to {0}.", result.GetType().Name);
                        else
                            Console.WriteLine("returned {0:N0} bytes.", result);
                    }
                    break;
            }
        }
    }
}
