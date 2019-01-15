using System;
using System.Collections.Generic;
using System.Text;

namespace _04_GraphUsingAdjacencyMatrix
{
    class Graph
    {
        public int[][] AdjMatrix;
        public int NumVertex;
        public Dictionary<char, int> Vertices;
        private char[]  verticesList;
        public Graph(int numVertex)
        {
            for (var i = 0; i < numVertex; i++)
            {
                var arr = new int[numVertex];
                for (var j = 0; j < numVertex; j++)
                    arr[j] = -1;
                AdjMatrix[i] = arr;
            }

            NumVertex = numVertex;
            Vertices = new Dictionary<char, int>();
            verticesList = new char[numVertex];
        }

        public void SetVertex(int vertex, char id)
        {
            if (vertex >= 0 && vertex <= NumVertex)
            {
                Vertices[id] = vertex;
                verticesList[vertex] = id;
            }
        }

        public void SetEdge(char from, char to, int cost = 0)
        {
            int frm = Vertices[from];
            int t = Vertices[to];
            AdjMatrix[frm][t] = cost;
            // For directed graph do not add this
            AdjMatrix[to][from] = cost;
        }

        public char[] GetVertex()
        {
            return verticesList;
        }

        //public (char, char, int) GetEdges()
        //{
        //    var edges = new (char, char, int)[NumVertex,NumVertex];
        //    for (var i = 0; i < NumVertex; i++)
        //        for (var j = 0; j < NumVertex; j++)
        //            if (AdjMatrix[i][j] != -1)
        //                edges[i, j] = ;
        //} 

    }
}
