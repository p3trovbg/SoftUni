using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Plant_Discovery
{
    class Plant
    {
        public int Rarity { get; set; }
        public List<int> Raiting { get; set; }

        public Plant(int rariry, List<int> raiting)
        {
            Rarity = rariry;
            Raiting = raiting;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, Plant>();
            for (int i = 0; i < n; i++)
            {
                string[] dataPlant = Console.ReadLine().Split("<->");
                string namePlant = dataPlant[0];
                int rarity = int.Parse(dataPlant[1]);
                List<int> raiting = new List<int>();
                if (!plants.ContainsKey(namePlant))
                {
                    plants.Add(namePlant, new Plant(rarity, raiting));
                }
                plants[namePlant].Rarity = rarity;
            }

            string input;
             string[] separators =  { ": ", " - " }; 
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] commands = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string operation = commands[0];
                string name = commands[1];
                if (!plants.ContainsKey(name))
                {
                    Console.WriteLine("error");
                    continue;
                }
                switch (operation)
                {
                    case "Rate":
                        int raiting = int.Parse(commands[2]);
                        plants[name].Raiting.Add(raiting);
                        break;

                    case "Update":
                        int rarity = int.Parse(commands[2]);
                        plants[name].Rarity = rarity;
                        break;

                    case "Reset":
                        plants[name].Raiting.Clear();
                        break;
                }
            }

            //RESULT
            Console.WriteLine("Plants for the exhibition:");
            plants = plants
                .OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Raiting.Count > 0 ? x.Value.Raiting.Average() : 0)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var plant in plants)
            {
                double rating = plant.Value.Raiting.Count > 0 ? plant.Value.Raiting.Average() : 0;
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {rating:F2}");
            }
        }
    }
}
