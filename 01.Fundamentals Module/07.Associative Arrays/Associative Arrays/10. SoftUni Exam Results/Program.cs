using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var languages = new SortedDictionary<string, int>();
            var students = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] data = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 2)
                {
                    string bannedName = data[0];
                    students.Remove(bannedName);
                }
                else
                {
                    string name = data[0];
                    string language = data[1];
                    int currentPoints = int.Parse(data[2]);

                    if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                    else
                    {
                        languages.Add(language, 1);
                    }

                    if (students.ContainsKey(name))
                    {
                        if (students[name] < currentPoints)
                        {
                            students[name] = currentPoints;
                        }
                    }
                    else
                    {
                        students.Add(name, currentPoints);
                    }
                }
            }

            //After that print each language, used in the exam, ordered descending by total submission count and then by language name, in the following format:
            var filterStudents = students
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var student in filterStudents)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }

    }
}
