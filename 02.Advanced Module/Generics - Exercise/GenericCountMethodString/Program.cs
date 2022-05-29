using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> digits = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                Box<double> currentBox = new Box<double>(double.Parse(Console.ReadLine()));
                digits.Add(currentBox);
            }

            Console.WriteLine(Filter(digits, double.Parse(Console.ReadLine())));
        }

        static int Filter<T>(List<Box<T>> list, T item)
            where T : IComparable
        {
            return list.Count(x => x.Input.CompareTo(item) > 0);
        }
        
    }
}
