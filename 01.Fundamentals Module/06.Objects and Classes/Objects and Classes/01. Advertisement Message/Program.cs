using System;
using System.Reflection.Metadata;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new string[]
                {"Diana",
                    "Petya",
                    "Stella",
                    "Elena",
                    "Katya",
                    "Iva",
                    "Annie",
                    "Eva"
                };
            string[] city = new string[]
                {"Burgas",
                    "Sofia",
                    "Plovdiv",
                    "Varna",
                    "Ruse"
                };

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Random rd = new Random();
                int indexPhrase = rd.Next(phrases.Length);
                int indexEvents = rd.Next(events.Length);
                int indexAuthors = rd.Next(authors.Length);
                int indexCities = rd.Next(city.Length);


                Console.WriteLine($"{phrases[indexPhrase]} {events[indexEvents]} {authors[indexAuthors]} – {city[indexCities]}");

            }
        }
    }
}
