using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> currentStudent = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] date = input.Split();

                string firstName = date[0];
                string lastName = date[1];
                string age = date[2];
                string homeTown = date[3];

                Student student = new Student();
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = homeTown;
                currentStudent.Add(student);
            }

            string city = Console.ReadLine();
            List<Student> current = currentStudent
                .Where(s => s.HomeTown == city)
                .ToList();
            current.Reverse();
            foreach (var student in current)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}

