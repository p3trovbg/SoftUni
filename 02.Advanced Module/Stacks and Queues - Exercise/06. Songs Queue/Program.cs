using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            var myQueue = new Queue<string>(songs);

            while (myQueue.Count > 0)
            {
                string[] operations = Console.ReadLine().Split(" ", 2);
                string command = operations[0];
                switch (command)
                {
                    case "Play":
                        myQueue.Dequeue();
                        break;
                    case "Add":
                        string song = operations[1];
                        if (!myQueue.Contains(song))
                        {
                            myQueue.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                            continue;
                        }
                        break;
                    case "Show":
                        string[] allSongs = myQueue.ToArray();
                        Console.WriteLine(string.Join(", ", allSongs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
