using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            var sb = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }
                char[] text = input.ToCharArray();
                int idx = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    text[i] -= (char)keys[idx];
                    idx++;
                    if (idx == keys.Length)
                    {
                        idx = 0;
                    }
                }
                //"hidden&gold&at<10N70W>"
                string pattern = @".*([&])(?'tr'[a-zA-Z]*)([&]).*([<])(?'coo'.*)([>])";
                string newText = new string(text);

                Regex reg = new Regex(pattern);
                Match mat = reg.Match(newText);
                if (mat.Success)
                {
                    sb.AppendLine($"Found {mat.Groups["tr"]} at {mat.Groups["coo"]}");
                }
            }
            Console.WriteLine(sb);
        }
    }
}