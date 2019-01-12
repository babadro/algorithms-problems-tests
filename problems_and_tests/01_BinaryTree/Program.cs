using System;

namespace _01_BinaryTree
{
    public class Node
    {
        int key;
        public Node left;
        public Node right;

        public Node(int item)
        {
            key = item;
            left = null;
            right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;

        public BinaryTree(int key)
        {
            root = new Node(key);
        }

        public BinaryTree()
        {
            root = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new Node(1); // Create root

            tree.root.left = new Node(2);
            tree.root.right = new Node(3);

            tree.root.left.left = new Node(4);
        }
    }
}
