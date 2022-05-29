using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var box = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(", ");
                string operation = data[0];
                string carNumber = data[1];

                if (operation == "IN")
                {
                    box.Add(carNumber);
                }
                else
                {
                    box.Remove(carNumber);
                }
            }
            if (box.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var number in box)
            {
                Console.WriteLine(number);
            }
        }
    }
}