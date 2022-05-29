using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"@(?<name>[A-Za-z]+)([^\@\-\!\:\>]+)!(?<type>[G|N])!");
            var sb = new StringBuilder();
            while (true)
            {
                string criptMessage = Console.ReadLine();
                if (criptMessage == "end")
                {
                    break;
                }

                string result = Result(criptMessage, key);
                Match names = pattern.Match(result);

                if (names.Groups["type"].Value == "G")
                {
                    sb.AppendLine(names.Groups["name"].Value);
                }
            }

            Console.WriteLine(sb);
        }

        private static string Result(string criptMessage, int key)
        {
            string result = string.Empty;
            for (int i = 0; i < criptMessage.Length; i++)
            {
                result += (char)(criptMessage[i] - key);
            }
            return result;
        }
    }
}