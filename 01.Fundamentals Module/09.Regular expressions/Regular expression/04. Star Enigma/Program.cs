using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex latters = new Regex(@"[STARstar]");
            Regex encryptedText = new Regex(@"[^:@\-.!:>]*?(?<name>[A-Z][a-z]+)[^:@\-.!:>]*?:(?<population>\d+)[^:@\-.!:>]*?!(?<type>[AD]{1})[^:@\-.!:>]*?!->(?<count>\d+)");
            List<string> attacked = new List<string>();
            List<string> destryoed = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection lattersCount = latters.Matches(input);
                int keyCount = lattersCount.Count;
                string text = GetText(input, keyCount);

                Match dataCollection = encryptedText.Match(text);
                string name = dataCollection.Groups["name"].Value;
                string typeAttack = dataCollection.Groups["type"].Value;

                if (typeAttack == "A")
                {
                    attacked.Add(name);
                }
                else if (typeAttack == "D")
                {
                    destryoed.Add(name);
                }
            }

            Result(attacked, destryoed);
        }

        private static void Result(List<string> attacked, List<string> destryoed)
        {
            var orderAttack = attacked.OrderBy(x => x).ToList();
            Console.WriteLine($"Attacked planets: {orderAttack.Count}");
            foreach (var planet in orderAttack)
            {
                Console.WriteLine($"-> {planet}");
            }
            var destroyAttack = destryoed.OrderBy(x => x).ToList();
            Console.WriteLine($"Destroyed planets: {destroyAttack.Count}");
            foreach (var planet in destroyAttack)
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        private static string GetText(string input, int keyCount)
        {
            var sb = new StringBuilder();
            foreach (var latter in input)
            {
                sb.Append((char)(latter - keyCount));
            }
            return sb.ToString();
        }
    }
}
