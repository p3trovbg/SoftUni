using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personInfo = input.Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];
                var person = new Person(name, age, town);
                persons.Add(person);
            }
            //"{count of matches} {number of not equal people} {total number of people}"
            int countOfMatches = 0;
            int countOfNotEqualPeople = 0;
            int idx = int.Parse(Console.ReadLine());
            foreach (var person in persons)
            {
                if (person.CompareTo(persons[idx - 1]) == 1 || person.CompareTo(persons[idx - 1]) == -1)
                {
                    countOfNotEqualPeople++;
                }              
                else
                {
                    countOfMatches++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {countOfNotEqualPeople} {persons.Count}");
            }
        }
    }
}
