using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            IsResult(text, sb);
        }

        private static void IsResult(string[] text, StringBuilder sb)
        {
            foreach (var word in text)
            {
                bool flag = false;
                if (word.Length < 3 || word.Length > 16)
                {
                    continue;
                }

                for (int i = 0; i < word.Length; i++)
                {
                    char currentChar = word[i];
                    if (char.IsLetterOrDigit(currentChar) ||
                        currentChar == '-' ||
                        currentChar == '_')
                    {
                        continue;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    sb.AppendLine(word);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
