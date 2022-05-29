using System.Collections.Generic;

namespace Exam.Management
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int MonthsInService { get; set; }

        public List<Employee> Subordinates { get; set; }

        public Employee(string id, string name, int monthsInService, List<Employee> subordinates)
        {
            this.Id = id;
            this.Name = name;
            this.MonthsInService = monthsInService;
            this.Subordinates = subordinates;
        }
    }
}
