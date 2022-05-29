using System;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            long sum = 0;

            while (numbers.Count > 0)
            {
                long currentNumber = 0;
                bool flag = true;
                int idx = int.Parse(Console.ReadLine());
                //Ако даденият индекс е по-малък от 0, премахнете първия елемент от последователността и копирайте последния елемент на мястото му.
                if (idx < 0)
                {
                    flag = false;
                    idx = 0;
                    currentNumber = numbers[idx];
                    numbers.RemoveAt(0);
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                }
                else if (idx >= numbers.Count)
                {
                    flag = false;
                    idx = numbers.Count - 1;
                    currentNumber = numbers[idx];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(numbers[0]);
                }

                
                sum += currentNumber;
                if (flag)
                {
                    currentNumber = numbers[idx];
                    sum += currentNumber;
                    numbers.RemoveAt(idx);
                }

                //Трябва да увеличите стойността на всички елементи в последователността, които са по-малки или равни на премахнатия елемент
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= currentNumber)
                    {
                        numbers[i] += currentNumber;
                    }

                    else if (numbers[i] > currentNumber)
                    {
                        numbers[i] -= currentNumber;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
