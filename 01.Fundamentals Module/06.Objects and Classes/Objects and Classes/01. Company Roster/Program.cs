using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _01._Company_Roster
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> listOfEmployees = new List<Employee>(n);
            
            for (int i = 0; i < n; i++)
            {
                string[] dates = Console.ReadLine().Split();
                string name = dates[0];
                decimal salary = decimal.Parse(dates[1]);
                string department = dates[2];

                Employee employee = new Employee()
                {
                    Name = name,
                    Salary = salary,
                    Department = department
                };
                listOfEmployees.Add(employee);
            }

            //CALCULATE THE HIGHEST AVERAGE SALARY

            listOfEmployees = listOfEmployees.OrderBy(x => x.Department).ToList();

            var departments = new Dictionary<string, List<decimal>>();


            for (int i = 0; i < listOfEmployees.Count; i++)
            {
                string newDepartment = listOfEmployees[i].Department;
                decimal newSalary = listOfEmployees[i].Salary;
                if (!departments.ContainsKey(newDepartment))
                {
                    departments[newDepartment] = new List<decimal>();
                }
                departments[newDepartment].Add(newSalary);
            }
            string departmentMaxAverage = departments.OrderByDescending(x => x.Value.Average()).First().Key;

            //PRINT OUTPUT

            listOfEmployees = listOfEmployees
                .Where(x => x.Department == departmentMaxAverage)
                .OrderByDescending(x => x.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {departmentMaxAverage}");

            foreach (var men in listOfEmployees)
            {
                Console.WriteLine($"{men.Name} {men.Salary:f2}");
            }
        }
    }
}
    
