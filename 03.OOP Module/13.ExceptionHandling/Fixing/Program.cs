using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5]
           { "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"};

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
