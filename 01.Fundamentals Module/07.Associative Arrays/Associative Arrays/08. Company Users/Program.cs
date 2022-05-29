using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string[] data = Console.ReadLine().Split(" -> ");
                if (data[0] == "End")
                {
                    break;
                }
                string name = data[0];
                string id = data[1];
                if (!employee.ContainsKey(name))
                {
                    employee.Add(name, new List<string>());
                    employee[name].Add(id);
                }
                else
                {
                    if (!employee[name].Contains(id))
                    {
                        employee[name].Add(id);
                    }
                }
            }

            foreach (var company in employee)
            {
                Console.WriteLine(company.Key);

                foreach (var employees in company.Value)
                {
                    Console.WriteLine($"-- {employees}");
                }
            }

        }
    }
}
