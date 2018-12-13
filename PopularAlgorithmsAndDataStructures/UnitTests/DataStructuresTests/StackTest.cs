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

            p.push(10);
            p.push(20);
            p.push(30);
            Assert.Equal(30, p.pop());
            Assert.Equal(20, p.pop());
            Assert.Equal(10, p.pop());
            Assert.Equal(-1, p.pop());
        }
    }
}
