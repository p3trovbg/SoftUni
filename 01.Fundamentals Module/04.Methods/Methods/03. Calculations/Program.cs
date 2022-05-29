using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            long firstNum = long.Parse(Console.ReadLine());
            long secondNum = long.Parse(Console.ReadLine());
            Console.WriteLine(Result(command, firstNum, secondNum));
        }

        static long Result(string command, long first, long second)
        {
            long result = 0;
            if (command == "add")
            {
                result = first + second;
            }
            else if (command == "multiply")
            {
                result = first * second;
            }
            else if (command == "subtract")
            {
                result = first - second;
            }
            else if (command == "divide")
            {
                result = first / second;
            }

            return result;
        }
    }
}
