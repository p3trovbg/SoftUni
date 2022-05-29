using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public int Health { get; set; }
        public int Mana { get; set; }

        public Hero( int health, int mana)
        {
            Health = health;
            Mana = mana;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] dataHero = Console.ReadLine().Split();
                string name = dataHero[0];
                int hp = int.Parse(dataHero[1]);
                int mana = int.Parse(dataHero[2]);
                if (hp > 100 || mana > 200)
                {
                    continue;
                }
                heroes.Add(name, new Hero(hp, mana));
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" - ");
                string operation = commands[0];
                string heroName = commands[1];
                switch (operation)
                {
                    case "CastSpell":
                        //{hero name} – {MP needed} – {spell name} 
                        int mana = int.Parse(commands[2]);
                        string spell = commands[3];

                        if (heroes[heroName].Mana >= mana)
                        {
                            heroes[heroName].Mana -= mana;
                            Console.WriteLine($"{heroName} has successfully cast {spell} and now has {heroes[heroName].Mana} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
                        }
                        break;

                    case "TakeDamage":
                        //TakeDamage – {hero name} – {damage} – {attacker}
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];
                        heroes[heroName].Health -= damage;
                        if (heroes[heroName].Health > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].Health} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        }
                        break;

                    case "Recharge":
                        //Recharge – {hero name} – {amount}
                        int amount = int.Parse(commands[2]);
                        int addedAmount = 0;
                        if (heroes[heroName].Mana + amount > 200)
                        {
                            addedAmount = heroes[heroName].Mana - 200;
                            heroes[heroName].Mana = 200;
                            
                        }
                        else
                        {
                            heroes[heroName].Mana += amount;
                            addedAmount = amount;
                        }
                        Console.WriteLine($"{heroName} recharged for {Math.Abs(addedAmount)} MP!");
                        break;

                    case "Heal":
                        //Heal – {hero name} – {amount}
                        int addHealth = int.Parse(commands[2]);
                        int addedHealth = 0; 
                        if (heroes[heroName].Health + addHealth > 100)
                        {
                            addedHealth = heroes[heroName].Health - 100;
                            heroes[heroName].Health = 100;
                        }
                        else
                        {
                            heroes[heroName].Health += addHealth;
                            addedHealth = addHealth;
                        }

                        Console.WriteLine($"{heroName} healed for {Math.Abs(addedHealth)} HP!");
                        break;
                }
            }

            heroes = heroes.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var nameHero in heroes)
            {
                Console.WriteLine(nameHero.Key);
                Console.WriteLine($"  HP: {nameHero.Value.Health}");
                Console.WriteLine($"  MP: {nameHero.Value.Mana}");
            }
        }
    }
}
