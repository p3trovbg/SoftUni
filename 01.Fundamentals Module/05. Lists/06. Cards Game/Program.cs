using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var secondPlayer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int limit = secondPlayer.Count;
            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                int first = firstPlayer[0];
                int second = secondPlayer[0];

                if (first > second)
                {
                    firstPlayer.Add(second);
                    firstPlayer.Add(first);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (first < second)
                {
                    secondPlayer.Add(first);
                    secondPlayer.Add(second);
                    secondPlayer.RemoveAt(0);
                    firstPlayer.RemoveAt(0);
                }
                else if (first == second)
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }

            if (firstPlayer.Sum() > secondPlayer.Sum())
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
    }
}
