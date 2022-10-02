using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Road_Trip
{
    public class Item
    {
        public Item(int value, int amount)
        {
            Value = value;
            Amount = amount;
        }

        public int Value { get; set; }

        public int Amount { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var amounts = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxCapacity = int.Parse(Console.ReadLine());

            var items = new List<Item>();
            for (int idx = 0; idx < values.Length; idx++)
            {
                var amount = amounts[idx];
                var value = values[idx];
                items.Add(new Item(value, amount));
            }

            var table = new int[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < table.GetLength(0); row++)
            {
                var item = items[row - 1];
                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < item.Amount)
                    {
                        table[row, capacity] = table[row - 1, capacity];
                    }
                    else
                    {
                        table[row, capacity] = Math.Max(table[row - 1, capacity],
                                                        table[row - 1, capacity - item.Amount] + item.Value);
                    }
                }
            }

            Console.WriteLine($"Maximum value: {table[items.Count, maxCapacity]}");
        }
    }
}
