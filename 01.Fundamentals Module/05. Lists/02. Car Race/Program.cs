using System;
using System.Linq;

namespace car_racer
{
    class Program
    {
        static void Main(string[] args)
        {
            var race = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            var limit = race.Count / 2;
            double leftSum = 0;
            double rightSum = 0;
            for (int i = 0; i < limit; i++)
            {
                if (race[i] == 0)
                {
                    leftSum -= leftSum * 0.20;
                }
                else
                {
                    leftSum += race[i];
                }

            }

            for (int i = race.Count - 1; i > limit; i--)
            {
                if (race[i] == 0)
                {
                    rightSum -= rightSum * 0.20;
                }
                else
                {
                    rightSum += race[i];
                }
            }

            if (leftSum > rightSum)
            {
                Console.WriteLine($"The winner is right with total time: {rightSum}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {leftSum}");
            }

        }
    }
}