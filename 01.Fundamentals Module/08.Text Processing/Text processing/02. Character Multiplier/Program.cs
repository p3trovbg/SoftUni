using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();
            int result = Sum(elements[0], elements[1]);
            Console.WriteLine(result);
        }

        private static int Sum(string first, string second)
        {
            int result = 0;
            int limit = Math.Min(first.Length, second.Length);

            string biggerLength = first.Length >= second.Length ? first : second;
            string smallerLength = biggerLength == first ? second : first;

            for (int i = 0; i < smallerLength.Length; i++)
            {
                int firstValue = biggerLength[i];
                int secondValue = smallerLength[i];
                result += firstValue * secondValue;
            }

            for (int i = limit; i < biggerLength.Length; i++)
            {
                result += biggerLength[i];
            }

            return result;
        }

      
    }
}
