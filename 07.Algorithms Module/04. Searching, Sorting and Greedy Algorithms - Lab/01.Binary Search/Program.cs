using System;
using System.Linq;
namespace _01.Binary_Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int element = int.Parse(Console.ReadLine());

            var result = Binary_Search(input, element);
            Console.WriteLine(result);
        }

        private static int Binary_Search(int[] input, int element)
        {
            int leftPosition = 0;
            int rightPosition = input.Length - 1;

            while (leftPosition <= rightPosition)
            {
                var middle = (leftPosition + rightPosition) / 2;
                if(input[middle] == element)
                {
                    return middle;
                }
                else if(element > input[middle])
                {
                    leftPosition = middle + 1;
                }
                else
                {
                    rightPosition = middle - 1;
                }
            }

            return -1;
        }
    }
}