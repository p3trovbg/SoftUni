using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _08.Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines(@"input.txt");
            var myList = new List<string>();
            int idx = 1;
            foreach (var line in text)
            {
                int symbols = line.Count(x => char.IsLetter(x));
                int punctuations = line.Count(x => char.IsPunctuation(x));
                string newText = $"Line {idx}: {line} ({symbols})({punctuations})";
                myList.Add(newText);
                idx++;
            }

            File.WriteAllLines(@"output.txt", myList, Encoding.UTF8);
        }
    }
}
