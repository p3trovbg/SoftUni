using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenSeconds = int.Parse(Console.ReadLine());
            int greenWindow = int.Parse(Console.ReadLine());
            int count = 0;
            bool existCrash = false;
            
            var myQueue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                { 
                    break;
                }

                if (input == "green")
                {
                    int seconds = greenSeconds;
                    int window = greenWindow;
                    while (myQueue.Count > 0 && seconds > 0)
                    {
                        string car = myQueue.Dequeue();
                        seconds -= car.Length;

                        if (seconds > 0)
                        {
                            count++;
                        }
                        else
                        {
                            window += seconds;
                            if (window < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + window]}.");
                                return;
                            }
                            else
                            {
                                count++;
                            }
                        }
                    }
                }
                else
                {
                    myQueue.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");

        }
    }
}
