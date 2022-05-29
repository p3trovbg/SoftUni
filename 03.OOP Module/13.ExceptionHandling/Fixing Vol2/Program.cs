using System;

namespace Fixing_Vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine())
                  , secondNumber = int.Parse(Console.ReadLine());
            byte result = 0;
            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            }
        }
    }
}
