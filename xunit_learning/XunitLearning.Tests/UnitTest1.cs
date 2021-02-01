using System;
using System.Collections.Generic;
using Xunit;

namespace XunitLearning.Tests
{
    public class TheDictionaryShould
    {
        [Fact]
        public void GetAddedPair()
        {
            var sut = new Dictionary<string, int>();
            sut.Add("a", 1);
            Assert.Equal(1, sut["a"]);
        }
    }
}
