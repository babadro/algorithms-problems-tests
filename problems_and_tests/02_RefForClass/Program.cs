using System;
using System.IO;

namespace _02_RefForClass
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs;

            StartProcessingFiles(out fs);

            for (; fs != null; ContinueProcessingFiles(ref fs))
            {
                // Process a file.
                fs.Read(...);
            }
        }

        private static void StartProcessingFiles(out FileStream fs)
        {
            fs = new FileStream(...);
        }

        private static void ContinueProcessingFiles(ref FileStream fs)
        {
            fs.Close();

            if (noMoreFilesToProcess) fs = null;
            else fs = new FileStream(...);
        }
    }
}
