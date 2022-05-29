using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            byte multiply = byte.Parse(Console.ReadLine());
            List<string> result = new List<string>();
            if (multiply == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int reminder = 0;
            for (int i = number.Length -1 ; i >= 0; i--)
            {
                int digit = number[i] - '0';
                digit *= multiply;

                if (reminder > 0)
                {
                    digit += reminder;
                    reminder = 0;
                }
                if (digit > 9)
                {
                    string stringDigit = digit.ToString();
                    result.Add(stringDigit[1].ToString());
                    reminder = stringDigit[0] - '0';
                }
                else
                {
                    result.Add(digit.ToString());
                }
            }
            if (reminder > 0)
            {
                result.Add(reminder.ToString());
            }

            result.Reverse();
            Console.WriteLine(string.Concat(result));
        }
    }
}
