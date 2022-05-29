using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfInput = Console.ReadLine();
            if (typeOfInput == "int")
            {
                int firstValue = int.Parse(Console.ReadLine());
                int secondValue = int.Parse(Console.ReadLine());
                string result = GetMaxInt(typeOfInput, firstValue, secondValue).ToString();
                Console.WriteLine(result);
            }
            else if (typeOfInput == "char")
            {
                char firstValue = char.Parse(Console.ReadLine());
                char secondValue = char.Parse(Console.ReadLine());
                string result = GetMaxChar(typeOfInput, firstValue, secondValue).ToString();
                Console.WriteLine(result);
            }
            else if (typeOfInput == "string")
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();
                string result = GetMaxString(typeOfInput, firstValue, secondValue);
                Console.WriteLine(result);
            }
        }

        static int GetMaxInt(string type, int first, int second)
        {
            int maxValue = 0;
            switch (type)
            {
                case "int":
                    if (first > second)
                    {
                        maxValue = first;
                    }
                    else if (second > first)
                    {
                        maxValue = second;
                    }
                    break;
            }
            return maxValue;
        }

        static char GetMaxChar(string type, char first, char second)
        {
            char maxValue = ' ';
            switch (type)
            {
                case "char":
                    if (first > second)
                    {
                        maxValue = first;
                    }
                    else if (second > first)
                    {
                        maxValue = second;
                    }
                    break;
            }
            return (char)maxValue;
        }

        static string GetMaxString(string type, string first, string second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
