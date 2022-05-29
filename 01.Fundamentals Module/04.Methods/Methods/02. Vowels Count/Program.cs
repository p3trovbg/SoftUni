using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine(Vowels(input));
        }

        static long Vowels(string input)
        {
            long count = 0;
            for (long i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        count++;
                        break;
                }
            }

            return count;
        }
    }
}
