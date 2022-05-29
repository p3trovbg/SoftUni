using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (PasswordLength(input))
            {
                if(!OnlyLetterOrDigit(input))
                {
                    Console.WriteLine("Valid");
                }
            }
        }

        static bool PasswordLength(string input)
        {
            bool flag = false;
            if (input.Length >= 6 && input.Length <= 10)
            {
                flag = true;
            }
            return flag;
        }
        public static bool OnlyLetterOrDigit(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
            
        }
    }
}
