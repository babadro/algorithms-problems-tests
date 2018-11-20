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
            tree.AttachWagonFromRight(1);
            tree.AttachWagonFromRight(2);
            tree.AttachWagonFromRight(3);
            tree.AttachWagonFromRight(4);
            tree.AttachWagonFromRight(5);
            tree.AttachWagonFromRight(6);
            tree.AttachWagonFromRight(7);
            tree.AttachWagonFromRight(8);
            tree.AttachWagonFromRight(9);
            tree.AttachWagonFromRight(10);
            Console.WriteLine(tree.DetachWagonFromLeft()); // 1 
            Console.WriteLine(tree.DetachWagonFromLeft()); // 2
            Console.WriteLine(tree.DetachWagonFromRight()); //10
            Console.WriteLine(tree.DetachWagonFromRight()); //9
            Console.ReadLine();
        }
    }
}
