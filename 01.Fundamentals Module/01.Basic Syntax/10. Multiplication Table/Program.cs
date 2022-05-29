using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numStart = int.Parse(Console.ReadLine());
            if (numStart > 10)
            {
                Console.WriteLine($"{num} X {numStart} = {num * numStart}");
            }
            for (int i = numStart; i <= 10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }     
        }
    }
}
