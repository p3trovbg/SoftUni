using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] operations = input.Split(':');
                string command = operations[0];

                switch (command)
                {
                    case "Add Stop":
                        int idx = int.Parse(operations[1]);
                        string insertText = operations[2];
                        if (idx >= 0 && idx < text.Length)
                        {
                            text = text.Insert(idx, insertText);
                        }
                        break;

                    case "Remove Stop":
                        int startIdx = int.Parse(operations[1]);
                        int count = int.Parse(operations[2]);
                        if (startIdx >= 0 && startIdx < text.Length &&
                            count < text.Length && count >= 0)
                        {
                            int endIdx = count - startIdx + 1;
                            text = text.Remove(startIdx, endIdx);
                        }
                        break;

                    case "Switch":
                        string oldString = operations[1];
                        string newString = operations[2];
                        if (text.Contains(oldString))
                        {
                            text = text.Replace(oldString, newString);
                           
                        }
                        break;
                }
                Console.WriteLine(text);
            }

            //Result
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
