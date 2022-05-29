using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            Sign(num);
        }

        static void Sign(double number)
        {
            string sign = null;
           if (number >= 2.00 && number <= 2.99)
            {
                sign = "Fail";
            }
            else if (number >= 3.00 && number <= 3.49)
            {
                sign = "Poor";
            }
            else if (number >= 3.50 && number <= 4.49)
            {
                sign = "Good";
            }
            else if (number >= 4.50 && number <= 5.49)
            {
                sign = "Very good";
            }
            else if (number >= 5.50 && number <= 6.00)
            {
                sign = "Excellent";
            }

            Console.WriteLine(sign);
        }
    }
}
