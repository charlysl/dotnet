using System;

namespace GradeBook
{
    public class Statistics
    {
        public double low = double.MaxValue;
        public double high = double.MinValue;

        public double average = 0.0;


        double sum = 0.0;
        int count = 0;
        private GradeAddedDelegate gradeAddedDelegate;

        public Statistics(GradeAddedDelegate gradeAddedDelegate)
        {
            this.gradeAddedDelegate = gradeAddedDelegate;
            gradeAddedDelegate += OnGradeAdded;
        }

        private void OnGradeAdded(object sender, EventArgs args)
        {
            var grade = 0.0;
            high = Math.Max(high, grade);
            low = Math.Min(low, grade);
            sum += grade;
            average = sum / ++count;
        }

    }
}