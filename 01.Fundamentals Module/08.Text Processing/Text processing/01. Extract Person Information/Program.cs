using System;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int startIndexName = 0;
            int endIndexName = 0;
            int startIndexAge = 0;
            int endIndexAge = 0;
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                for (int j = 0; j < text.Length; j++)
                {
                    char symbol = text[j];

                    switch (symbol)
                    {
                        case '@':
                            startIndexName = j + 1;
                            break;
                        case '|':
                            endIndexName = j - startIndexName;
                            break;
                        case '#':
                            startIndexAge = j + 1;
                            break;
                        case '*':
                            endIndexAge = j - startIndexAge;
                            break;
                    }
                }
                string name = text.Substring(startIndexName, endIndexName);
                string age = text.Substring(startIndexAge, endIndexAge);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}