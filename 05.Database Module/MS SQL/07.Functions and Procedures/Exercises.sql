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

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(20))
RETURNS BIT
AS
BEGIN
		DECLARE @currentIndex INT = 1
		WHILE(@currentIndex <= LEN(@word))
		BEGIN
			IF(CHARINDEX(SUBSTRING(@word, @currentIndex, 1), @setOfLetters) = 0)
			   RETURN 0
			ELSE 
			   SET @currentIndex += 1
		END
		RETURN 1
END



	
--Ex.8
CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)