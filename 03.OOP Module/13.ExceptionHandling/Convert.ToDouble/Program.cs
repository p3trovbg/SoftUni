using System;

namespace ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            double number = 0;
            try
            {
                number = Convert.ToDouble(num);

                number = Math.Pow(number, 40);

                if (double.IsNegativeInfinity(number) || double.IsPositiveInfinity(number))
                {
                    throw new OverflowException();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(number);
        }
    }
}
