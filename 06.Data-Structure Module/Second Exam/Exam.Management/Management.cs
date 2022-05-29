using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Management
{
    public class Management : IManagement
    {
        private Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
        private Dictionary<string, Employee> managers = new Dictionary<string, Employee>();

        public int Count => employees.Count;

        private void AddEmployeeInternal(Employee employee)
        {
            if(employee.Subordinates.Count == 0)
            {
                return;
            }

            foreach (var employer in employee.Subordinates)
            {
                if (managers.ContainsKey(employer.Id))
                {
                    managers.Remove(employer.Id);
                }
                if (employer.Subordinates.Count != 0)
                {
                    AddEmployeeInternal(employer);
                }
                employees.Add(employer.Id, employer);
            }
        }

        public void AddEmployee(Employee employee)
        {
            managers.Add(employee.Id, employee);
            employees.Add(employee.Id, employee);
            AddEmployeeInternal(employee);
            
        }

        public bool Contains(Employee employee)
        {
            return employees.ContainsKey(employee.Id);
        }

        public IEnumerable<Employee> GetAllEmployeesOrderedByCountOfSubordinatesThenByTimeServedThenByName()
        {
            return employees.Values.OrderBy(x => x.Subordinates.Count).ThenBy(x => x.MonthsInService).ThenBy(x => x.Name);
        }

        public IEnumerable<Employee> GetCLevelManagement()
        {
            return managers.Values.OrderByDescending(x => x.Subordinates.Count).ThenBy(x => x.MonthsInService);
        }

        public Employee GetEmployee(string employeeId)
        {
            if(!employees.ContainsKey(employeeId))
            {
                throw new ArgumentException();
            }

            return employees[employeeId];
        }

        public IEnumerable<Employee> GetEmployeesInTimeServedRange(int lowerBound, int upperBound)
        {
            return employees.Values.Where(x => x.MonthsInService >= lowerBound && x.MonthsInService <= upperBound).OrderByDescending(x => x.MonthsInService)
                .ThenBy(x => x.Name);
        }

        public IEnumerable<Employee> GetManagerEmployees(string managerId)
        {
            if(!employees.ContainsKey(managerId))
            {
                throw new ArgumentException();
            }

            if(employees[managerId].Subordinates.Count == 0)
            {
                throw new ArgumentException();
            }

            var manager = employees[managerId];
            var subordinates = manager.Subordinates;
            return subordinates.OrderByDescending(x => x.MonthsInService);
        }

        public void RemoveEmployee(string employeeId)
        {
            if(!employees.ContainsKey(employeeId))
            {
                throw new ArgumentException();
            }

            employees.Remove(employeeId);
        }
    }
}
