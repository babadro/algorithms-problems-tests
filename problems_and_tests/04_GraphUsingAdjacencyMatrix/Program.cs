using System;

namespace _04_GraphUsingAdjacencyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);

            Console.Write(g.ToString());
        }
    }
}
