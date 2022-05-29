using System;
using System.Reflection;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] arrayFirst = new int[5];
            int[] arraySecond = new int[10];
            var numbers = new EqualityScale<int[]>(arrayFirst, arraySecond);
            Console.WriteLine(numbers.AreEqual());
        }
    }
}
