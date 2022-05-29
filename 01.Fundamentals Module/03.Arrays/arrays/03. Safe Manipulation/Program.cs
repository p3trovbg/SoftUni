using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _03._Safe_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] exist = new string[array.Length];
            int countDistinct = 1;
            int countReverse = 1;
            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split();
                if (command[0] == "END")
                {
                    break;
                }
                else if (command[0] == "Distinct")
                {
                    exist = array.Distinct().ToArray();
                    array = exist;
                    if (countDistinct == 1)
                    {
                        countDistinct += 1;
                        Console.WriteLine("Invalid input!");
                    }
                    
                }
                else if (command[0] == "Reverse")
                {
                  
                    exist = array.Reverse().ToArray();
                    array = exist;
                    if (countReverse == 1)
                    {
                        countReverse += 1;
                        Console.WriteLine("Invalid input!");
                    }
                   
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    if (index >= array.Length || index < 0)
                    {
                        continue;
                    }
                    array[index] = command[2];
                    exist = array;
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
