using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double result = 0;
            if (text == "add")
            {
                result = Add(firstNum, secondNum);         
            }
            else if (text == "multiply")
            {
                result = Multiply(firstNum, secondNum);
            }
            else if (text == "substract")
            {
                result = Substract(firstNum, secondNum);
            }
            else if (text == "divide")
            {
                result = Divide(firstNum, secondNum);
            }

            Console.WriteLine(result);
        }
        static double Add(double first, double second)
        {
            return first + second;
        }
        static double Multiply(double first, double second)
        {
            return first * second;
        }
        static double Substract(double first, double second)
        {
            return first - second;
        }
        static double Divide(double first, double second)
        {
            return first / second;

        }
    }
}
