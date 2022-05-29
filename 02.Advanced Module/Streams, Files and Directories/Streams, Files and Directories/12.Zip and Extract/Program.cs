using System;
using System.IO.Compression;
using System.Linq;

namespace _12.Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @".\";
            string outputFile = @"C:\Users\George\Desktop\zip.rar";
            ZipFile.CreateFromDirectory(inputFile, outputFile);
            ZipFile.ExtractToDirectory(outputFile, @"C:\Users\George\Desktop");
        }
    }
}
