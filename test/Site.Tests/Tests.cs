using System;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1() 
        {
            var a = 1;
            var b = 1;
            Assert.True(a == b);
        }

        [Fact]
        public void Test2()
        {
            var a = 1;
            var b = 2;
            Assert.True(a != b);
        }

        [Fact]
        public void Test3()
        {
            var a = 5;
            var b = 5;
            Assert.True(a == b);
        }
    }
}
