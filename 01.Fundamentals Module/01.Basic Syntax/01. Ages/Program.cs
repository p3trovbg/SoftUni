using System;

namespace _01._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());
            string type = null;
            if (ages >= 0 && ages <= 2)
            {
                type = "baby";
            }
            else if (ages >= 3 && ages <= 13)
            {
                type = "child";
            }
            else if (ages >= 14 && ages <= 19)
            {
                type = "teenager";
            }
            else if (ages >= 20 && ages <= 65)
            {
                type = "adult";
            }
            else if (ages >= 66)
            {
                type = "elder";

            }
            Console.WriteLine(type);

        }
    }
}
