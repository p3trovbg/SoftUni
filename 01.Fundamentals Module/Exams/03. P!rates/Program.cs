
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class CityDate
    {
        public int Population { get; set; }
        public int Gold { get; set; }

        public CityDate(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, CityDate>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Sail")
                {
                    break;
                }

                string[] date = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string city = date[0];
                int population = int.Parse(date[1]);
                int gold = int.Parse(date[2]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new CityDate(population, gold));
                }
                else
                {
                    cities[city].Gold += gold;
                    cities[city].Population += population;
                }

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] date = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string theEvent = date[0];
                string town = date[1];
                switch (theEvent)
                {
                    //"Plunder=>{town}=>{people}=>{gold}"
                    case "Plunder":
                        int people = int.Parse(date[2]);
                        int gold = int.Parse(date[3]);

                        cities[town].Population -= people;
                        cities[town].Gold -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            cities.Remove(town);
                        }
                        break;

                    //"Prosper=>{town}=>{gold}"
                    case "Prosper":
                        int golds = int.Parse(date[2]);
                        if (golds < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        else
                        {
                            cities[town].Gold += golds;
                            Console.WriteLine($"{golds} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                        }
                        break;
                }
            }

            cities = cities
                .OrderByDescending(x => x.Value.Gold)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
            }
        }
    }
}