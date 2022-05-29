using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
       
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                string input = Console.ReadLine();

                int sum = 0;
                firstChar += (char) 1;
                for (char i = firstChar; i < secondChar; i++)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (input[j] == i)
                        {
                            sum += i;
                        }
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }