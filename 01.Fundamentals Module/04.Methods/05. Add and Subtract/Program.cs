using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thirth = int.Parse(Console.ReadLine());
            int result = Sum(first, second);
            Console.WriteLine(Substract(thirth, result));        
        }      
        static int Sum(int first, int second)
        {
            return first + second;
        }
        static int Substract(int thirth, int result)
        {
            return result - thirth;
        }
    }
}
