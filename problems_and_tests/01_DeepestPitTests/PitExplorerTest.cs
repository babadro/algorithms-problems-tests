using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_DeepestPit;

namespace _01_DeepestPitTests
{
    [TestClass]
    public class PitExplorerTest
    {
        [TestMethod]
        public void PitCheck()
        {
            var arr1 = new int[] { }; //0
            var arr2 = new int[] { 1 }; //0
            var arr3 = new int[] { 1, 10 }; //0
            var arr4 = new int[] { 10, 1 }; //0
            var arr5 = new int[] { 1, 2, 3 }; //0
            var arr6 = new int[] { 3, 2, 1 }; //0
            var arr7 = new int[] { 3, 2, 4 }; //1
            var arr8 = new int[] { 4, 2, 3 }; //1
            var arr9 = new int[] { 1, 1, 1 }; //0
            var arr10 = new int[] { 3, 2, 4, 6, 2, 1, 7, 8, 5, 4, 7 }; //5
            var arr11 = new int[] { 3, 3, 5, 6, 6, 2, 2, 0, 4, 6, 8, 8, 7, 5, 9, 9 }; //3
            var arr12 = new int[] { 1, 2, 3, 3, 5, 2, 2, 1, 5, 7, 6, 0, -10, 5, 5, 100, 0, 0 }; //15
            var arr13 = new int[] { 0, 11, 3, -2, 0, 1, 0, -3, 2, 3 }; //4
            var arr14 = new int[] { 0, 1, 3, -2, 0, 1, 0, -3, 2, 3 }; //4
            var arr15 = new int[] { 1, 0, 0, 0, 0, 0, 10, 20 };//0
            var arr16 = new int[] { -1, 0, 0, 0, 0, 0, -10, -20 };//0
            var arr17 = new int[] { 7, 3, 3, 1, 7 };//2
            var arr18 = new int[] { 4, 2, 0, 1, 1, 3 };//1
            var arr19 = new int[] { 5, 3, 3, 2, 5, 5, 7, 6, 6, 5, 8, 8, 10, 9, 4, 10 }; //6

            var p = new PitExplorer();

            Assert.AreEqual(0, p.FindDeepestPit(arr1));
            Assert.AreEqual(0, p.FindDeepestPit(arr2));
            Assert.AreEqual(0, p.FindDeepestPit(arr3));
            Assert.AreEqual(0, p.FindDeepestPit(arr4));
            Assert.AreEqual(0, p.FindDeepestPit(arr5));
            Assert.AreEqual(0, p.FindDeepestPit(arr6));
            Assert.AreEqual(1, p.FindDeepestPit(arr7));
            Assert.AreEqual(1, p.FindDeepestPit(arr8));
            Assert.AreEqual(0, p.FindDeepestPit(arr9));
            Assert.AreEqual(5, p.FindDeepestPit(arr10));
            Assert.AreEqual(3, p.FindDeepestPit(arr11));
            Assert.AreEqual(15, p.FindDeepestPit(arr12));
            Assert.AreEqual(4, p.FindDeepestPit(arr13));
            Assert.AreEqual(4, p.FindDeepestPit(arr14));
            Assert.AreEqual(0, p.FindDeepestPit(arr15));
            Assert.AreEqual(0, p.FindDeepestPit(arr16));
            Assert.AreEqual(2, p.FindDeepestPit(arr17));
            Assert.AreEqual(1, p.FindDeepestPit(arr18));
            Assert.AreEqual(6, p.FindDeepestPit(arr19));
        }
    }
}
