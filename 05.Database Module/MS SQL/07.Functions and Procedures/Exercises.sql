USE SoftUni

--Ex.1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT FirstName, LastName 
	  FROM Employees
	 WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000


--Ex.2
CREATE PROC usp_GetEmployeesSalaryAboveNumber
	@Salary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName, LastName 
	  FROM Employees
	 WHERE Salary >= @Salary 
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Ex.3
CREATE PROC usp_GetTownsStartingWith 
	@Symbol VARCHAR(20)
AS
BEGIN
	SELECT [Name]
	  FROM Towns
	 WHERE Name LIKE CONCAT(@Symbol, '%')
END


EXEC usp_GetTownsStartingWith b


--Ex.4
CREATE OR ALTER PROC usp_GetEmployeesFromTown
	@TownName VARCHAR(20)
AS
BEGIN
	SELECT e.FirstName, e.LastName
	  FROM Employees e
	  JOIN Addresses a ON a.AddressID = e.AddressID
	  JOIN Towns t ON t.TownID = a.TownID
	  WHERE t.Name = @TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

--Ex.5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)
	SET @salaryLevel = (CASE
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	 END )
	RETURN @salaryLevel
END


SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [SalaryLevel]
  FROM Employees

--Ex.6
CREATE OR ALTER PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS 
BEGIN 
	SELECT e.FirstName, e.LastName
	FROM Employees e
	WHERE @salaryLevel LIKE dbo.ufn_GetSalaryLevel(e.Salary)
END

EXEC usp_EmployeesBySalaryLevel 'High'


--Ex.7

ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(20))
RETURNS BIT
AS
BEGIN
		DECLARE @currentIndex INT = 1
		WHILE(@currentIndex <= LEN(@word))
		BEGIN
			DECLARE @currentLater CHAR(1) = SUBSTRING(@word, @currentIndex, 1);
				IF(CHARINDEX(@currentLater, @setOfLetters) = 0)
				   RETURN 0
			SET @currentIndex += 1
		END
		RETURN 1
END



	
--Ex.8
CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL
	
	--2
	DELETE 
	  FROM EmployeesProjects
	 WHERE EmployeeID IN (
					SELECT EmployeeID
					  FROM Employees 
					 WHERE DepartmentID = @departmentId)
	
	--3
	UPDATE Employees
	   SET ManagerID = NULL
	 WHERE EmployeeID IN (
					SELECT EmployeeID
					  FROM Employees 
					 WHERE DepartmentID = @departmentId)
	--4
	UPDATE Employees
	   SET ManagerID = NULL
	 WHERE ManagerID IN (
					SELECT EmployeeID
					  FROM Employees 
					 WHERE DepartmentID = @departmentId)
	
	--5
	UPDATE Departments
	   SET ManagerID = NULL
	 WHERE DepartmentID = @departmentId
	
	--6 
	DELETE 
	  FROM Employees
	 WHERE DepartmentID = @departmentId
	 
	 --7
	 DELETE 
	  FROM Departments
	 WHERE DepartmentID = @departmentId
	
	--8
	 SELECT COUNT(*) 
	   FROM Employees 
	  WHERE DepartmentID = @departmentId
END


EXEC usp_DeleteEmployeesFromDepartment 1

--================================================================================
USE Bank

--Ex.9
CREATE OR ALTER PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name]
	  FROM AccountHolders
END

EXEC usp_GetHoldersFullName


--Ex.10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@money DECIMAL(15,2))
AS
BEGIN
	SELECT FirstName, LastName
  FROM AccountHolders ah
  JOIN Accounts a ON a.AccountHolderId = ah.Id
  GROUP BY FirstName, LastName
  HAVING SUM(Balance) > @money
  ORDER BY FirstName, LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 50000

--Ex.11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15,2), @earlyRate FLOAT, @years INT)
RETURNS DECIMAL (15,4)
AS
BEGIN
	DECLARE @result DECIMAL (15,4)
	SET @result = @sum * POWER((1 + @earlyRate), @years)
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)


--Ex.12
CREATE PROC usp_CalculateFutureValueForAccount(@Id INT, @rate FLOAT)
AS
BEGIN	
	SELECT a.Id
		  ,ah.FirstName
		  ,ah.LastName
		  ,a.Balance AS [Current Balance]
		  ,dbo.ufn_CalculateFutureValue(Balance, @rate, 5) [Balance in 5 years]
	  FROM AccountHolders ah
	  JOIN Accounts a ON a.Id = ah.Id
	 WHERE a.Id = @Id
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1


--Ex.13
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100))
RETURNS TABLE
AS
	RETURN(SELECT SUM(result.TotalCash) AS [TotalCash]
			 FROM
			 (SELECT Cash AS TotalCash
				  ,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
			  FROM Games g
			  JOIN UsersGames ug ON ug.GameId = g.Id
			  WHERE Name = @gameName) AS result
	 WHERE result.RowNumber % 2 = 1)


SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')