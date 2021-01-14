namespace GradeBook.Tests
{
    public class InMemoryBookTests : BookTests
    {
        protected override IBook CreateBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}