using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            for (int i = 0; i < arry.Length; i++)
            {
                int currentNumber = arry[i];
                int topInteger = 0;
                bool flag = false;
                if (arry.Length - 1 == i)
                {
                    topInteger = currentNumber;
                    flag = true;
                }
                for (int j = i + 1  ; j < arry.Length; j++)
                {
                    int nextNumber = arry[j];
                    if (currentNumber > nextNumber)
                    {
                        topInteger = currentNumber;
                        flag = true;
                    }   
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.Write($"{topInteger} ");
                }              
            } 
        }
    }
}
