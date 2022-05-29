using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var vip = new HashSet<string>();
            var normal = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    while ((input = Console.ReadLine()) != "END")
                    {
                        if (vip.Contains(input))
                        {
                            vip.Remove(input);
                        }
                        if (normal.Contains(input))
                        {
                            normal.Remove(input);
                        }
                    }
                    break;
                }

                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    normal.Add(input);
                }
            }

            Console.WriteLine(vip.Count + normal.Count);
            foreach (var guestNumber in vip)
            {
                Console.WriteLine(guestNumber);
            }
            foreach (var guest in normal)
            {
                Console.WriteLine(guest);
            }
        }
    }
}