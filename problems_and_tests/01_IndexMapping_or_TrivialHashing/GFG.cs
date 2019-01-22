using System;
using System.Collections.Generic;
using System.Text;

namespace _01_IndexMapping_or_TrivialHashing
{
    public class GFG
    {
        private readonly bool[,] has;
        public GFG(int max)
        {
            has = new bool[max, 2];
        }

        public bool Search(int X)
        {
            if (X >= 0)
                return has[X, 0];

            X = Math.Abs(X);
            return has[X, 1];
        }

        public void Insert(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 0)
                    has[a[i], 0] = true;
                else
                    has[Math.Abs(a[i]), 1] = true;
            }
        }
    }
}
