using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
                students.Add(student[0], int.Parse(student[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string typeInfo = Console.ReadLine();
            
            switch (condition)
            {
                case "older":
                    students = students.Where(x => x.Value >= age)
                        .ToDictionary(x => x.Key, x => x.Value);
                    break;
                case "younger":
                   students = students.Where(x => x.Value < age)
                        .ToDictionary(x => x.Key, x => x.Value);
                    break;
            }

            Result(typeInfo, students);
        }

        private static void Result(string typeInfo, Dictionary<string, int> students)
        {
            switch (typeInfo)
            {
                case "name age":
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Key} - {student.Value}");
                    }
                    break;
                case "name":
                    foreach (var student in students)
                    {
                        Console.WriteLine(student.Key);
                    }
                    break;
                case "age":
                    foreach (var student in students)
                    {
                        Console.WriteLine(student.Value);
                    }
                    break;
            }
        }
    }
}
