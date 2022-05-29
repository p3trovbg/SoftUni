using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

           
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Generate")
                {
                    break;
                }

                string[] operations = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string command = operations[0];
                switch (command)
                {
                    //Contains>>>{substring} 
                    case "Contains":
                        string substring = operations[1];
                        if (key.Contains(substring))
                        {
                            Console.WriteLine($"{key} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                        break;
                    //Flip>>>Upper/Lower>>>{startIndex}>>>{endIndex}
                    case "Flip":
                        string typeOperation = operations[1];
                        int startIdx = int.Parse(operations[2]);
                        int endIdx = int.Parse(operations[3]);
                        int counter = (endIdx - startIdx);
                        string oldSubs = key.Substring(startIdx, counter);
                        if (typeOperation == "Upper")
                        {
                            string newSubs = key.Substring(startIdx, counter).ToUpper();
                            key = key.Replace(oldSubs, newSubs);
                        }
                        else if (typeOperation == "Lower")
                        {
                            string newSubs = key.Substring(startIdx, counter).ToLower();
                            key = key.Replace(oldSubs, newSubs);
                        }

                        Console.WriteLine(key);
                        break;
                    //Slice>>>{startIndex}>>>{endIndex}
                    case "Slice":
                        int startIndex = int.Parse(operations[1]);
                        int count = int.Parse(operations[2]);
                        key = key.Remove(startIndex, count - startIndex);
                        Console.WriteLine(key);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
