using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            var deleteNames = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] operations = input.Split(";");
                string command = operations[0];
                string typeFilter = operations[1];
                string parameter = operations[2];

                Predicate<string> predicate = GetFilter(typeFilter, parameter);
                if (command == "Add filter")
                {
                    deleteNames.AddRange(names.FindAll(predicate)); 
                }
                else if (command == "Remove filter")
                {
                    if (deleteNames.Any())
                    {
                        deleteNames.RemoveAll(predicate);
                    }
                }
            }

            if (deleteNames.Any())
            {
                foreach (var name in deleteNames)
                {
                    names.Remove(name);
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }

        private static Predicate<string> GetFilter(string typeFilter, string parameter)
        {
            switch (typeFilter)
            {
                case "Starts with":
                    return x => x.StartsWith(parameter);
                    break;
                case "Ends with":
                    return x => x.EndsWith(parameter);
                    break;
                case "Length":
                    int length = int.Parse(parameter);
                    return x => x.Length == length;
                    break;
                case "Contains":
                    return x => x.Contains(parameter);
                    break;
            }

            return null;
        }
    }
}
