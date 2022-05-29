using System;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            text("Uq mi qnko", 5);
        }
        static void text(string text, int text1)
        {
            Console.WriteLine(text);
            for (int i = 0; i < 5; i++)
            {
                text1 = i + text1;
            }
        }
    }
}
