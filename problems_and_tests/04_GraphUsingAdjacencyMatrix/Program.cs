using System;

namespace _04_GraphUsingAdjacencyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var G = new Graph(6);

            G.SetVertex(0, 'a');
            G.SetVertex(1, 'b');
            G.SetVertex(2, 'c');
            G.SetVertex(3, 'd');
            G.SetVertex(4, 'e');
            G.SetVertex(5, 'f');

            G.SetEdge('a', 'e', 10);
            G.SetEdge('a', 'c', 20);
            G.SetEdge('c', 'b', 30);
            G.SetEdge('b', 'e', 40);
            G.SetEdge('e', 'd', 50);
            G.SetEdge('f', 'e', 60);

            Console.WriteLine("Vertices of Graph");
            Console.WriteLine(G.GetVertex());

            Console.WriteLine("Edges of Graph");
            Console.WriteLine(G.GetEdges());

            Console.WriteLine("Adjacency Matrix of Graph");
            Console.WriteLine(G.GetMatrix());
        }
    }
}
