using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name) {
        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade) {
            // System.Console.WriteLine($"Adding grade {grade}");
            grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }


        private List<double> grades = new List<double>();
        
    }
}