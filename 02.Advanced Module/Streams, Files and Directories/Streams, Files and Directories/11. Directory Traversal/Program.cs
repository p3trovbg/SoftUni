using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace _11._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new Dictionary<string, Dictionary<string, double>>();
            string[] files = Directory.GetFiles(@"..\..\..\");
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string extension = Path.GetExtension(file);
                double size = (double)file.Length / 1024.0;
                if (!info.ContainsKey(extension))
                {
                    info.Add(extension, new Dictionary<string, double>());
                }
                if (!info[extension].ContainsKey(fileName))
                {
                    info[extension].Add(fileName, size);
                }
            }

            foreach (var extension in info.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                string outputExtension = $"{extension.Key} {Environment.NewLine}";
                File.AppendAllText(@"C:\Users\George\Desktop\output.txt", outputExtension);
                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                   string outputFile = ($"--{file.Key} - {file.Value}kb {Environment.NewLine}");
                    File.AppendAllText(@"C:\Users\George\Desktop\output.txt", outputFile);
                }
            }
        }
    }
}
