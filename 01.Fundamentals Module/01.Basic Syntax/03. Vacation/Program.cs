using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string week = Console.ReadLine();
            double price = 0;
            double discount = 0;         
            if (typeOfGroup == "Students")
            {
                if (peopleCount >= 30)
                {
                    discount = 15;                  
                }

                if (week == "Friday")
                {
                    price += 8.45;
                }
                else if (week == "Saturday")
                {
                    price += 9.80;
                }
                else if (week == "Sunday")
                {
                    price += 10.46;
                }
            }
            if (typeOfGroup == "Business")
            {
                if (peopleCount >= 100)
                {
                    peopleCount -= 10;
                }
                if (week == "Friday")
                {
                    price += 10.90;
                }
                else if (week == "Saturday")
                {
                    price += 15.60;
                }
                else if (week == "Sunday")
                {
                    price += 16;
                }
            }
            if (typeOfGroup == "Regular")
            {
                if (peopleCount >= 10 && peopleCount <= 20)
                {
                    discount = 5;                   
                }

                if (week == "Friday")
                {
                    price += 15;
                }
                else if (week == "Saturday")
                {
                    price += 20;
                }
                else if (week == "Sunday")
                {
                    price += 22.50;
                }
            }        
            price = price * peopleCount;
            double totalDiscount = price * discount / 100;
            double totalPrice = price - totalDiscount;
            Console.WriteLine($"Total price: {totalPrice:F2}");
           
           
            
            
        }
    }
}
