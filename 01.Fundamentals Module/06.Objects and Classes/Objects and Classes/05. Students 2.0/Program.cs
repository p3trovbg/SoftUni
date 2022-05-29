using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;

namespace _05._Students_2._0
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

                //Chek for same people 
                Student student = currentStudent.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                    if (student == null)
                    {
                        currentStudent.Add(new Student()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Age = age,
                            HomeTown = homeTown,
                        });
                    }
                    else
                    {
                        student.FirstName = firstName;
                        student.LastName = lastName;
                        student.Age = age;
                        student.HomeTown = homeTown;
                    }
            }

            //Read city 
            string city = Console.ReadLine();

            //Chek who living in this city.
            List<Student> current = currentStudent
                .Where(s => s.HomeTown == city)
                .ToList();

            //Print result
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
