using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string typeNumbers = Console.ReadLine();
            var selectedNumbers = SelectedNumbers(numbers[0], numbers[1], typeNumbers);
            Console.WriteLine(string.Join(" ", selectedNumbers));
        }

        private static List<int> SelectedNumbers(int startRange, int endRange, string typeNumbers)
        {
            var selectedNumbers = new List<int>();

            for (int i = startRange; i <= endRange; i++)
            {
                selectedNumbers.Add(i);
            }
            if (typeNumbers == "even")
            {
                selectedNumbers = selectedNumbers.Where(x => x % 2 == 0).ToList();
            }
            else
            {
                selectedNumbers = selectedNumbers.Where(x => x % 2 != 0).ToList();
            }
            return selectedNumbers;
        }
    }
}
