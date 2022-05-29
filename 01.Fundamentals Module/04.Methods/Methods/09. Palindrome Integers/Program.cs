using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string originalNumber = input;
                string currentNumber = "";
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    currentNumber += input[i];
                }

                if (currentNumber == originalNumber)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

            }
        }
    }
}
