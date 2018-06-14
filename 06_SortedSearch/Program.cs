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
            var middleIdx = sortedArray.Length / 2;
            if (sortedArray[middleIdx] == lessThan)
                return middleIdx;
            if (sortedArray[middleIdx] < lessThan)
            {
                var newArr = new int[sortedArray.Length - (middleIdx + 1)];
                Array.Copy(sortedArray, middleIdx + 1, newArr, 0, newArr.Length);
                return CountNumbers(newArr, lessThan);
            }
            return 1;

        }

        public static void Main(string[] args)
        {
            Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
        }
    }
}
