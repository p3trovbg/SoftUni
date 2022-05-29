using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                int inx;
                int index = 0;
                string parameter = "";
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                //Разделяме входа на отделни команди
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = commands[0];
                if (int.TryParse(commands[1], out inx))
                {
                    index = int.Parse(commands[1]);

                }
                else
                {
                    parameter = commands[1];
                }
                if (commands.Length == 3)
                {
                    parameter = commands[2];
                }
                //Размяна на числа;
                if (operation == "exchange")
                {
                    if (index < numbers.Length && index >= 0)
                    {
                        Exchange(numbers, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                //Проверка за max even/odd number;
                else if (operation == "max")
                {
                    int result = MaxEvenOrOdd(numbers, parameter);
                    if (result < 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }

                }
                //Проверка за min even/odd number;
                else if (operation == "min")
                {
                    int result = MinEvenOrOdd(numbers, parameter);
                    if (result < 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                //Проверка за първите четни или нечетни
                else if (operation == "first")
                {
                    if (index > numbers.Length && index > 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    string result = FirstCountEvenOrOdd(numbers, index, parameter);
                    Console.WriteLine($"[{result}]");
                }
                //Проверка за послдните четни или нечетни
                else if (operation == "last")
                {
                    if (index > numbers.Length && index > 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    string result = LastCountEvenOrOdd(numbers, index, parameter);
                    Console.WriteLine($"[{result}]");
                }
            }
            //Краен резултат
            Console.WriteLine($"[{string.Join(", ", numbers)}]");

        }

        static string LastCountEvenOrOdd(int[] numbers, int index, string parameters)
        {
            int countNumber = 0;
            int count = 0;
            List<int> result = new List<int>(index);
            string res = "";
            bool flag = false;

            if (parameters == "odd")
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    int currentNum = numbers[i];
                    if (numbers[i] % 2 != 0)
                    {
                        count++;
                        flag = true;
                        result.Add(currentNum);
                        if (count == index)
                        {
                            break;
                        }
                    }
                }

                result.Reverse();
                res = string.Join(", ", result);
                if (!flag)
                {
                    res = "";
                }
            }
            else if (parameters == "even")
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    int currentNum = numbers[i];
                    if (numbers[i] % 2 == 0)
                    {
                        flag = true;
                        result.Add(currentNum);
                        if (count == index)
                        {
                            break;
                        }
                    }
                }

                result.Reverse();
                res = string.Join(", ", result);
                if (!flag)
                {
                    res = "";
                }
            }
            return res;
        }
        static string FirstCountEvenOrOdd(int[] numbers, int index, string parameters)
        {
            int count = 0;
            int countNumber = 0;
            List<int> result = new List<int>(index);
            string res = "";
            bool flag = false;
            if (parameters == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int currentNum = numbers[i];
                    if (numbers[i] % 2 != 0)
                    {
                        count++;
                        flag = true;
                        result.Add(currentNum);
                        res = string.Join(", ", result);
                        if (count == index)
                        {
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    res = "";
                }
            }
            else if (parameters == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int currentNum = numbers[i];
                    if (numbers[i] % 2 == 0)
                    {
                        count++;
                        flag = true;
                        result.Add(currentNum);
                        res = string.Join(", ", result);
                        if (count == index)
                        {
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    res = "";
                }
            }
            return res;
        }

        static int MinEvenOrOdd(int[] numbers, string parameters)
        {

            int countNumber = 0;
            int minIndex = 0;
            int minNumber = 0;
            if (parameters == "even")
            {

                countNumber = numbers.Where(x => x % 2 == 0).Count();
                if (countNumber == 0)
                {
                    countNumber = -1;
                    return countNumber;
                }
                else
                {
                    minNumber = numbers.Where(x => x % 2 == 0).Min();
                    minIndex = Array.IndexOf(numbers, minNumber);
                }

            }
            else if (parameters == "odd")
            {

                countNumber = numbers.Where(x => x % 2 != 0)
                    .Count();
                if (countNumber == 0)
                {
                    countNumber = -1;
                    return countNumber;
                }
                else
                {
                    minNumber = numbers.Where(x => x % 2 != 0).Min();
                    minIndex = Array.IndexOf(numbers, minNumber);
                }

            }
            for (int i = minIndex + 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        static int MaxEvenOrOdd(int[] numbers, string parameters)
        {
            int countNumber = 0;
            int maxIndex = 0;
            int maxNumber = 0;
            if (parameters == "even")
            {
                countNumber = numbers.Where(x => (x % 2 == 0)).Count();
                if (countNumber == 0)
                {
                    countNumber = -1;
                    return countNumber;
                }
                else
                {
                    maxNumber = numbers.Where(x => (x % 2 == 0)).Max();
                    maxIndex = Array.IndexOf(numbers, maxNumber);
                }

            }
            else if (parameters == "odd")
            {
                countNumber = numbers.Where(x => (x % 2 != 0)).Count();
                if (countNumber == 0)
                {
                    countNumber = -1;
                    return countNumber;
                }
                else
                {
                    maxNumber = numbers.Where(x => (x % 2 != 0)).Max();
                    maxIndex = Array.IndexOf(numbers, maxNumber);
                }

            }
            for (int i = maxIndex + 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        //[1, 2, 3, 4, 5] -> exchange 2 -> result: [4, 5, 1, 2, 3]
        static void Exchange(int[] numbers, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                int firstNumber = numbers[0];
                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[j - 1] = numbers[j];
                }
                numbers[numbers.Length - 1] = firstNumber;
            }
        }
    }
}