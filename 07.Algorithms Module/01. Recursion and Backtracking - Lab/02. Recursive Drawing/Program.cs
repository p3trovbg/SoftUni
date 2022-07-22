using System;

namespace _02._Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            Drawing(input);
        }

        private static void Drawing(int input)
        {
            if(input == 0)
            {
                return;
            }
            Console.WriteLine(new string('*', input));
            Drawing(input - 1);
            Console.WriteLine(new string('#', input));
        }
    }
}
