using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();
            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {

                string[] operations = input.Split();
                string command = operations[0];
                string commandCriteria = operations[1];
                string param = operations[2];
                Predicate<string> predicate = GetCriteria(commandCriteria, param);

                if (command == "Double")
                {
                    List<string> searchNames = names.FindAll(predicate);
                    if (searchNames.Any())
                    {
                        int idx = searchNames.FindIndex(predicate);
                        names.InsertRange(idx, searchNames);
                    }
                }
                else if (command == "Remove")
                {
                    names.RemoveAll(predicate);
                }
            }

            if (names.Any())
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static Predicate<string> GetCriteria(string command, string param)
        {
            if (command == "StartsWith")
            {
                return x => x.StartsWith(param);
            }
            else if (command == "EndsWith")
            {
                return x => x.EndsWith(param);
            }

            int length = int.Parse(param);
            return x => x.Length == length;
        }
    }
}
