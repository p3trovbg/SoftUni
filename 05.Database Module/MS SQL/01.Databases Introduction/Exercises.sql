--Problem 1.Create Database
CREATE DATABASE Minions

--Problem 2.Create Tables
CREATE TABLE Minions
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

--Problem 3.Alter Minions Table
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--Problem 4.Insert Records in Both Tables
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna')

--1	Kevin	22	1
--2	Bob	15	3
--3	Steward	NULL 2
INSERT INTO Minions([Name], Age, TownId) VALUES
('Kevin', 22, 1),
('Bob', 15, 3),
('Steward', NULL, 2)

--Problem 5.Truncate Table Minions
TRUNCATE TABLE Minions

--Problem 6.Drop All Tables

DROP TABLE Minions
DROP TABLE Towns


--Problem 7.Create Table People
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(5, 2),
	[Weight] DECIMAL(5, 2),
	Gender BIT NOT NULL,
	Birthdate DATETIME2,
	Biography VARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Pesho', 'pictureMeRollin', 10.20, 200, 0, '2016-7-16', NULL),
('Misho', 'pictureMeRollin', 100.30, 200, 0, '2016-7-16', NULL),
('Gosho', 'pictureMeRollin', 100.40, 200, 0, '2016-7-16', NULL),
('Mitko', 'pictureMeRollin', 100.10, 200, 0, '2016-7-16', NULL),
('Vesko', 'pictureMeRollin', 100.123, 200, 0 , '2016-7-16', NULL)

SELECT * FROM People

--Problem 8.Create Table Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26),
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME2,
	IsDelete BIT NOT NULL
)


INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDelete) VALUES
('Pesho', '123', 'pictureMeRollin', '2016-7-16', 0),
('Misho', '2312das', 'pictureMeRollin', '2016-7-16', 1),
('Gosho', '3412423', 'pictureMeRollin',  '2016-7-16', 0),
('Mitko', '1235234', 'pictureMeRollin','2016-7-16', 1),
('Vesko', '1123122111', 'pictureMeRollin' , '2016-7-16', 0)

SELECT * FROM Users

--Problem 9.Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07134BC3C5


ALTER TABLE Users	
ADD CONSTRAINT PK_Users_IdUsername
	PRIMARY KEY (Id, Username)


--Problem 10. Add Check Constraint

ALTER TABLE Users
	ADD CHECK (DATALENGTH([Password]) >= 5)



--Problem 11. Set Default Value of a Field

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
 DEFAULT(CURRENT_TIMESTAMP)
  FOR LastLoginTime

SELECT * FROM Users


--Problem 12. Set Unique Field
ALTER TABLE Users
 DROP CONSTRAINT PK_Users_IdUsername

ALTER TABLE Users
 ADD CONSTRAINT PK_Users_Id
	PRIMARY KEY(Id)

ALTER TABLE Users
 ADD CONSTRAINT Users_Username
		UNIQUE (DATALENGTH(Username) >= 3)



--Problem 13. Movies Database
CREATE DATABASE Movies
--•	Directors (Id, DirectorName, Notes)
--•	Genres (Id, GenreName, Notes)
--•	Categories (Id, CategoryName, Notes)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)


--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyRightYear DATETIME2,
	[Length] DECIMAL(5, 2),
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating FLOAT(2),
	NOTES VARCHAR(MAX)
)


--Problem 14.	Car Rental Database
CREATE DATABASE CarRental

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50),
	DailyRate FLOAT(2),
	WeeklyRate FLOAT(2),
	MonthlyRate FLOAT(2),
	WeekendRate FLOAT(2)
)

INSERT INTO Categories VALUES
('Hatchback', NULL, NULL, NULL, NULL),
('Sedan', NULL, NULL, NULL, NULL),
('SUV', NULL, NULL, NULL, NULL)


--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear DATETIME2,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors SMALLINT NOT NULL,
	Picture VARCHAR(MAX),
	Condition VARCHAR(20),
	Avaliable BIT NOT NULL
)

INSERT INTO Cars VALUES
('12AAAA12', 'Mercedes', 'S63', NULL, 3, 4, 4, 'Perfect', 1),
('13AGGGGBA', 'BMWGipsy', 'MPower', NULL, 2, 2, 4, 'Perfect', 1),
('?21881EO', 'Toyota', 'Supra', NULL, 1, 4, 4, 'Perfect', 1)

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Gosho', 'Mosho', NULL, NULL),
('Zario', 'Ciganina', NULL, NULL),
('Zarko', 'Kafeto', NULL, NULL)

--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenseNumber VARCHAR NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(50),
	City VARCHAR (30),
	ZIPCode VARBINARY(50),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
('СН0062СН', 'Vasil Naidenov', NULL, 'Sliven', NULL, NULL),
('CН36963НН', 'Gosho Gushtera', NULL, 'Burgas', NULL, NULL),
('CА03216HP', 'Mitio Pishtova', NULL, 'Veliko Turnvo', NULL, NULL)

--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel SMALLINT,
	KilometrageStart SMALLINT, 
	TotalKilometrage SMALLINT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays SMALLINT,
	RateApplied FLOAT(2),
	TaxRate FLOAT(2),
	OrderStatus VARCHAR(20),
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1, 2, 3, 100, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Pending', NULL),
(3, 2, 1 , 120, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Active', NULL),
(3, 1, 2 , 110, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Stolen', NULL)

