using System;

namespace EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadDigit(start, end);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
        }

        private static void ReadDigit(int start, int end)
        {
            string num = Console.ReadLine();
            if (!int.TryParse(num, out int _))
            {
                throw new FormatException();
            }
            int n = int.Parse(num);
            if (n < start || n > end)
            {
                throw new ArgumentException();
            }

        }
    }
}
