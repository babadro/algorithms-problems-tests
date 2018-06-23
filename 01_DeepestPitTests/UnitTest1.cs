using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_DeepestPitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PitExplorerTest()
        {
            var arr1 = new int[] { };
            var arr2 = new int[] { 1 };
            var arr3 = new int[] { 1, 10 };
            var arr4 = new int[] { 10, 1 };
            var arr5 = new int[] { 2, 0, 1 };
            var arr6 = new int[] { 0, 11, 3, -2, 0, 1, 0, -3, 2, 3 };
            var arr9 = new int[] { 0, 1, 3, -2, 0, 1, 0, -3, 2, 3 };

            var arr7 = new int[] { 1, 0, 0, 0, 0, 0, 10, 20 };
            var arr8 = new int[] { -1, 0, 0, 0, 0, 0, -10, -20 };
            
            var arr10 = new int[] { 7, 3, 3, 1, 7 };
            var arr11 = new int[] { 4, 2, 0, 1, 1, 3 };

            var arr12 = new int[] { 5, 3, 3, 2, 5, 5, 7, 6, 6, 5, 8, 8, 10, 9, 4, 10 }; //6
        }
    }
}
