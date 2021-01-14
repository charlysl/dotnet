using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name, GradeAdded)
        {
        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            string fileName = $"{Name}.txt";
            using(var sw = File.AppendText(fileName))
            {
                sw.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
    }
}