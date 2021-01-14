using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Scott");

            InputGrades(book);

            Statistics statistics = book.GetStatistics();

            System.Console.WriteLine($"For the book named {book.Name}");
            System.Console.WriteLine($"The highest grade is {statistics.high}");
            System.Console.WriteLine($"The lowest grade is {statistics.low}");
            System.Console.WriteLine($"The average grade is {statistics.average:N1}");
        }

        private static void InputGrades(IBook book)
        {
            Console.WriteLine("Enter grades (q to end):");
            while(true)
            {
                var line = Console.ReadLine();

                if (line.Equals("q"))
                {
                    break;
                }

                try 
                {
                    var grade = double.Parse(line);

                    switch(grade)
                    {
                        case var g when g > 100:
                            Console.WriteLine("The grade must be at most 100");
                            break;
                        case var g when g < 0:
                            Console.WriteLine("The grade must be at least 0");
                            break;
                        default:
                            book.AddGrade(grade);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
