using System;
using Xunit;

namespace GradeBook.Tests
{
    public abstract class BookTests
    {
        [Fact]
        public void CanGetStatistics()
        {
            // arrange
            var book = CreateBook("");
            var low = 67.5;
            var high = 90.1;
            var middle = 85.2;
            book.AddGrade(high);
            book.AddGrade(middle);
            book.AddGrade(low);
            var expected = new Statistics();
            expected.low = low;
            expected.high = high;
            expected.average = (low + middle + high) / 3;

            // act
            var actual = book.GetStatistics();

            // assert
            Assert.Equal(expected.low, actual.low, 1);
            Assert.Equal(expected.high, actual.high, 1);
            Assert.Equal(expected.average, actual.average, 1);
        }

        protected abstract IBook CreateBook(string name);
    }
}
