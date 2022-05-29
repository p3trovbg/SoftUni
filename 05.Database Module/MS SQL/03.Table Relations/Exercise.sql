--Problem 1. One-To-One Relationship

CREATE TABLE Passports
(
	PassportID INT IDENTITY(101, 1) PRIMARY KEY,
	PassportNumber VARCHAR(50) 
)

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50),
	Salary DECIMAL(10,2),
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT 
  INTO Passports(PassportNumber) VALUES
	   ('N34FG21B')
	   ,('K65LO4R7')
	   ,('ZE657QP2')

INSERT 
  INTO Persons(FirstName, Salary, PassportID) VALUES
	   ('Roberto', 43300.00, 102)
	   ,('Tom', 56100.00, 103)
	   ,('Yana', 60200.00, 101)


--02. One-To-Many Relationship

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	EstablishedOn DATETIME2
)


CREATE TABLE Models
(
	ModelID INT IDENTITY(101,1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerId) NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
	('BMW', '07/03/1916')
	,('Tesla', '01/01/2003')
	,('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID) VALUES
	('X1', 1)
	,('i6', 1)
	,('Model S', 2)
	,('Model X', 2)
	,('Model 3', 2)
	,('Nova', 3)



--03. Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT INT PRIMARY KEY (StudentID, ExamID) 
)

INSERT INTO Students([Name]) VALUES
('Mila')
,('Toni')
,('Ron')

INSERT INTO Exams ([Name]) VALUES
('SpringMVC')
,('Neo4j')
,('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID) VALUES
(1, 101)
,(1, 102)
,(2, 101)
,(3, 103)
,(2, 102)
,(2, 103)


-- 04. Self-Referencing

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1)
	,[Name] VARCHAR (50) NOT NULL
	,ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers ([Name], ManagerID) VALUES
('John', NULL)
,('Maya', 106)
,('Silvia', 106)
,('Ted', 105)
,('Mark', 101)
,('Greta', 101)


--Problem 5. Online Store Database
CREATE TABLE ItemTypes
(
	ItemTypeID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items
(
	ItemID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities
(
	CityID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT IDENTITY PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID)
	CONSTRAINT INT PRIMARY KEY (OrderId, ItemID)
)



--Problem 6. University Database

CREATE TABLE Majors
(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Subjects
(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(10),
	StudentName VARCHAR(50),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount DECIMAL(5,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	CONSTRAINT INT PRIMARY KEY(StudentID, SubjectID)
)

SELECT * FROM Peaks
SELECT MountainRange, PeakName, Elevation 
	FROM Peaks AS p
	JOIN Mountains m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY Elevation DESC


SELECT GETDATE()