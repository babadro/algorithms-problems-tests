using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_BinarySearchAlgorithm_01_MinMaxDivision
{
    class Solution
    {
        int BlocksNo(int[] A, int maxBlock)
        {
            // Initially set the A[0] being an individual block.
            // The number of blocks, that A could be divided to with the restriction that, the sum of each block is less than or equal to maxBlock
            var blocksNumber = 1;
            var preBlockSum = A[0]; 
            for (var i = 1; i < A.Length; i++)
            {
                var element = A[i];
                // Try to extend the previous block
                if (preBlockSum + element > maxBlock)
                {
                    // Fail to extend the previous block, becaus of the sum limitation maxBlock
                    preBlockSum = element;
                    blocksNumber += 1;
                }
                else
                    preBlockSum += element;
            }
            return blocksNumber;
        }
        public int solution(int K, int M, int[] A)
        {
            var resultLowerBound = A.Max();
            var resultUpperBound = A.Sum();
            var result = 0; // Minimal large sum

            // Handle two special cases
            if (K == 1)
                return resultUpperBound;
            if (K >= A.Length)
                return resultLowerBound;

            // Binary search the result:
            while (resultLowerBound <= resultUpperBound)
            {
                var resultMaxMid = (resultLowerBound + resultUpperBound) / 2;
                var blocksNeeded = BlocksNo(A, resultMaxMid); // Given the restriction on the sum of each block, how many blocks could the original A be divided to?
                if (blocksNeeded <= K)
                {
                    // With large sum being resultMaxMid or resultMaxMid-, we need bloksNeeded/blocksNeeded- blocks.
                    // While we have some unused blocks (K - blocksNeeded), We could try to use them to decrease the large sum.
                    resultUpperBound = resultMaxMid - 1;
                    result = resultMaxMid;
                }
                else // With large sum being resultMaxMid or resultMaxMid-, we need to use more than K blocks. So resultMaxMid is impossible to be our answer.
                    resultLowerBound = resultMaxMid + 1;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
