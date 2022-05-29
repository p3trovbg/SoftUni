using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string value = Console.ReadLine();
            Result(type, value);
            Console.WriteLine(Result(type, value));

        }

        static string Result(string type, string value)
        {
            string result = "";
            if (type == "int")
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    int num = int.Parse(value);
                    num *= 2;
                    result = $"{num}";
                }
            }
            else if (type == "real")
            {
                double number;
                if (double.TryParse(value, out number))
                {
                    double num = double.Parse(value);
                    num *= 1.5;
                    result = $"{num:f2}";
                }
            }
            else if (type == "string")
            {
                result = $"${value}$";
            }

            return result;
        }
    }
}
