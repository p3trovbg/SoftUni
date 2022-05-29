using System;

namespace _06._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string language = null;

            switch (country)
            {
                case "England":
                case "USA":
                    language = "English";
                    break;
                case "Argentina":
                case "Mexico":
                case "Spain":
                    language = "Spanish";
                        break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
            Console.WriteLine(language);

        }
    }
}
