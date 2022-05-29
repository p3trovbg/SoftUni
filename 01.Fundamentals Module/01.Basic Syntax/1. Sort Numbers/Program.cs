using System;

namespace _1._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double x = 0;

            if (b < a)
            {
                x = a;
                a = b;
                b = x;
            }
           if (c < a)
            {
                x = c;
                c = a;
                a = x;
            }
            if (c < b)
            {
                x = c;
                c = b;
                b = x;
            }
           if (a == b)
            {
                x = a;
                a = b;
                b = x;
            }
            if (a == c)
            {
                x = a;
                a = c;
                c = x;
            }
           if (b == c)
            {
                x = b;
                b = c;
                c = x;
            }
            Console.WriteLine(c);
            Console.WriteLine(b);
            Console.WriteLine(a);
        }
    }
}
