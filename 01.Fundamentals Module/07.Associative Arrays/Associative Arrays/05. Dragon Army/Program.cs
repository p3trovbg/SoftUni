using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace _05._Dragon_Army
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var theDragon = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                string type = inputs[0];
                string name = inputs[1];
                IsNull(inputs);
                int damage = int.Parse(inputs[2]);
                int health = int.Parse(inputs[3]);
                int armor = int.Parse(inputs[4]);

                if (!theDragon.ContainsKey(type))
                {
                    theDragon.Add(type, new Dictionary<string, List<string>>());
                }

                if (!theDragon[type].ContainsKey(name))
                {
                    theDragon[type].Add(name, new List<string>());
                }
                else
                {
                    //If exist type and dragon - change stats 
                    theDragon[type][name].RemoveRange(0, 1);
                }

                theDragon[type][name].Add(string.Concat(damage, " ", health, " ", armor));
            }
            Result(theDragon);
        }

        private static void Result(Dictionary<string, Dictionary<string, List<string>>> theDragon)
        {
            foreach (var type in theDragon)
            {
                double[] average = new double[3];
                foreach (var dragon in type.Value.OrderBy(x => x.Key))
                {
                    int[] result = dragon.Value[0].Split(" ").Select(int.Parse).ToArray();
                    average[0] += result[0];
                    average[1] += result[1];
                    average[2] += result[2];
                }
                double damage = average[0] / type.Value.Count;
                double health = average[1] / type.Value.Count;
                double armor = average[2] / type.Value.Count;

                Console.WriteLine($"{type.Key}::({damage:F2}/{health:F2}/{armor:F2})");
                foreach (var dragon in type.Value.OrderBy(x => x.Key))
                {
                    int[] result = dragon.Value[0].Split(" ").Select(int.Parse).ToArray();
                    Console.WriteLine($"-{dragon.Key} -> damage: {result[0]}, health: {result[1]}, armor: {result[2]}");
                }
            }
        }
        private static void IsNull(string[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i] == "null")
                {
                    if (i == 2)
                    {
                        inputs[i] = "45";
                    }
                    else if (i == 3)
                    {
                        inputs[i] = "250";
                    }
                    else if (i == 4)
                    {
                        inputs[i] = "10";
                    }
                }
            }
        }
    }
}
