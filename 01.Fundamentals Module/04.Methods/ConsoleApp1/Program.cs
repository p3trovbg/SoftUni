using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thirth = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int onePerHour = one + second + thirth;

            int hours = (int)Math.Ceiling(students / (double)onePerHour);
           
            else
            {
                hours += hours / 3;
                Console.WriteLine($"Time needed: {hours}h.");
            }
            
            



        }
    }
}
