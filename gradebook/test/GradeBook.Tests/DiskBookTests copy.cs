namespace GradeBook.Tests
{
    public class DiskBookTests : BookTests
    {
        protected override IBook CreateBook(string name)
        {
            return new DiskBook(name);
        }
    }
}