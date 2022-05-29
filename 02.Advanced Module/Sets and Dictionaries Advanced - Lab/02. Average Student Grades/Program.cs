using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < counter; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);

                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, new List<decimal>());
                }
                dictionary[name].Add(grade);
            }

            foreach (var student in dictionary)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => x.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}