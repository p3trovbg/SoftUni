using System;
using System.Linq;
namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string[] arry = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = arry[0];
                if (command == "end")
                {
                    break;
                }
                else if (command == "decrease")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] -= 1;
                        
                    }
                    continue;
                }
                int firstNumber = int.Parse(arry[1]);
                int secondNumber = int.Parse(arry[2]);              
                if (command == "swap")
                {
                    int originalFirstNumber = array[firstNumber];
                    array[firstNumber] = array[secondNumber];
                    array[secondNumber] = originalFirstNumber;
                }
                else if (command == "multiply")
                {
                    array[firstNumber] *= array[secondNumber];
                }
               
            }
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
