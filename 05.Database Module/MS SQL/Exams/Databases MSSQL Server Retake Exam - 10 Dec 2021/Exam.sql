CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	Year INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PilotID INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) NOT NULL,
	Country VARCHAR(100) NOT NULL
)

CREATE TABLE FlightDestinations
(
	Id INT IDENTITY PRIMARY KEY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	Start DATETIME2 NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL
)


--Insert
INSERT INTO Passengers(FullName, Email)
SELECT 
	p.FirstName + ' ' + p.LastName AS FullName,
	p.FirstName + p.LastName + '@gmail.com' AS Email
  FROM Pilots p
  WHERE p.Id BETWEEN 5 AND 15

--Update
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') AND
      (FlightHours IS NULL OR FlightHours <= 100) AND
	  Year >= 2013

--Delete
DELETE Passengers WHERE LEN(FullName) <= 10


--==============================================================
SELECT 
	Manufacturer,
	Model,
	FlightHours,
	Condition
FROM Aircraft
ORDER BY FlightHours DESC

--==============================================================
SELECT 
		p.FirstName,
		p.LastName,
		a.Manufacturer,
		a.Model,
		a.FlightHours
  FROM Aircraft a
  JOIN PilotsAircraft pa ON pa.AircraftId = a.Id
  JOIN Pilots p ON p.Id = pa.PilotID
  WHERE a.FlightHours < 304
  ORDER BY a.FlightHours DESC, p.FirstName ASC

--==============================================================

SELECT TOP(20) 
		fd.Id AS DestinationId,
		fd.Start,
		p.FullName,
		a.AirportName,
		fd.TicketPrice
   FROM FlightDestinations fd
   JOIN Airports a ON a.Id = fd.AirportId
   JOIN Passengers p ON p.Id = fd.PassengerId
   WHERE DATEPART(DAY,fd.Start) % 2 = 0
   ORDER BY TicketPrice DESC, AirportName ASC


--==============================================================

SELECT 
	a.Id,
	a.Manufacturer,
	a.FlightHours,
	COUNT(fd.AircraftId) AS d
  FROM Aircraft a
  JOIN FlightDestinations fd ON fd.AircraftId = a.Id 

SELECT * FROM Aircraft
SELECT * FROM FlightDestinations