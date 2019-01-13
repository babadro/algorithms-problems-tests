using System;
using System.Collections.Generic;

namespace TreeTraversal
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Key;

        public Node(int item)
        {
            Key = item;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        void PrintPostorder(Node node, List<int> seq)
        {
            if (node == null)
                return;

            PrintPostorder(node.Left, seq);

            PrintPostorder(node.Right, seq);

            Console.Write(node.Key + " ");
            seq.Add(node.Key);
        }

        void PrintInorder(Node node, List<int> res)
        {
            if (node == null)
                return;

            PrintInorder(node.Left, res);

            Console.Write(node.Key + " ");
            res.Add(node.Key);

            PrintInorder(node.Right, res);
        }

        void PrintPreorder(Node node, List<int> res)
        {
            if (node == null)
                return;

            Console.Write(node.Key + " ");
            res.Add(node.Key);

            PrintPreorder(node.Left, res);

            PrintPreorder(node.Right, res);
        }

        // Wrapper over above recursive functions
        public void PrintPostorder(List<int> res)
        {
            PrintPostorder(root, res);
        }

        public void PrintInorder(List<int> res)
        {
            PrintInorder(root, res);
        }

        public void PrintPreorder(List<int> res)
        {
            PrintPreorder(root, res);
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.Left = new Node(2);
            tree.root.Right = new Node(3);
            tree.root.Left.Left = new Node(4);
            tree.root.Left.Right = new Node(5);

            Console.WriteLine("Preorder traversal of binary tree is ");
            var preorderSeq = new List<int>();
            tree.PrintPreorder(preorderSeq);

            Console.WriteLine("\nInorder traversal of binary tree is ");
            var inorderSeq = new List<int>();
            tree.PrintInorder(inorderSeq);

            Console.WriteLine("\nPostorder traversal of binary tree is ");
            var postorderSeq = new List<int>();
            tree.PrintPostorder(postorderSeq);

            Console.WriteLine();

            
        }
    }
}
