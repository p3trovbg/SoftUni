using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int ages = int.Parse(Console.ReadLine());
            double price = 0;
            bool flag = true;
            if (0 <= ages && ages <= 18)
            {
                if (typeOfDay == "Weekday")
                {
                    price = 12;
                }
                else if (typeOfDay == "Weekend")
                {
                    price = 15;
                }
                else if (typeOfDay == "Holiday")
                {
                    price = 5;
                }
            }

            else if (18 < ages && ages <= 64)
            {
                if (typeOfDay == "Weekday")
                {
                    price = 18;
                }
                else if (typeOfDay == "Weekend")
                {
                    price = 20;
                }
                else if (typeOfDay == "Holiday")
                {
                    price = 12;
                }
            }

            else if (64 < ages && ages <= 122)
            {
                if (typeOfDay == "Weekday")
                {
                    price = 12;
                }
                else if (typeOfDay == "Weekend")
                {
                    price = 15;
                }
                else if (typeOfDay == "Holiday")
                {
                    price = 10;
                }
            }
            else
            {
                Console.WriteLine("Error!");
                flag = false;
            }
            if (flag)
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
