using System;
using System.Collections.Generic;

//https://leetcode.com/problems/implement-stack-using-queues/
namespace _225_ImplementStackCusingQueues
{
    public class MyStack
    {
        private readonly List<int> _list = new List<int>();
        /** Initialize your data structure here. */
        public MyStack()
        {
            
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            _list.Add(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            var lastIdx = _list.Count - 1;
            var res = _list[lastIdx];
            _list.RemoveAt(lastIdx);
            return res;
        }

        /** Get the top element. */
        public int Top()
        {
            return _list[_list.Count - 1];
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _list.Count == 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
