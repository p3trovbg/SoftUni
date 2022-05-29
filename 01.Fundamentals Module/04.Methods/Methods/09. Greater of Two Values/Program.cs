using System;
using System.Runtime.ExceptionServices;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string fist = Console.ReadLine();
            string second = Console.ReadLine();
            
            Console.WriteLine(Result(type,fist, second));
        }
        static string Result(string type, string first, string second)
        {
            string sum = "";
            if (type == "long")
            {
                if (long.Parse(first) > long.Parse(second))
                {
                    sum = first;
                }
                else
                {
                    sum = second;
                }
            }

            if (type == "char")
            {
                if (char.Parse(first) > char.Parse(second))
                {
                    sum = first;
                }
                else
                {
                    sum = second;
                }
            }

            if (type == "string")
            {
                if (first.CompareTo(second) >= 0)
                {
                    sum = first;
                }
                else
                {
                    sum = second;
                }
            }
            return sum;
        }
    }
}
