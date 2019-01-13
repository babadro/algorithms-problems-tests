using Xunit;
using TreeTraversal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class _04_TreesAndGraps_01_Theory_BinaryTreeTests
    {
        [Fact]
        public void TreeTraversalTests()
        {
            BinaryTree bigTree = new BinaryTree();
            bigTree.root = new Node(25);
            bigTree.root.Left = new Node(15);
            bigTree.root.Right = new Node(50);

            bigTree.root.Left.Left = new Node(10);
            bigTree.root.Left.Left.Left = new Node(4);
            bigTree.root.Left.Left.Right = new Node(12);

            bigTree.root.Left.Right = new Node(22);
            bigTree.root.Left.Right.Left = new Node(18);
            bigTree.root.Left.Right.Right = new Node(24);

            bigTree.root.Right.Left = new Node(35);
            bigTree.root.Right.Left.Left = new Node(31);
            bigTree.root.Right.Left.Right = new Node(44);

            bigTree.root.Right.Right = new Node(70);
            bigTree.root.Right.Right.Left = new Node(66);
            bigTree.root.Right.Right.Right = new Node(90);

            Console.WriteLine("\nPreorder traversal of bigTree is ");
            var preorderSeqBig = new List<int>();
            bigTree.PrintPreorder(preorderSeqBig);
            Assert.True(preorderSeqBig.SequenceEqual(new int[] { 25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90 }));

            Console.WriteLine("\nInorder traversal of bigTree is ");
            var inorderSeqBig = new List<int>();
            bigTree.PrintInorder(inorderSeqBig);
            Assert.True(inorderSeqBig.SequenceEqual(new int[] { 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90 }));

            Console.WriteLine("\nPostorder traversal of bigTree is ");
            var postorderSeqBig = new List<int>();
            bigTree.PrintPostorder(postorderSeqBig);
            Assert.True(postorderSeqBig.SequenceEqual(new int[] { 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25 }));
            
        }
    }
}
