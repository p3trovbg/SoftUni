using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var sb = new StringBuilder();

            //Extract emojies from text
            Regex regEmoji = new Regex(@"([:]{2}|[*]{2})([A-Z][a-z]{2,})\1");
            MatchCollection emoji = regEmoji.Matches(text);

            //Threshold sum \/
            Regex regThreshold = new Regex(@"\d");
            MatchCollection threshold = regThreshold.Matches(text);

            int thresholdSum = 1;
            foreach (Match digits in threshold)
            {
                int digit = int.Parse(digits.Value);
                thresholdSum = thresholdSum * digit;
            }

           
            Console.WriteLine($"Cool threshold: {thresholdSum}");
            Console.WriteLine($"{emoji.Count} emojis found in the text. The cool ones are:");
            if (emoji.Count < 1)
            {
                return;
            }
            Chek(sb, thresholdSum, emoji);
        }

        private static void Chek(StringBuilder sb, int thresholdSum, MatchCollection emoji)
        {
           
            foreach (Match names in emoji)
            {
                int sum = 0;
                string name = names.Value;
                for (int i = 2; i < name.Length - 2; i++)
                {
                    sum += (char) name[i];
                }

                if (sum > thresholdSum)
                {
                    sb.AppendLine(name);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
