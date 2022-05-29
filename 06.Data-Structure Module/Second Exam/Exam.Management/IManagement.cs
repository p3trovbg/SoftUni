using System.Collections.Generic;

namespace Exam.Management
{
    public interface IManagement
    {
        void AddEmployee(Employee employee);

        bool Contains(Employee employee);

        int Count { get; }

        Employee GetEmployee(string employeeId);

        void RemoveEmployee(string employeeId);

        IEnumerable<Employee> GetManagerEmployees(string managerId);

        IEnumerable<Employee> GetCLevelManagement();

        IEnumerable<Employee> GetEmployeesInTimeServedRange(int lowerBound, int upperBound);

        IEnumerable<Employee> GetAllEmployeesOrderedByCountOfSubordinatesThenByTimeServedThenByName();
    }
}
