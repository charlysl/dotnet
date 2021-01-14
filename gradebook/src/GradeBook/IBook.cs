namespace GradeBook
{
    public interface IBook
    {
        event GradeAddedDelegate GradeAdded;
        void AddGrade(double grade);
        Statistics GetStatistics();
    }
}