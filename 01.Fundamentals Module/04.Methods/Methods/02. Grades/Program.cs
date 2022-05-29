using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(Result(number));
        }

        static string Result(long number)
        {
            string result = "";
            if (number >= 2.00 && number < 3.00)
            {
                result = "Fail";
            }
            else if (number >= 3.00 && number < 3.50)
            {
                result = "Poor";
            }
            else if (number >= 3.50 && number < 4.50)

            {
                result = "Good";
            }
            else if (number >= 4.50 && number < 5.50)

            {
                result = "Very good";
            }
            else if (number >= 5.50 && number <= 6.00)

            {
                result = "Excellent";
            }

            return result;
        }
    }
}
