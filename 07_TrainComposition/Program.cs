using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TrainComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainComposition tree = new TrainComposition();
            tree.AttachWagonFromLeft(7);
            tree.AttachWagonFromLeft(13);
            Console.WriteLine(tree.DetachWagonFromRight()); // 7 
            Console.WriteLine(tree.DetachWagonFromLeft()); // 13
            Console.ReadLine();
        }
    }
}
