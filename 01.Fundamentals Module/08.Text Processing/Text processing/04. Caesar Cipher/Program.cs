using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] chars = text.ToCharArray();
            char result = ' ';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                int index = chars[i] + 3;
                result = (char)index;
                sb.Append(result);
            }

            Console.WriteLine(sb);
        }
    }
}
