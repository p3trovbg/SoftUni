using System;
using System.Collections.Generic;
using System.IO;

namespace _04.Merge_files
{
    class Program
    {
        static void Main(string[] args)
        {
           using StreamReader sr1 = new StreamReader(
                @"C:\Users\George\Desktop\Advanced-Module-SoftUni\Advanced-Module-SoftUni\Streams, Files and Directories\Streams, Files and Directories\04.Merge files\input1.txt");
           using StreamReader sr2 = new StreamReader(
               @"C:\Users\George\Desktop\Advanced-Module-SoftUni\Advanced-Module-SoftUni\Streams, Files and Directories\Streams, Files and Directories\04.Merge files\input2.txt");
           List<int> numbers = new List<int>();
           while (!sr1.EndOfStream && !sr2.EndOfStream)
           {
               numbers.Add(int.Parse(sr1.ReadLine()));
               numbers.Add(int.Parse(sr2.ReadLine()));
           }

           using StreamWriter sw =
               new StreamWriter(
                   @"C:\Users\George\Desktop\Advanced-Module-SoftUni\Advanced-Module-SoftUni\Streams, Files and Directories\Streams, Files and Directories\04.Merge files\output.txt");
           foreach (var number in numbers)
           {
               sw.WriteLine(number);
           }
        }
    }
}
