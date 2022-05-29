using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var course = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                string[] data = input.Split(" : ",StringSplitOptions.RemoveEmptyEntries);
                string nameCourse = data[0];
                string user = data[1];

                if (!course.ContainsKey(nameCourse))
                {
                    course.Add(nameCourse, new List<string>());
                }
                course[nameCourse].Add(user);
            }


            var orderCourse = course
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var currentCourse in orderCourse)
            {
                Console.WriteLine($"{currentCourse.Key}: {currentCourse.Value.Count}");
               currentCourse.Value.Sort();
                foreach (var users in currentCourse.Value)
                {
                    Console.WriteLine($"-- {users}");
                }
            }
        }
    }
}
