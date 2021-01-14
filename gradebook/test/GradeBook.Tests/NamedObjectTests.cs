using Xunit;

namespace GradeBook.Tests
{
    public class NamedObjectTests {
        [Fact]
        public void CanGetName()
        {
            var obj = new NamedObject("Name 1");
            var name = obj.Name;
            Assert.Equal("Name 1", name);
        }

        [Fact]
        public void CanSetName()
        {
            var obj = new NamedObject("Name 1");
            obj.Name = "Name 2";
            var name = obj.Name;
            Assert.Equal("Name 2", name);
        }
    }
}