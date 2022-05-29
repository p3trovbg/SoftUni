using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EgnValidation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            InputInProgram();

        }

        private static void InputInProgram()
        {
            Console.WriteLine("if you want generate EGN, write \"Generator\" or \"Validation\", to validate some EGN");
            string input = Console.ReadLine();
            IEgnValidator egn = new EgnValidator();
            try
            {
                if (input == "Generator")
                {
                    Console.Write("Write the year: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Write the month: ");
                    int month = int.Parse(Console.ReadLine());
                    Console.Write("Write the day: ");
                    int day = int.Parse(Console.ReadLine());
                    Console.Write("Write the region: ");
                    string region = Console.ReadLine();
                    Console.Write("Is male: True/False ");
                    bool isMale = bool.Parse(Console.ReadLine());

                    var birthDate = new DateTime(year, month, day);
                    egn = new EgnValidator();
                    var egns = egn.Generate(birthDate, region, isMale);
                    foreach (var currentEgn in egns)
                    {
                        Console.WriteLine(currentEgn);
                    }
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("Generate successfull!");
                    InputInProgram();
                }
                else if (input == "Validation")
                {
                    //Chek some egn
                    Console.WriteLine("=============================================================");
                    Console.Write("Chek some EGN: ");
                    string someEgn = Console.ReadLine();
                    if (egn.Validate(someEgn))
                    {
                        Console.WriteLine("Your EGN is valid!");
                    }
                    else
                    {
                        Console.WriteLine("Your EGN is invalid!");
                        Console.WriteLine("Please try again!");
                        InputInProgram();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again!");
                InputInProgram();
            }
        }
    }
}
