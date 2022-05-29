using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            
            long firstNumber = long.Parse(Console.ReadLine());
            string operations = Console.ReadLine();
            long secondNumber = long.Parse(Console.ReadLine());
            Console.WriteLine(Result(operations, firstNumber, secondNumber));
        }

        static long Result(string operation, long first, long second)
        {
            long sum = 0;
            if (operation == "+")
            {
                sum = first + second;
            }
            else if (operation == "-")
            {
                sum = first - second;
            }
            else if (operation == "*")
            {
                sum = first * second;
            }
            else if (operation == "/")
            {
                sum = first / second;
            }

            return sum;
        }
    }
}
