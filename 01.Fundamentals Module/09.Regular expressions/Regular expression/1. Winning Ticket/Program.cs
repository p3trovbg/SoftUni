using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _01._Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string[] inputs = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            //Regex 
            Regex wordRegex = new Regex(@"[\$\@\^\#]{6,10}");
            int sum = 0;
            foreach (var word in inputs)
            {
                if (word.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                //Collection with signs.
                MatchCollection signCollection = wordRegex.Matches(word);

                //Chek for counts on collections and even whether signs are same.
                if (signCollection.Count != 2 || !isSame(signCollection))
                {
                    Console.WriteLine($"ticket \"{word}\" - no match");
                    continue;
                }


                //Get collection with smaller counts.
                sum = signCollection.Min(x => x.Length);

                //Get sign.
                string currentSign = signCollection.Min(x => x.Value.Substring(1, 1).ToString());

                //Result
                Result(sum, word, currentSign);
            }
        }

        private static bool isSame(MatchCollection signCollection)
        {
            string a = signCollection.Min(x => x.Value.Substring(1, 1).ToString());
            string b = signCollection.Max(x => x.Value.Substring(1, 1).ToString());
            if (a == b)
            {
                return true;
            }

            return false;
        }

        private static void Result(int sum, string word, string sign)
        {
            if (sum == 10)
            {
                Console.WriteLine($"ticket \"{word}\" - {sum}{sign} Jackpot!");
            }
            else
            {
                Console.WriteLine($"ticket \"{word}\" - {sum}{sign}");
            }
        }
    }
}