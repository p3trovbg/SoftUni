--Part I – Queries for SoftUni Database
--Ex.1
SELECT * 
  FROM Departments

--Ex.2
SELECT [Name] 
  FROM Departments

--Ex.3
SELECT FirstName, LastName, Salary 
  FROM Employees

--Ex.4
SELECT FirstName, MiddleName, LastName 
  FROM Employees

--Ex.5
SELECT FirstName + '.' + LastName + '@softuni.bg' 
    AS [Full Email Address]
  FROM Employees

--Ex.6
  SELECT 
DISTINCT Salary 
	FROM Employees

--Ex.7
SELECT * 
  FROM Employees
 WHERE JobTitle = 'Sales Representative'

--Ex.8
SELECT FirstName, LastName, Salary
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000

--Ex.9
SELECT FirstName + ' ' + MiddleName + ' ' + LastName
    AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600)


--Ex.10
SELECT FirstName, LastName
  FROM Employees
 WHERE ManagerID IS NULL

--Ex.11
SELECT FirstName, LastName, Salary
  FROM Employees
 WHERE Salary > 50000
 ORDER BY Salary DESC

--Ex.12
SELECT TOP 5 FirstName, LastName
  FROM Employees
  ORDER BY Salary DESC

--Ex.13
SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentId != 4

--Ex.14
SELECT *
  FROM Employees
 ORDER BY Salary DESC
		,FirstName ASC
		,LastName DESC
		,MiddleName ASC

--Ex.15
CREATE 
  VIEW [V_EmployeesSalaries] AS
SELECT FirstName, LastName, Salary 
  FROM Employees

--Ex.16
CREATE VIEW [V_EmployeeNameJobTitle] AS
     SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle
       FROM Employees

--Ex.17
SELECT DISTINCT JobTitle 
           FROM Employees

--Ex.18
SELECT TOP 10 * 
      FROM Projects
  ORDER BY StartDate
           ,[Name]

--Ex.19
SELECT TOP(7) FirstName, LastName, HireDate
      FROM Employees
  ORDER BY HireDate DESC

--Ex.20
UPDATE Employees
   SET Salary *= 1.12
 WHERE DepartmentID IN (1, 2, 4, 11)
SELECT Salary 
  FROM Employees




