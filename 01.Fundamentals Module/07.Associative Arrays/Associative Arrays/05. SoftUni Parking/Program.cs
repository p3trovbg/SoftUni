using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var license = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string operation = data[0];
                string name = data[1];
                if (operation == "register")
                {
                    string licensePlateNumber = data[2];
                    if (license.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        license.Add(name, licensePlateNumber);
                        Console.WriteLine($"{name} registered {licensePlateNumber} successfully");
                    }
                }
                else
                {
                    if (license.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        license.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }


            license.Distinct();
            foreach (var validRegister in license)
            {
                Console.WriteLine($"{validRegister.Key} => {validRegister.Value}");
            }
        }
    }
}