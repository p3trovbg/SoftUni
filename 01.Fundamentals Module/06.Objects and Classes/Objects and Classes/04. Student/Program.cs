using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students_с
{
    class Student
    {

        public Student(string firstName, string lastName, double grade)
        {
            Name = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}: {Grade:F2}";

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> collect = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);
                Student currentStudent = new Student(firstName, lastName, grade);
                collect.Add(currentStudent);
            }

            List<Student> result = collect.OrderByDescending(x => x.Grade).ToList();
            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

        }
    }
}
