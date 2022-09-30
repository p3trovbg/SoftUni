using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _16._Knapsack
{
    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            var bag = new List<Item>();

            ReadInput(bag);

            var matrix = new int[bag.Count + 1, maxCapacity + 1];
            FillMatrix(bag, matrix);

            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;
            var selectedItems = new SortedSet<string>();
            var totalWeight = 0;
            var totalValue = 0;

            while (row > 0 && col > 0)
            {
                if (matrix[row, col] != matrix[row - 1, col])
                {
                    var item = bag[row - 1];

                    selectedItems.Add(item.Name);
                    totalWeight += item.Weight;
                    totalValue += item.Value;

                    col -= item.Weight;
                }

                row--;
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            foreach (var item in selectedItems)
            {
                Console.WriteLine(item);
            }

        }

        private static void ReadInput(List<Item> bag)
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Split();

                if (inputLine[0] == "end")
                {
                    break;
                }

                bag.Add(new Item
                {
                    Name = inputLine[0],
                    Weight = int.Parse(inputLine[1]),
                    Value = int.Parse(inputLine[2]),
                });
            }
        }

        private static void FillMatrix(List<Item> bag, int[,] matrix)
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                var item = bag[row - 1];
                for (int capacity = 0; capacity < matrix.GetLength(1); capacity++)
                {
                    if (capacity < item.Weight)
                    {
                        matrix[row, capacity] = matrix[row - 1, capacity];
                    }
                    else
                    {
                        matrix[row, capacity] =
                            Math.Max(matrix[row - 1, capacity],
                                     matrix[row - 1, capacity - item.Weight] + item.Value);

                    }
                }
            }
        }
    }
}
