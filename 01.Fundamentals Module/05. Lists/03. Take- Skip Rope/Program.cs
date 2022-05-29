using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace _03._Take__Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> numbers = new List<string>();
            List<string> latters = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    numbers.Add(text[i].ToString());
                }
                else
                {
                    latters.Add(text[i].ToString());
                }
            }

            List<string> oddIndex = new List<string>();
            List<string> evenIndex = new List<string>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenIndex.Add(numbers[i]);
                }
                else
                {
                    oddIndex.Add(numbers[i]);
                }
            }

            string result = "";
            int index = 0;
            for (int i = 0; i < oddIndex.Count; i++)
            {
                int take = int.Parse(evenIndex[i]);
                int skip = int.Parse(oddIndex[i]);
                if (index + take > latters.Count)
                {
                    take = latters.Count - index;
                }

                for (int j = 0; j < take; j++)
                {
                    result += latters[index + j];
                }
                index += take + skip;
            }

            Console.WriteLine(result);
        }
    }
}