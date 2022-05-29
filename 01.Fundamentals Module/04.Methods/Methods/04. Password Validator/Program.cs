using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (Length(input) && LattersOrDigits(input) && TwoDigist(input))
            {
                Console.WriteLine($"Password is valid");
            }
            else if (!Length(input) && LattersOrDigits(input) && !TwoDigist(input))
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
                Console.WriteLine($"Password must have at least 2 digits");
            }
            else if (Length(input) && !LattersOrDigits(input) && !TwoDigist(input))
            {
                Console.WriteLine($"Password must consist only of letters and digits");
                Console.WriteLine($"Password must have at least 2 digits");
            }
            else if (!Length(input) && !LattersOrDigits(input) && TwoDigist(input))
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
                Console.WriteLine($"Password must consist only of letters and digits");
            }
             else if (!Length(input) && !LattersOrDigits(input) && !TwoDigist(input))
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
                Console.WriteLine($"Password must consist only of letters and digits");
                Console.WriteLine($"Password must have at least 2 digits");
            }
            else if (Length(input) && LattersOrDigits(input) && !TwoDigist(input))
            {
                Console.WriteLine($"Password must have at least 2 digits");
            }
            else if (!Length(input) && LattersOrDigits(input) && TwoDigist(input))
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }
            else if (Length(input) && !LattersOrDigits(input) && TwoDigist(input))
            {
                Console.WriteLine($"Password must consist only of letters and digits");
            }



            static bool Length(string password)
            {
                bool chek = false;
                if (password.Length > 5 && password.Length <= 10)
                {
                    chek = true;
                }

                return chek;
            }

            static bool LattersOrDigits(string password)
            {
                bool chek = false;
                for (long i = 0; i < password.Length; i++)
                {
                    if (char.IsLetterOrDigit(password[i]))
                    {
                        chek = true;
                    }
                    else
                    {
                        chek = false;
                        break;
                    }
                }

                return chek;
            }

            static bool TwoDigist(string password)
            {
                bool chek = false;
                long count = 0;
                for (long i = 0; i < password.Length; i++)
                {
                    if (char.IsDigit(password[i]))
                    {
                        count++;
                        if (count == 2)
                        {
                            chek = true;
                            break;
                        }
                    }
                }

                return chek;
            }
        }
    }

}
