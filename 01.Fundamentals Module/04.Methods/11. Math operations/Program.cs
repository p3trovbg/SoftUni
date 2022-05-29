using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstValue = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondValue = int.Parse(Console.ReadLine());
            if (@operator == "+")
            {
                Console.WriteLine(Add(firstValue, @operator, secondValue));
            }
            else if (@operator == "-")
            {
                Console.WriteLine(Substract(firstValue, @operator, secondValue));
            }
            else if (@operator == "*")
            {
                Console.WriteLine(Multiply(firstValue, @operator, secondValue));
            }
            else if (@operator == "/")
            {
                Console.WriteLine(Divide(firstValue, @operator, secondValue));
            }
        }

        static int Add(int first, string @operators, int second)
        {
            return first + second;
        }
        static int Substract(int first, string @operators, int second)
        {
            return first - second;
        }
        static int Multiply(int first, string @operators, int second)
        {
            return first * second;
        }
        static int Divide(int first, string @operators, int second)
        {
            return first / second;
        }
    }
}
