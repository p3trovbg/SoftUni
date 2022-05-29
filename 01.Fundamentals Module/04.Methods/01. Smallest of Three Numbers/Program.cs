using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = SmallestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(result);
        }

        static int SmallestNumber(int first, int second, int third)
        {
            int minValue = int.MaxValue;
            if (minValue > first)
            {
                minValue = first;
            }
            
            if (minValue > second)
            {
                minValue = second;
            }
            
            if (minValue > third)
            {
                minValue = third;
            }
            return minValue;
        }
    }
}
