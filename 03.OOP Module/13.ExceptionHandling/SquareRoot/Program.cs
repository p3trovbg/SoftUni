using System;

namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads an integer number and calculates and prints its square root.
            //If the number is invalid or negative, print "Invalid number".In all cases finally print "Goodbye".Use try-catch-finally.
           
            try
            {
                double integer = double.Parse(Console.ReadLine());
                Digit digit = new Digit(integer);
                digit.Calculate();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
