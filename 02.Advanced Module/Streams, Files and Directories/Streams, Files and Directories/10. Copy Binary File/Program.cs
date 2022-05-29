using System;
using System.IO;

namespace _10._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream wallpaper = new FileStream(@"wallpaper.jpg", FileMode.Open, FileAccess.Read);
            using FileStream newPaper = new FileStream(@"newWallPaper.jpg", FileMode.Create);
            byte[] buffer = new byte[4096];
            

            while (true)
            {
                int count = wallpaper.Read(buffer);
                if (count <= 0)
                {
                    break;
                }
                newPaper.Write(buffer);
            }
        }
    }
}
