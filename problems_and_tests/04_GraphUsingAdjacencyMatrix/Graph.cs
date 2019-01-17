using System;
using System.Collections.Generic;
using System.Text;

namespace _04_GraphUsingAdjacencyMatrix
{
    /// <summary>
    /// https://www.programiz.com/dsa/graph-adjacency-matrix
    /// </summary>
    public class Graph
    {
        private bool[][] adjMatrix;
        private int numVertices;

        public Graph(int numVertices)
        {
            this.numVertices = numVertices;
            adjMatrix = new bool[numVertices][];
            for (var i = 0; i < adjMatrix.Length; i++)
                adjMatrix[i] = new bool[numVertices];
        }

        public void AddEdge(int i, int j)
        {
            adjMatrix[i][j] = true;
            adjMatrix[j][i] = true;
        }

        public void RemoveEdge(int i, int j)
        {
            adjMatrix[i][j] = false;
            adjMatrix[j][i] = false;
        }

        public bool isEdge(int i, int j) => adjMatrix[i][j];

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < numVertices; i++)
            {
                s.Append(i + ": ");
                foreach (var j in adjMatrix[i])
                    s.Append((j ? 1 : 0) + " ");

                s.Append("\n");
            }
            return s.ToString();
        }
    }
}
