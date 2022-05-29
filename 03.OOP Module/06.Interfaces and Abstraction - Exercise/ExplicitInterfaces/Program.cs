using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);

                var citizen = new Citizen(name, country, age);
                IResident resident = citizen;
                IPerson person = citizen;
                person.GetName();
                resident.GetName();
            }
        }
    }
}
