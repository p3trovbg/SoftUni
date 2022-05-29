using System;
using System.Linq;

namespace _04._Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();
            long sum = 0;
            int index = 0;
            long num = long.Parse(Console.ReadLine());
            //1 3 5 7 12 2 3 5 12
            bool flag = true;
            foreach (var elements in numbers)
            {
                if (elements == num)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if (num >= numbers.Length || !flag)
            {
                Console.WriteLine("No occurrences were found!");
                return;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == num)
                {
                    index = i;
                }
            }

            for (int i = 0; i < index; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}
