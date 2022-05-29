using System;
using System.Collections.Generic;
namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Person> persons = new HashSet<Person>();
            SortedSet<Person> sortedPersons = new SortedSet<Person>();
            
            for (int i = 0; i < n; i++)
            {
                string[] dataPerson = Console.ReadLine().Split();
                string name = dataPerson[0];
                int age = int.Parse(dataPerson[1]);
                Person currentPerson = new Person(name, age);
                persons.Add(currentPerson);
                sortedPersons.Add(currentPerson);
            }

            Console.WriteLine(sortedPersons.Count);
            Console.WriteLine(persons.Count);
        }
    }
}
