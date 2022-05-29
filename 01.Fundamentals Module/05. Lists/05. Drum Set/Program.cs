using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> originalDrumSet = new List<int>(drumSet);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Hit it again, Gabsy!")
                {
                    break;
                }

                int damage = int.Parse(input);
                bool flag = false;
                for (int i = 0; i < drumSet.Count; i++)
                {
                    int originalDrum = 0;
                    drumSet[i] -= damage;
                    if (drumSet[i] <= 0)
                    {
                        originalDrum = originalDrumSet[i];
                        if (money >= originalDrum * 3)
                        {
                            drumSet[i] = originalDrum;
                            money -= originalDrum * 3;
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            originalDrumSet.RemoveAt(i);
                            i--;
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}
