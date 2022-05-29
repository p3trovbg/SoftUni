using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "end")
                {
                    break;
                }
                Console.WriteLine($"{word} = {ReverseString(word)}");
            }
        }
    }
}
