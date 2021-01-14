using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        delegate string WriteLogDelegate(string message);
        [Fact]
        public void DelegateCanPointToMethod()
        {
            WriteLogDelegate write = ReturnMessage;
            var log = write("A message");
            Assert.Equal("A message", log);
        }
        int count = 0;

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        
        [Fact]
        public void DelegateCanMulticast()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;

            log("A message");

            Assert.Equal(2, count);
        }

    }
}