using System;
using System.IO;

namespace _06.Folder_size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\Users\George\Desktop\Advanced-Module-SoftUni\Advanced-Module-SoftUni\Streams, Files and Directories\Streams, Files and Directories\06.Folder size");
            long length = 0;
            foreach (var file in files)
            {
                length += new FileInfo(file).Length;
            }

            using StreamWriter sw =
            new StreamWriter(
                @"C:\Users\George\Desktop\Advanced-Module-SoftUni\Advanced-Module-SoftUni\Streams, Files and Directories\Streams, Files and Directories\06.Folder size\output.txt");
            sw.Write(length / 1000000.0);
        }
    }
}
