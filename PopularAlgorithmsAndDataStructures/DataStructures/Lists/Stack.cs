using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Lists
{
    
    public class Stack
    {
        private int[] array;
        private int top;

        public Stack(int size)
        {
            array = new int[size];
            top = -1;
        }

        public void Push(int element)
        {
            if (top == array.Length - 1)
            {
                Console.WriteLine("Stack overflow");
                return;
            }
            else
                array[++top] = element;
        }

        public int Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            else
                return array[top--];
        }

        public void Print()
        {
            if (top == -1)
                Console.WriteLine("Stack is empty");
            else
            {
                foreach (var i in array)
                    Console.WriteLine(i);
            }
        }
    }
}
