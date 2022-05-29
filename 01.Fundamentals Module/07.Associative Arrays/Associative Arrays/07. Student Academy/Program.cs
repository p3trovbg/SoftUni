using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double currentGrade = double.Parse(Console.ReadLine());
                if (grades.ContainsKey(name))
                {
                    grades[name].Add(currentGrade);
                }
                else
                {
                    grades.Add(name , new List<double>());
                    grades[name].Add(currentGrade);
                }
            }
            var filteredGrades = grades
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value.Average());

            foreach (var students in filteredGrades)
            {
                Console.WriteLine($"{students.Key} -> {students.Value:F2}");
            }
        }
    }
}
