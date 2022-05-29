using System;
using System.Linq;
namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            int result = CountOfTheVowels(input);
            Console.WriteLine(result);
        }
        static int CountOfTheVowels(string text)
        {
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
               
                char currentLatter = text[i];
                
                switch (currentLatter)
                {
                    case 'a':
                        counter++;
                        break;
                    case 'e':
                        counter++;
                        break;
                    case 'i':
                        counter++;
                        break;
                    case 'o':
                        counter++;
                        break;
                    case 'u':
                        counter++;
                        break;
                }               
            }
            return counter;
        }
    }
}
