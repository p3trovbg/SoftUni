using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _06._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>(); 
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] parts = input.Split();
                string serialNumber = parts[0];
                string item = parts[1];
                int itemQuantity = int.Parse(parts[2]);
                double price = double.Parse(parts[3]);
                double priceForBox = itemQuantity * price;

                Item current = new Item()
                {
                    Name = item,
                    Price = price
                };

                Box currentBox = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = current,
                    ItemQuantity = itemQuantity,
                    PriceForBox = priceForBox

                };
                boxes.Add(currentBox);
            }
            List<Box> sorted = boxes.OrderByDescending(item => item.PriceForBox).ToList();

            foreach (Box box in sorted)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item{ get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }

    }
}
