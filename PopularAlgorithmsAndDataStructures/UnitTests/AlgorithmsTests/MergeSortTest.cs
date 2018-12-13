using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms;
using DataStructures.Lists;
using Xunit;

namespace UnitTests.AlgorithmsTests
{
    public class MergeSortTest
    {

        [Fact]
        public static void DoTest()
        {
            int[] arr = {12, 11, 13, 5, 6, 7};
            int[] expectedResult = {5, 6, 7, 11, 12, 13};
            MergeSort.Start(arr, 0, arr.Length - 1);

            Assert.True(arr.SequenceEqual(expectedResult));
        }
    }
}
