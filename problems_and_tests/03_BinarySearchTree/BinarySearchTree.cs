using System;
using System.Collections.Generic;
using System.Text;

namespace _03_BinarySearchTree
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }
    public class BinarySearchTree
    {
        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public Node Search(Node root, int key)
        {
            if (root == null || root.key == key)
                return root;

            if (root.key > key)
                return Search(root.left, key);

            return Search(root.right, key);
        }

        public void Insert(int key)
        {
            root = InsertRec(root, key);
        }

        private Node InsertRec(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            if (key < root.key)
                root.left = InsertRec(root.left, key);
            else if (key > root.key)
                root.right = InsertRec(root.right, key);

            return root;
        }

        public void Inorder()
        {
            InorderRec(root);
        }

        private void InorderRec(Node root)
        {
            if (root != null)
            {
                InorderRec(root.left);
                Console.WriteLine(root.key);
                InorderRec(root.right);
            }
        }

    }
}
