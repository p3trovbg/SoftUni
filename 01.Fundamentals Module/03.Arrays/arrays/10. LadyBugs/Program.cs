
using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            bool[] field = new bool[fieldSize];
            int[] arry = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var item in arry)
            {
                if (item < 0 || item >= field.Length)
                {
                    continue;
                }
                field[item] = true;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] parts = input.Split();
                int index = int.Parse(parts[0]);
                string direction = parts[1];
                int length = int.Parse(parts[2]);
                if (index < 0 || index >= field.Length || !field[index])
                {
                    continue;
                }

                field[index] = false;
                while (true)
                {
                    if (direction == "right")
                    {
                        index += length;
                    }
                    else
                    {
                        index -= length;
                    }

                    if (index >= field.Length || index < 0)
                    {
                        break;
                    }
                    if (!field[index])
                    {
                        field[index] = true;
                        break;
                    }
                }
            }
            foreach (var item in field)
            {
                if (item)
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
        }
    }
}
