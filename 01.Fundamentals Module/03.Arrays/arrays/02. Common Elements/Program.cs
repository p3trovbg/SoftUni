using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arryFirst = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var arrySecond = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var firstItem in arrySecond)
            {               
                foreach (var secondItem in arryFirst)
                {
                    if (firstItem == secondItem)
                    {
                        Console.Write($"{secondItem} ");
                    }
                }
            }                    
        }
    }
}
