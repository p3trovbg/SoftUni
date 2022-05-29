using System;
using System.Linq;
namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var arry = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)               
                .ToArray();
            var count = int.Parse(Console.ReadLine());          
            for (int i = 0; i < count; i++)
            {
                string firstElement = arry[0];
                for (int j = 1; j < arry.Length; j++)
                {
                    int prevNum = j - 1;
                    arry[prevNum] = arry[j];
                }
                arry[arry.Length - 1] = firstElement;              
            }
            Console.WriteLine(string.Join(' ',arry));
        }
	}  
}
