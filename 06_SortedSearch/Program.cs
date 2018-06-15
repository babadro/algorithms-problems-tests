using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _06_SortedSearch
{
    public class SortedSearch
    {
        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            if (sortedArray.Length == 0)
                return 0;
            if (sortedArray.Length == 1)
                return sortedArray[0] < lessThan ? 1 : 0;
            
                

            var startIdx = 0;
            var endIdx = sortedArray.Length - 1;
            while (true)
            {
                var middleIdx = (endIdx + startIdx) / 2;
                if (sortedArray[middleIdx] == lessThan)
                    return middleIdx;

                if (endIdx - startIdx == 1)
                {
                    if (sortedArray[startIdx] > lessThan)
                        return startIdx;
                    if (sortedArray[endIdx] > lessThan)
                        return endIdx;
                    return endIdx + 1;
                }

                if (sortedArray[middleIdx] > lessThan)
                    endIdx = middleIdx - 1;
                else if (sortedArray[middleIdx] < lessThan)
                    startIdx = middleIdx + 1;
            }
            /*
            if (sortedArray[middleIdx] == lessThan)
                return middleIdx;
            if (sortedArray[middleIdx] < lessThan)
            {
                var newArr = new int[sortedArray.Length - (middleIdx + 1)];
                Array.Copy(sortedArray, middleIdx + 1, newArr, 0, newArr.Length);
                return CountNumbers(newArr, lessThan);
            }*/

        }

        public static void Main(string[] args)
        {
            Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7, 11, 12, 14, 20, 24, 25, 26 }, 27));
            Console.ReadLine();
        }
    }
}
