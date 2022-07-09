using System;

namespace _01._Reverse_Array
{
    internal class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            _Reverse_Array(0);
        }

        private static void _Reverse_Array(int idx)
        {
            if(elements.Length / 2 == idx)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Swap(idx);

            _Reverse_Array(idx + 1);
        }

        private static void Swap(int idx)
        {
            var temp = elements[idx];
            elements[idx] = elements[elements.Length - 1 - idx];
            elements[elements.Length - 1 - idx] = temp;
        }
    }
}
