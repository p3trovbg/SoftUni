using System;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] limits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int numberBomb = limits[0];
            int diazapone = limits[1];

            //1 2 2 4 2 2 2 9
            //4 2

            for (int i = 0; i < numbers.Count; i++)
            {
                int indexBomb = numbers.IndexOf(numbers[i]);
                if (numbers[i] == numberBomb)
                {
                    //Когато силата на бомбата е нулево разстояние.
                    if (diazapone == 0)
                    {
                        int count = numbers.Where(x => x == numberBomb).Count();
                        for (int j = 0; j < count; j++)
                        {
                            numbers.Remove(numberBomb);
                        }
                        break;
                    }

                    int startIndex = indexBomb - diazapone;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    int endIndex = indexBomb + diazapone;
                    if (endIndex >= numbers.Count)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    int counts = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, counts);

                }
            }

            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
