CREATE DATABASE SoftUni

--•	Towns (Id, Name)
CREATE Table Towns
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20)
)

--•	Addresses (Id, AddressText, TownId)
CREATE Table Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(20),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--•	Departments (Id, Name)
CREATE Table Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20)
)

--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)

CREATE Table Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	MiddleName VARCHAR(20), 
	LastName VARCHAR(20) NOT NULL,
	JobTitle VARCHAR(20) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME2,
	Salary DECIMAL(10,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)


--•	Towns: Sofia, Plovdiv, Varna, Burgas
--•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance

INSERT INTO Towns(Name) VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments(Name) VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

--Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
--Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
--Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
--Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
--Peter Pan Pan	Intern	Marketing	28/08/2016	599.88

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)



SELECT * FROM Towns
	ORDER BY Name ASC

SELECT * FROM Departments
	ORDER BY Name ASC

SELECT * FROM Employees
	ORDER BY Salary DESC


SELECT [Name] FROM Towns
	ORDER BY Name ASC

SELECT [Name] FROM Departments
	ORDER BY Name ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
	ORDER BY Salary DESC


UPDATE Employees 
SET Salary = salary * 1.10

SELECT Salary 
		FROM Employees
