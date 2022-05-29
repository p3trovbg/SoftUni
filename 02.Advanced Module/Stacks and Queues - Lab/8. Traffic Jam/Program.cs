using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passedCars = int.Parse(Console.ReadLine());
            var myQueue = new Queue<string>();
            int idx = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    for (int i = 0; i < passedCars; i++)
                    {
                        if (myQueue.Count > 0)
                        {
                            Console.WriteLine($"{myQueue.Dequeue()} passed!");
                            idx++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    myQueue.Enqueue(input);
                }
            }

            Console.WriteLine($"{idx} cars passed the crossroads.");
        }
    }
}
