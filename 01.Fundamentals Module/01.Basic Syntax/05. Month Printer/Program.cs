using System;

namespace _05._Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            int week = int.Parse(Console.ReadLine());
            string weeks = null;
            switch (week)
            {
                case 1:
                    weeks = "January";
                    break;
                case 2:
                    weeks = "February";
                    break;
                case 3:
                    weeks = "March";
                    break;
                case 4:
                    weeks = "April";
                    break;
                case 5:
                    weeks = "May";
                    break;
                case 6:
                    weeks = "June";
                    break;
                case 7:
                    weeks = "July";
                    break;
                case 8:
                    weeks = "August";
                    break;
                case 9:
                    weeks = "September";
                    break;
                case 10:
                    weeks = "October";
                    break;
                case 11:
                    weeks = "November";
                    break;
                case 12:
                    weeks = "December";
                    break;                   
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            Console.WriteLine(weeks);
        }
    }
}
