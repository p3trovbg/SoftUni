using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new[] {',',' '},StringSplitOptions.RemoveEmptyEntries);
            List<Demon> demons = new List<Demon>();
            foreach (var name in names)
            {
                Regex regName = new Regex(@"[^0-9\+\-\*\.\/]");
                Regex regDmg = new Regex(@"[-+]*\d+\.?\d*");
                Regex regSign = new Regex(@"[\/*]");
                //(excluding numbers (0-9), arithmetic symbols ('+', '-', '*', '/') and delimiter dot ('.')) 
                MatchCollection getName = regName.Matches(name);
                MatchCollection getDmg = regDmg.Matches(name);
                MatchCollection sign = regSign.Matches(name);

                List<double> dmg = getDmg.Select(x => double.Parse(x.Value)).ToList();
                double damage = dmg.Sum();

                int health = GetHealth(getName);
                double totalDamage = GetDamage(damage, sign);

                Demon demon = new Demon(name, health, totalDamage);
                demons.Add(demon);
            }

            foreach (Demon demon in demons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        private static double GetDamage(double damage, MatchCollection signs)
        {
            foreach (Match type in signs)
            {
                string sign = type.Value;
                if (sign == "/")
                {
                    damage /= 2;
                }
                else
                {
                    damage *= 2;
                }
            }

            return damage;
        }

        private static int GetHealth(MatchCollection getName)
        {
            int health = 0;
            foreach (Match latters in getName)
            {
                char latter = char.Parse(latters.Value);
                health += (char)latter;
            }
            return health;
        }
    }
}
