using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            PersonName = name;
            Id = id;
            Age = age;
        }
        public string PersonName { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{PersonName} with ID: {Id} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> currentPerson = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] dates = input.Split();
                string name = dates[0];
                string id = dates[1];
                int age = int.Parse(dates[2]);
                Person person = new Person(name, id, age);
                currentPerson.Add(person);
            }

            List<Person> result = currentPerson.OrderBy(x => x.Age).ToList();

            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
        }
    }
}
