using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SchoolTeams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetOwner[] petOwners =
       { new PetOwner { Name="Higa, Sidney",
              Pets = new List<string>{ "Scruffy", "Sam", "Gosho" } },
          new PetOwner { Name="Ashkenazi, Ronen",
              Pets = new List<string>{ "Walker", "Sugar", "Bobcho" } },
          new PetOwner { Name="Price, Vernette",
              Pets = new List<string>{ "Scratches", "Diesel", "Minko" } } };

            // Query using SelectMany().
            IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);

            // Only one foreach loop is required to iterate
            // through the results since it is a
            // one-dimensional collection.
            foreach (string pet in query1)
            {
                Console.WriteLine(pet);
            }
        }
    }
}


class PetOwner
{
    public string Name { get; set; }
    public List<String> Pets { get; set; }
}

