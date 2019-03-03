using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryBytesExample
{
    class Program
    {
        private static Int64 DirectoryBytes(String path, String searchPattern, SearchOption searchOption)
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
            Int64 masterTotal = 0;

            ParallelLoopResult result = Parallel.ForEach<string, Int64>(
                files,
                () => // LocalInit: Invoked один раз на таску при старте
                    {
                        return 0; // Установить начальное значение taskLocalTotal в 0
                    },
                (file, loopState, index, taskLocalTotal) => // body: вовлекается единожды на каждый ворк итем
                    {// Получить размер файлаи добавить его в total
                        Int64 fileLength = 0;
                        FileStream fs = null;
                        try
                        {
                            fs = File.OpenRead(file);
                            fileLength = fs.Length;
                        }
                        catch (IOException) { /* Игнорируем файлы, которые не получилось обработать*/}
                        finally { if (fs != null) fs.Dispose(); }
                        return taskLocalTotal + fileLength;
                    },
                taskLocalTotal => // localFinally: код вызывается единожды в конце таски
                    { // Атомно добавляем таску
                        Interlocked.Add(ref masterTotal, taskLocalTotal);
                    }
                );
            return masterTotal;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
