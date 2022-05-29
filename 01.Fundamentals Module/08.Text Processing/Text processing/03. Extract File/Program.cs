using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string[] result = file[file.Length - 1].Split(".", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"File name: {result[0]}");
            Console.WriteLine($"File extension: {result[1]}");
        }
    }
}
