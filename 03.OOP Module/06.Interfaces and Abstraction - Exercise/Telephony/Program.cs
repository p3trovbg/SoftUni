using System;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();
            for (int i = 0; i < numbers.Length; i++)
            {
                int number;
                if (int.TryParse(numbers[i], out number))
                {
                    if (numbers[i].Length == 7)
                    {
                        stationaryPhone.Calling(numbers[i]);
                    }
                    else
                    {
                        smartphone.Calling(numbers[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                bool isValid = true;
                string site = sites[i];
                for (int j = 0; j < site.Length; j++)
                {
                    if (char.IsDigit(site[j]))
                    {
                        Console.WriteLine("Invalid URL!");
                        isValid = false;
                        break;
                    }                  
                }
                if (isValid)
                {
                    smartphone.Browsing(site);
                }
            }
        }
    }
}
