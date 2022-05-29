using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());           
            int lightsabersCount = (int)Math.Ceiling(countOfStudents * 1.1);
            int beltsCount = countOfStudents  - countOfStudents / 6;
            double sumSet = lightsabersCount * priceOfLightsabers +
                            countOfStudents * priceOfRobes +
                            beltsCount * priceOfBelts;
            if (sumSet <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {sumSet:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {sumSet - amountOfMoney:f2}lv more.");
            }

        }
    }
}
