using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<IBaseHero> list = new List<IBaseHero>();
            while (list.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid":
                        list.Add(new Druid(name));
                        break;
                    case "Paladin":
                        list.Add(new Paladin(name));
                        break;
                    case "Rogue":
                        list.Add(new Rogue(name));
                        break;
                    case "Warrior":
                        list.Add(new Warrior(name));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

            }

            int healthBoss = int.Parse(Console.ReadLine());
            int totalDamage = 0;
            foreach (var hero in list)
            {
                Console.WriteLine(hero.CastAbility());
                totalDamage += hero.Power;
            }

            if (totalDamage >= healthBoss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
