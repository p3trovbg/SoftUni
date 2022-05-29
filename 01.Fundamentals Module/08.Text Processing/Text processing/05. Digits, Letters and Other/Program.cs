using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            string digits = string.Empty;
            string latters = string.Empty;
            string symbols = string.Empty;
            for (int element = 0; element < text.Length; element++)
            {
                char currentChar = text[element];
                if (char.IsDigit(currentChar))
                {
                    digits += currentChar;
                }
                else if (char.IsLetter(currentChar))
                {
                    latters += currentChar;
                }
                else
                {
                    symbols += currentChar;
                }
            }
            sb.AppendLine(digits);
            sb.AppendLine(latters);
            sb.AppendLine(symbols);

            Console.WriteLine(sb);
        }
    }
}
