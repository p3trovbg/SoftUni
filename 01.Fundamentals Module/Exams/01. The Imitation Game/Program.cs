using System;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] commands = input.Split('|');
                string operation = commands[0];
                switch (operation)
                {
                    case "ChangeAll":
                        string oldString = commands[1];
                        string newString = commands[2];
                        if (text.Contains(oldString))
                        {
                            text = text.Replace(oldString, newString);
                        }
                        break;
                    case "Insert":
                        int idx = int.Parse(commands[1]);
                        string element = commands[2];

                        if (idx >= 0 && idx <= text.Length)
                        {
                            text = text.Insert(idx, element);
                        }
                        break;
                    case "Move":
                        string newText = string.Empty;
                        int length = int.Parse(commands[1]);
                        if (length < text.Length)
                        {
                            newText = text.Substring(0, length);
                            text = text.Remove(0, length);
                            text = text.Insert(text.Length, newText);
                        }
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {text}");
        }
    }
}