using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] currentPerson = input.Split();
                string firstName = currentPerson[0];
                string lastName = currentPerson[1];
                int age = int.Parse(currentPerson[2]);
                decimal salary = decimal.Parse(currentPerson[3]);

                persons.Add(new Person(firstName, lastName, age, salary));
            }
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
