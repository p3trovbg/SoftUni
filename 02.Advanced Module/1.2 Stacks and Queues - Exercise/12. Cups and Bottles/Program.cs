using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var queueCups = new Queue<int>(cups);
            var stackBottles = new Stack<int>(bottles);
            int wastedLiters = 0;

            while (queueCups.Count > 0 && stackBottles.Count > 0)
            {
                int currentCup = queueCups.Peek();
                int currentBottle = stackBottles.Peek();

                if (currentBottle < currentCup)
                {
                    while (currentCup > 0)
                    {
                        int bottle = stackBottles.Pop();
                        if (bottle >= currentCup)
                        {
                            wastedLiters += bottle - currentCup;
                            queueCups.Dequeue();
                            break;
                        }
                        else
                        {
                            currentCup -= bottle;
                        }

                    }
                }
                else if (currentBottle >= currentCup)
                {
                    wastedLiters += currentBottle - currentCup;
                    queueCups.Dequeue();
                    stackBottles.Pop();
                }

            }

            //Result
            Result(queueCups, stackBottles, wastedLiters);

        }

        private static void Result(Queue<int> queueCups, Stack<int> stackBottles, int wastedLiters)
        {
            if (queueCups.Count > 0)
            {
                queueCups.ToArray();
                Console.WriteLine($"Cups: {string.Join(" ", queueCups)}");
                Console.WriteLine($"Wasted litters of water: {wastedLiters}");
            }
            else
            {
                stackBottles.ToArray();
                Console.WriteLine($"Bottles: {string.Join(" ", stackBottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedLiters}");
            }
        }
    }
}
