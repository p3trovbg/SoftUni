using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryMaterials = new Dictionary<string, int>();
            legendaryMaterials.Add("shards", 0);
            legendaryMaterials.Add("fragments", 0);
            legendaryMaterials.Add("motes", 0);

            var junkMaterials = new SortedDictionary<string, int>();
            bool flag = false;
            string legendary = "";
            while (!flag)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (legendaryMaterials.ContainsKey(material))
                    {
                        legendaryMaterials[material] += quantity;
                        if (legendaryMaterials[material] >= 250)
                        {
                            legendaryMaterials[material] -= 250;
                            flag = true;
                            legendary = material;
                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }

            LegenderyMaterial(legendary);

            var filteredMaterial = legendaryMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var kvp in filteredMaterial)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var junkMaterial in junkMaterials)
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }

        private static void LegenderyMaterial(string legendary)
        {
            if (legendary == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (legendary == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (legendary == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
        }
    }
}
