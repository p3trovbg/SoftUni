using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string name = firstInput[0] + " " + firstInput[1];
            string city = string.Empty;
            if (firstInput.Length > 4)
            {
                city = firstInput[3] + " " + firstInput[4];
            }
            else
            {
                city = firstInput[3];
            }
            var firstTuple = new Threeuple<string, string, string>(name, firstInput[2], city);
            string[] secondInput = Console.ReadLine().Split();
            var secondTuple = new Threeuple<string, int, string>(secondInput[0], int.Parse(secondInput[1]), secondInput[2] == "drunk" ? "True" : "False" );
            string[] thirdInput = Console.ReadLine().Split();
            var thirdTuple = new Threeuple<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
