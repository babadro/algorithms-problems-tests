using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    public class Stack
    {
        private int[] ele;
        private int top;
        private int max;

        public Stack(int size)
        {
            ele = new int[size]; // Maximum size of Stack
            top = -1;
            max = size;
        }

        public void push(int item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
                ele[++top] = item;
        }

        public int pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            else
            {
                Console.WriteLine($"{ele[top]} popped from stack ");
                return ele[top--];
            }
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            else
            {
                for (int i = 0; i <= top; i++)
                    Console.WriteLine($"{ele[i]} pushed into stack");
            }
        }
    }
}
