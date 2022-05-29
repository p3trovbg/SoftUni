using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var theClothes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] dataClothes = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = dataClothes[0];
                string[] allClothes = dataClothes[1].Split(",");

                for (int j = 0; j < allClothes.Length; j++)
                {
                    if (!theClothes.ContainsKey(color))
                    {
                        theClothes.Add(color, new Dictionary<string, int>());
                    }

                    string clothes = allClothes[j];
                    if (!theClothes[color].ContainsKey(clothes))
                    {
                        theClothes[color].Add(clothes, 0);
                    }

                    theClothes[color][clothes]++;
                }
            }

            string[] currentClothes = Console.ReadLine().Split(" ");
            string currColor = currentClothes[0];
            string currClothes = currentClothes[1];
            foreach (var clothes in theClothes)
            {
                Console.WriteLine($"{clothes.Key} clothes:");
                foreach (var type in clothes.Value)
                {
                    if (clothes.Key == currColor && type.Key == currClothes)
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value}");
                    }
                }
            }
        }
    }
}