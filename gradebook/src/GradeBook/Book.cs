namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name, GradeAddedDelegate gradeAdded) : base(name)
        {
            statistics = new Statistics(gradeAdded);
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public Statistics GetStatistics()
        {
            return statistics;
        }

        Statistics statistics;
    }
}