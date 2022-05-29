using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            double result = Area(first, second);
            Console.WriteLine(result);
        }
        static double Area(double one, double two)
        {
            double result = 0;
            return result = one * two;
        }
    }
}
