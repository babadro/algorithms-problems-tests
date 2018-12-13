using DataStructures.Lists;
using Xunit;

namespace UnitTests.DataStructuresTests
{
    public class StackTest
    {
        [Fact]
        public static void DoTest()
        {
            var p = new Stack(5);

            p.Push(10);
            p.Push(20);
            p.Push(30);
            Assert.Equal(30, p.Pop());
            Assert.Equal(20, p.Pop());
            Assert.Equal(10, p.Pop());
            Assert.Equal(-1, p.Pop());
        }
    }
}
