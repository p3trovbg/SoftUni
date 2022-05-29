using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();          
            int maxCounter = 0;
            int sequnceNumber = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                int counter = 1;
                for (int j = i + 1; j < arry.Length; j++)
                {                   
                    if (arry[i] == arry[j])
                    {
                        counter += 1;                       
                    }
                    else
                    {                      
                        break;
                    }                     
                }
                if (counter > maxCounter)
                {
                    sequnceNumber = arry[i];
                    maxCounter = counter;
                }
            }
            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write($"{sequnceNumber} ");
            }
        }
    }
}

