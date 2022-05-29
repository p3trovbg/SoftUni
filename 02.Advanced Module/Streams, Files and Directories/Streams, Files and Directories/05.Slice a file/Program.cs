using System;
using System.IO;

namespace _05.Slice_a_file
{
    class Program
    {
        static void Main(string[] args)
        {
            using var file =
                new FileStream(
                    @"C:\Users\George\Desktop\Advanced-Module-SoftUni\Advanced-Module-SoftUni\Streams, Files and Directories\Streams, Files and Directories\05.Slice a file\text.txt",
                    FileMode.OpenOrCreate);
            var size = (int)Math.Ceiling(file.Length / 4.0);

            for (int i = 1; i <= 4; i++)
            {
                var buffer = new byte[size];
                file.Read(buffer);
                using var newText = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
                newText.Write(buffer);
            }
        }
    }
}