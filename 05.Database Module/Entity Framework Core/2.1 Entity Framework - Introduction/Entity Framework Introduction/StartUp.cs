using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();

            //03. Employees Full Information
            //Console.WriteLine(GetEmployeesFullInformation(context));

            //04. Employees with Salary Over 50 000
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //05. Employees from Research and Development
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //06. Adding a New Address and Updating Employee
            //Console.WriteLine(AddNewAddressToEmployee(context));

            //07. Employees and Projects
            //Console.WriteLine(GetEmployeesInPeriod(context)); //33 points in judge.

            //08. Addresses by Town
            //Console.WriteLine(GetAddressesByTown(context));

            //09. Employee 147
            //Console.WriteLine(GetEmployee147(context));

            //10. Departments with More Than 5 Employees
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //11. Find Latest 10 Projects
            //Console.WriteLine(GetLatestProjects(context));

            //12. Increase Salaries
            //Console.WriteLine(IncreaseSalaries(context));

            //13.13. Find Employees by First Name Starting With Sa
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //14. Delete Project by Id
            //Console.WriteLine(DeleteProjectById(context));

            //15. Remove Town
            
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            context.Employees
                   .ToList()
                   .ForEach(e =>
                   sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            context.Employees
                   .Where(e => e.Salary > 50000)
                   .OrderBy(x => x.FirstName)
                   .ToList()
                   .ForEach(e => sb.AppendLine($"{e.FirstName} - {e.Salary:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            context.Employees
                .Where(e => e.Department.Name.Equals("Research and Development"))
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList()
                .ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:F2}"));
            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov")
                .Address = newAddress;

            context.SaveChanges();

            var addressess = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .Select(a => a.Address.AddressText)
                .ToList();

            return String.Join(Environment.NewLine, addressess);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            context.Employees
                    .Include(m => m.Manager) //the manager is needed to print the result
                    .Include(ep => ep.EmployeesProjects)
                    .ThenInclude(p => p.Project)
                    .Where(eps => eps.EmployeesProjects
                                        .Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                    .Take(10)
                    .ToList()
                    .ForEach(e =>
                    {
                        sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");
                        foreach (var project in e.EmployeesProjects)
                        {
                            sb.AppendLine(string.Format(
                            "--{0} - {1} - {2}",
                            project.Project.Name,
                            project.Project.StartDate.
                                        ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            project.Project.EndDate.HasValue ? project.Project.EndDate.Value.
                                                                ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"));
                        }
                    });

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            context.Addresses
                .Include(e => e.Employees)
                .Include(t => t.Town)
                .OrderByDescending(e => e.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList()
                .ForEach(a => sb.AppendLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count()} employees"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(ep => ep.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                sb.AppendLine($"{project.Project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            //Order them by employee count (ascending), then by department name (alphabetically). 
            var departments = context.Departments
                        .Include(e => e.Employees)
                        .ThenInclude(m => m.Manager)
                        .Where(e => e.Employees.Count() > 5)
                        .OrderBy(x => x.Employees.Count())
                        .ThenBy(d => d.Name)
                        .ToList();

            //For each department, print the department name and the manager’s first and last name on the first row. 
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (var employee in department.Employees
                                                   .OrderBy(x => x.FirstName)
                                                   .ThenBy(x => x.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(p =>
                    {
                        sb.AppendLine($"{p.Name}");
                        sb.AppendLine($"{p.Description}");
                        sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
                    });

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            //Write a program that increase salaries of all employees that are in the Engineering, Tool Design, Marketing or
            //Information Services department by 12 %.

            context.Employees
                    .Include(d => d.Departments)
                    .Where(x => x.Department.Name == "Engineering" ||
                                x.Department.Name == "Tool Design" ||
                                x.Department.Name == "Marketing" ||
                                x.Department.Name == "Information Services")
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                    .ForEach(e =>
                    {
                        e.Salary *= 1.12M;
                        sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
                    });

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList()
                .ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            //Let's delete the project with id 2. Then, take 10 projects and return their names, each on a new line.
            //Remember to restore your database after this task.
            var id = 2;
            var projects = context.EmployeesProjects.Where(x => x.ProjectId == id);
            context.EmployeesProjects.RemoveRange(projects);
            context.SaveChanges();

            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
            context.SaveChanges();

            context.Projects
                .Take(10)
                .ToList()
                .ForEach(p => sb.AppendLine($"{p.Name}"));
            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {

            return sb.ToString().TrimEnd();
        }
    }
}
