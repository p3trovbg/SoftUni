--Ex.1
SELECT 
	EmployeeID
   ,LastName
   ,HireDate
   ,Salary
   ,CASE
      WHEN Salary BETWEEN 9000 AND 30000 THEN 'low'
      WHEN Salary BETWEEN 30001 AND 55000 THEN 'middle'
      WHEN Salary BETWEEN 55001 AND 130000 THEN 'high'
	 END AS [SalaryRange]
  FROM Employees

--Ex.2
SELECT 
       ProjectID
      ,Name
	  ,StartDate
	  ,ISNULL(EndDate, GETDATE()) AS EndDate
  FROM Projects

--Ex.3
SELECT DepartmentID, MIN(Salary)
  FROM Employees
  WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
 GROUP BY DepartmentID

--Ex.4
SELECT JobTitle, COUNT(*) AS EmployeeCount
  FROM Employees
 GROUP BY JobTitle
HAVING COUNT(*) > 5

--Ex.5
SELECT DepartmentID, AVG(Salary) AS AverageSalary
  FROM Employees
 GROUP BY DepartmentID
HAVING AVG(Salary) NOT BETWEEN 30000 AND 70000