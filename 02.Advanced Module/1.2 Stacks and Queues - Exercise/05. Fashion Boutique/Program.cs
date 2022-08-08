using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesBox = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var myStack = new Stack<int>(clothesBox);
            int capacity = int.Parse(Console.ReadLine());

            int capacityRack = 0;
            int countRack = 1;

            while (myStack.Count > 0)
            {
                capacityRack += myStack.Peek();

                if (capacityRack <= capacity)
                {
                    myStack.Pop();
                }
                else
                {
                    countRack++;
                    capacityRack = 0;
                }
            }

            Console.WriteLine(countRack);
        }
    }
}