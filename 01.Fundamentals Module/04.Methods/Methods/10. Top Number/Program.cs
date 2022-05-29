using System;
using System.ComponentModel;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsTopNumber(int num)
        {
            return IsDivisbleBy(num, 8) && ContainsOddDigit(num);
        }
        static bool ContainsOddDigit(int num)
        {
            while (num != 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 != 0)
                {
                    return true;
                }
                num /= 10;
            }

            return false;
        }
        static bool IsDivisbleBy(int num, int divider)
        {
            int sum = 0;
            while (num != 0)
            {
                int lastDigit = num % 10;
                sum += lastDigit;
                num /= 10;
            }

            return sum % divider == 0;
        }

    
    }
}
