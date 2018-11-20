using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            Path path = new Path("/a/b/c/d");
            path.Cd("../x");
            Console.WriteLine(path.CurrentPath);
            Console.ReadLine();
        }
    }
}
