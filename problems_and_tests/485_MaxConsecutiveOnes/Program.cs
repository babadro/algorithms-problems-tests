using System;

//https://leetcode.com/problems/max-consecutive-ones/
namespace _485_MaxConsecutiveOnes
{
    public class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            var max = 0;
            var curMax = 0;
            foreach (var i in nums)
            {
                if (i == 1)
                    curMax++;
                else
                {
                    if (max < curMax)
                        max = curMax;
                    curMax = 0;
                }
            }
            if (max < curMax)
                max = curMax;
            return max;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var result = sol.FindMaxConsecutiveOnes(new int[] { 1});
            Console.WriteLine(result);
        }
    }
}
