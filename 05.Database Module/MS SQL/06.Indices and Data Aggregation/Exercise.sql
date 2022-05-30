--Ex.1
SELECT 
   COUNT(*) 
  FROM WizzardDeposits AS [Count]

--Ex.2
SELECT MAX(MagicWandSize)
  FROM WizzardDeposits

--Ex.3
SELECT DepositGroup
	  ,MAX(MagicWandSize)
  FROM WizzardDeposits
  GROUP BY DepositGroup

--Ex.4
SELECT TOP(2)
	DepositGroup
  FROM WizzardDeposits
  GROUP BY DepositGroup
  ORDER BY AVG(MagicWandSize) ASC

--Ex.5
  SELECT
	DepositGroup
	,SUM(DepositAmount)
  FROM WizzardDeposits
  GROUP BY DepositGroup

--Ex.6
    SELECT
	DepositGroup
	,SUM(DepositAmount)
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup

--Ex.7
   SELECT
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
  ORDER BY TotalSum DESC

--Ex.8
SELECT
	DepositGroup
   ,MagicWandCreator
   ,MIN(DepositCharge) AS [MinDepositCharge]
  FROM WizzardDeposits
  GROUP BY DepositGroup,MagicWandCreator
  ORDER BY MagicWandCreator, DepositGroup

--Ex.9
SELECT 
	AgeByGroup AgeGroup, COUNT(AgeByGroup) AS [WizardCount]
FROM (SELECT 
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		 END AS AgeByGroup
		FROM WizzardDeposits) AgeByGroupTable
GROUP BY AgeByGroup

--Ex.10
SELECT 
  LEFT(FirstName, 1) AS FirstLatter
  FROM WizzardDeposits
  WHERE DepositGroup = 'Troll Chest'
  GROUP BY LEFT(FirstName, 1)
  ORDER BY FirstLatter

--Ex.11
SELECT 
	DepositGroup
	,IsDepositExpired
	,AVG(DepositInterest) [AverageInterest]
  FROM WizzardDeposits
  WHERE DepositStartDate > '1985-01-01'
  GROUP BY DepositGroup, IsDepositExpired
  ORDER BY DepositGroup DESC


--Ex.12

  SELECT SUM(Result.Total)
    FROM (
	  SELECT
	  Host.DepositAmount - LEAD(host.DepositAmount, 1) OVER (ORDER BY Host.Id) AS Total
	  FROM WizzardDeposits [Host]) AS [Result]

--=======================================================
USE SoftUni

--Ex.13
SELECT DepartmentId
	  ,SUM(Salary) [TotalSum]
  FROM Employees
  GROUP BY DepartmentID
  ORDER BY DepartmentID

--Ex.14
SELECT DepartmentId
	  ,MIN(Salary) [MinimumSalary]
  FROM Employees
  WHERE DepartmentID IN(2, 5, 7) AND HireDate > '2000-01-01'
  GROUP BY DepartmentID
  ORDER BY DepartmentID

--Ex.15
SELECT * INTO NewTable
		 FROM Employees
		WHERE Salary > 30000

DELETE FROM NewTable
 WHERE ManagerID = 42

 UPDATE NewTable
 SET Salary = Salary + 5000
 WHERE DepartmentID = 1;

 SELECT DepartmentID, AVG(Salary)
   FROM NewTable
  GROUP BY DepartmentID


--Ex.16
SELECT DepartmentId
	  ,MAX(Salary) [MaxSalary]
  FROM Employees
  GROUP BY DepartmentID
  HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Ex.17
SELECT Count(*) [Count]
  FROM Employees
  WHERE ManagerID IS NULL

--Ex.18
SELECT DISTINCT Result.DepartmentID, Result.Salary
  FROM ( SELECT DepartmentID
			   ,Salary
			   ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranked]
				   FROM Employees) AS Result
 WHERE Result.Ranked = 3



--Ex.19
SELECT TOP(10) FirstName, LastName, DepartmentID
  FROM Employees e
  WHERE Salary > (SELECT AVG(Salary)
					FROM Employees
					WHERE DepartmentID = e.DepartmentID
					GROUP BY DepartmentID)
ORDER BY DepartmentID