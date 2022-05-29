--Problem 15. Hotel Database

--CREATE DATABASE Hotel

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(50),
	Notes VARCHAR(MAX)
)

--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName VARCHAR(50),
	EmergencyNumber VARCHAR(50),
	Notes VARCHAR(MAX)
)

--•	RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(20) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

--•	RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

--•	BedTypes (BedType, Notes)
CREATE TABLE BedTypes
(
	BedType VARCHAR(20) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes([RoomType]),
	BedType VARCHAR(20) FOREIGN KEY REFERENCES BedTypes([BedType]),
	Rate DECIMAL(5,2),
	RoomStatus VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]),
	Notes VARCHAR(MAX)

)
--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME2,
	AccountNumber VARCHAR(20) NOT NULL,
	FirstDateOccupied DATETIME2,
	LastDateOccupied DATETIME2,
	TotalDays INT,
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(5,2),
	TaxAmount DECIMAL(5,2),
	PaymentTotal DECIMAL (5,2),
	Notes VARCHAR(MAX)
)

--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME2,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(5,2),
	PhoneCharge BIT,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
	('Gosho', 'Peshov', NULL, NULL),
	('Misho', 'Peshov', NULL, NULL),
	('Tosho', 'Peshov', NULL, NULL)


INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
	('Ivan', 'Petrov', 111111, NULL, NULL, NULL),
	('Martin', 'Georgiev', 222222, NULL, NULL, NULL),
	('Georgi', 'Vasilev', 333333, NULL, NULL, NULL)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
	('FREE', NULL),
	('OCCUPIED', NULL),
	('RESERVE', NULL)

INSERT INTO RoomTypes VALUES
	('Single', NULL),
	('Double', NULL),
	('King', NULL)

INSERT INTO BedTypes VALUES
	('Lux', NULL),
	('Queen', NULL),
	('Retro', NULL)

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('King', 'Lux', NULL, 'RESERVE', NULL),
('Single', 'Retro', NULL, 'OCCUPIED', NULL),
('Double', 'Queen', NULL, 'FREE', NULL)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, TotalDays, AmountCharged, PaymentTotal) VALUES
(2, '2022-02-05', 2, 20, NULL, 200.20),
(3, '2023-11-27', 3, 10, NULL, 300.30),
(1, '2014-03-08', 1, 5, NULL, 500.50)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber) VALUES
(2, 1, 3),
(3, 2, 1),
(1, 3, 2)

--Use Hotel database and decrease tax rate by 3% to all payments. Then select only TaxRate column from the Payments table. Submit your query statements as Prepare DB & Run queries.
UPDATE Payments
SET TaxRate = TaxRate * 0.97
SELECT Payments.TaxRate FROM Payments

DELETE FROM Occupancies