using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(@#+)(?<text>[A-Z][A-Za-z\d?]{4,}[A-Z])(@#+)");
            int n = int.Parse(Console.ReadLine());
            string newText = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match text = pattern.Match(input);
                if (!text.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                newText = text.Groups["text"].Value;
                bool flag = false;
                string result = string.Empty;
                for (int j = 0; j < newText.Length; j++)
                {

                    if (char.IsDigit(newText[j]))
                    {
                        flag = true;
                        result += newText[j];
                    }
                }

                if (flag)
                {
                    Console.WriteLine($"Product group: {result}");
                }
                else
                {
                    Console.WriteLine($"Product group: 00");
                }
            }
        }
    }
}
