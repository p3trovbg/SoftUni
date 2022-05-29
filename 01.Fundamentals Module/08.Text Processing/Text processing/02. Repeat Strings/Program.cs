using System;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string result = String.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                string word = text[i];
                for (int j = 0; j < word.Length; j++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
