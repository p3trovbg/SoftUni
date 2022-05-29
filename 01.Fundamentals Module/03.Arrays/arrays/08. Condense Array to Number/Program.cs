using System;
using System.Linq;
namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();               
            int finalResult = 0;                      
            if (num.Length == 1)
            {
                finalResult = num[0];
            }
            int firstLength = num.Length - 1;
            for (int i = 0; i < firstLength; i++)
            {
                int[] modifiedArray = new int[num.Length - 1];
                for (int j = 0; j < modifiedArray.Length; j++)
                    modifiedArray[j] = num[j] + num[j + 1];
                     num = modifiedArray;
                     finalResult = modifiedArray[0];
            }
            Console.WriteLine(finalResult);
        }
    }
}
