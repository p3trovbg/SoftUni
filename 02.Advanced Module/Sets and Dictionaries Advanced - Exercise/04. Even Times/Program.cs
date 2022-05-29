using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int digit = int.Parse(Console.ReadLine());
                if (!box.ContainsKey(digit))
                {
                    box.Add(digit, 0);
                }
                box[digit]++;
            }

            box = box
                .Where(x => x.Value % 2 == 0)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var digit in box)
            {
                Console.WriteLine(digit.Key);
            }
        }
    }
}
