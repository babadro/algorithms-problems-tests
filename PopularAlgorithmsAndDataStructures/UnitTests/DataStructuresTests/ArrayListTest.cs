using System;
using DataStructures.Lists;
using Xunit;

namespace UnitTests
{
    public class ArrayListTest
    {
        [Fact]
        public static void DoTest()
        {
            var dynamicArray = new DynamicArray<long>();

            for (long i = 1; i < 100000; ++i)
                dynamicArray.Append(i);

            Assert.Equal(99999, dynamicArray.ItemsCount);
            Assert.Equal(1, dynamicArray[0]);
            Assert.Equal(99999, dynamicArray[99998]);
        }
    }
}
