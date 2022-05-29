using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            CharactersInRange(first, second);
        }
        static void CharactersInRange(char first, char second)
        {
            if (first < second)
            {
                for (char i = first; i < second; i++)
                {
                    if (i == first)
                    {
                        continue;
                    }

                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            else
            {
                for (char i = second; i < first; i++)
                {
                    if (i == second)
                    {
                        continue;
                    }

                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }
    }
}
