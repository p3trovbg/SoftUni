using Exam.Management;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ManagementTests
{
    private IManagement management;

    private Employee GetRandomEmployeeWithoutSubordinates()
    {
        Random random = new Random();

        return new Employee(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            random.Next(1, 1_000_000_000),
            new List<Employee>());
    }

    [SetUp]
    public void Setup()
    {
        this.management = new Management();
    }

    // Correctness Tests

    [Test]
    public void Test1AddEmployee_ShouldSuccessfullyAddEmployee()
    {
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());

        Assert.AreEqual(2, this.management.Count);
    }

    [Test]
    public void Test2Contains_WithExistentEmployee_ShouldReturnTrue()
    {
        Employee randomEmployee = this.GetRandomEmployeeWithoutSubordinates();

        this.management.AddEmployee(randomEmployee);

        Assert.IsTrue(this.management.Contains(randomEmployee));
    }

    [Test]
    public void Test3Contains_WithNonexistentEmployee_ShouldReturnFalse()
    {
        Employee randomEmployee = this.GetRandomEmployeeWithoutSubordinates();

        this.management.AddEmployee(randomEmployee);

        Assert.IsFalse(this.management.Contains(this.GetRandomEmployeeWithoutSubordinates()));
    }

    [Test]
    public void Test4Count_With5Employees_ShouldReturn5()
    {
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());
        this.management.AddEmployee(this.GetRandomEmployeeWithoutSubordinates());

        Assert.AreEqual(5, this.management.Count);
    }

    [Test]
    public void Test9GetManagerEmployees_ShouldReturnCorrectEmployees()
    {
        Employee mainEmployee = this.GetRandomEmployeeWithoutSubordinates();

        Employee childEmployee = this.GetRandomEmployeeWithoutSubordinates();
        Employee child2Employee = this.GetRandomEmployeeWithoutSubordinates();
        Employee child3Employee = this.GetRandomEmployeeWithoutSubordinates();

        Employee subChildEmployee = new Employee(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 100, new List<Employee>());
        Employee subChild2Employee = this.GetRandomEmployeeWithoutSubordinates();
        Employee subChild3Employee = new Employee(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 200, new List<Employee>());

        childEmployee.Subordinates.Add(subChildEmployee);
        childEmployee.Subordinates.Add(subChild3Employee);
        child2Employee.Subordinates.Add(subChild2Employee);

        mainEmployee.Subordinates.Add(childEmployee);
        mainEmployee.Subordinates.Add(child2Employee);
        mainEmployee.Subordinates.Add(child3Employee);

        this.management.AddEmployee(mainEmployee);

        List<Employee> channel = this.management.GetManagerEmployees(childEmployee.Id).ToList();
        ;

        Assert.AreEqual(2, channel.Count);
        Assert.AreEqual(subChild3Employee, channel[0]);
        Assert.AreEqual(subChildEmployee, channel[1]);
    }

    // Performance Tests

    [Test]
    public void Test1AddEmployee_With100000Results_ShouldPassQuickly()
    {
        int count = 100000;

        Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();

        for (int i = 0; i < count; i++)
        {
            this.management.AddEmployee(new Employee(i + "", "Title" + i, i * 100, new List<Employee>()));
        }

        stopwatch.Stop();

        long elapsedTime = stopwatch.ElapsedMilliseconds;;

        Assert.IsTrue(elapsedTime < 450);
    }
}