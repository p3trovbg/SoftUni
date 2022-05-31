using System;

namespace _01._Reverse_Array
{
    class Program
    {
        private static string[] arr;
        static void Main(string[] args)
        {  
            arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ReverseArray(0);
        }

        private static void ReverseArray(int idx)
        {
          if(idx == arr.Length / 2)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            var temp = arr[idx];
            arr[idx] = arr[arr.Length - 1 - idx];
            arr[arr.Length - 1 - idx] = temp;
            
            ReverseArray(idx + 1);
        }
    }
}
 