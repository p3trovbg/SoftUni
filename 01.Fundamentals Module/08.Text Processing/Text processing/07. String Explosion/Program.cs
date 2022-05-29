using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var sb = new StringBuilder();
            int range = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (symbol == '>')
                {
                    range += text[i + 1] - '0';
                    sb.Append(symbol);
                }
                else if (range > 0)
                {
                    range -= 1;
                }
                else
                {
                    sb.Append(symbol);
                }
            }
            Console.WriteLine(sb);
        }
    }
}