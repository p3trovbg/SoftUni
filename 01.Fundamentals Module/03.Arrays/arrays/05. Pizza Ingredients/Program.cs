using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine()
                .Split()
                .ToArray();
            int lengthElements = int.Parse(Console.ReadLine());
            
            if (lengthElements <= 0 || lengthElements > 50)
            {
                return;
            }
            List<string> addingIngredeients = new List<string>();
            
            foreach (var items in ingredients)
            {
                if (items.Length == lengthElements)
                {
                    Console.WriteLine($"Adding {items}.");
                    addingIngredeients.Add(items);
                    if (addingIngredeients.Count == 10)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"Made pizza with total of {addingIngredeients.Count} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", addingIngredeients)}.");


        }
    }
}
