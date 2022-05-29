using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] operations = input.Split();
                switch (operations[0])
                {
                    case "TakeOdd":
                        string newString = string.Empty;
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                newString += password[i];
                            }
                        }
                        password = newString;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int startIdx = int.Parse(operations[1]);
                        int length = int.Parse(operations[2]);
                        password = password.Remove(startIdx, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string oldElement = operations[1];
                        string newElement = operations[2];
                        if (!password.Contains(oldElement))
                        {
                            Console.WriteLine($"Nothing to replace!");
                            continue;
                        }

                        password = password.Replace(oldElement, newElement);
                        Console.WriteLine(password);
                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
