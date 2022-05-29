using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> family = new List<Person>(n);
            for (int i = 0; i < n; i++)
            {
                string[] dates = Console.ReadLine().Split();
                string name = dates[0];
                int age = int.Parse(dates[1]);
                Person person = new Person(name, age);
                family.Add(person);
            }

            family = family.OrderByDescending(x => x.Age).ToList();
            foreach (var currentPerson in family)
            {
                Console.WriteLine($"{currentPerson.Name} {currentPerson.Age}");
                break;
            }
        }
    }
}
