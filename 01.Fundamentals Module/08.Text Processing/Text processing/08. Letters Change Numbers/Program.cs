using System;
using System.Globalization;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            foreach (var elements in text)
            {
                char firstLatter = elements[0];
                char lastLatter = elements[elements.Length - 1];

                double number = double.Parse(elements.Substring(1, elements.Length - 2));

                if (char.IsUpper(firstLatter))
                {
                    number /= firstLatter - 64;
                }
                else
                {
                    number *= firstLatter - 96;
                }

                if (char.IsUpper(lastLatter))
                {
                    number -= lastLatter - 64;
                }
                else
                {
                    number +=  lastLatter - 96;
                }

                result += number;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}
