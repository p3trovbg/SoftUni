using System;
using System.Linq;
namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int[] arry = new int[counter];
            for (int i = 0; i < arry.Length; i++)
            {
                arry[i] = int.Parse(Console.ReadLine());                
            }

            for (int i = arry.Length - 1; i >= 0; i--)
            {
                Console.Write($"{arry[i]} ");
            }

        }
    }
}
