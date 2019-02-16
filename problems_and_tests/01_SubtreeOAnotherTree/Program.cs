using System;

// https://leetcode.com/problems/subtree-of-another-tree/
namespace _01_SubtreeOfAnotherTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;
            return Equals(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        public bool Equals(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
                return true;
            if (node1 == null || node2 == null)
                return false;
            if (node1.val != node2.val)
                return false;
            
            return Equals(node1.left, node2.left) && Equals(node1.right, node2.right);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(null == null);
        }
    }
}
