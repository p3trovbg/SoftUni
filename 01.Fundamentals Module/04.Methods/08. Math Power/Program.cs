using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double degree = double.Parse(Console.ReadLine());

            double result = MathPower(number, degree);

            Console.WriteLine(result);
        }
        static double MathPower(double num, double degree)
        {
            return Math.Pow(num, degree);
        }
    }
}
