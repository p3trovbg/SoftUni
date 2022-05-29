using System;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] commands = input.Split(":|:");
                string operation = commands[0];

                switch (operation)
                {
                    case "InsertSpace":
                        int idx = int.Parse(commands[1]);
                        text = text.Insert(idx, " ");
                        break;
                    case "Reverse":
                        string part = commands[1];
                        if (!text.Contains(part))
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        int index = text.IndexOf(part);
                        text = text.Remove(index, part.Length);
                        part = ReverseText(part);
                        text = text.Insert(text.Length, part);
                        break;
                    case "ChangeAll":
                        string oldPart = commands[1];
                        string newPart = commands[2];
                        text = text.Replace(oldPart, newPart);
                        break;
                }
                Console.WriteLine(text);
            }

            Console.WriteLine($"You have a new text message: {text}");
        }

        private static string ReverseText(string part)
        {
            char[] array = part.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}