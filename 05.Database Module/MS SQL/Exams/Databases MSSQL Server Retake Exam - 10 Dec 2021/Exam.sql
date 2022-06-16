
CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(100) UNIQUE NOT NULL,
	Email NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) UNIQUE NOT NULL,
	LastName NVARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10) 
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName NVARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer NVARCHAR(25) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition NCHAR(1) NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id),
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName NVARCHAR(70) UNIQUE NOT NULL,
	Country NVARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

--Problem 2
INSERT INTO Passengers(FullName, Email)
SELECT 
	p.FirstName + ' ' + p.LastName AS FullName,
	p.FirstName + p.LastName + '@gmail.com' AS Email
  FROM Pilots p
  WHERE p.Id BETWEEN 5 AND 15

--Problem 3
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') AND
      (FlightHours IS NULL OR FlightHours <= 100) AND
	  [Year] >= 2013

--Problem 4
DELETE Passengers
 WHERE LEN(FullName) <= 10

--Problem 5
SELECT 
     Manufacturer,
	 Model,
	 FlightHours,
	 Condition
  FROM Aircraft
  ORDER BY FlightHours DESC


--Problem 6
SELECT 
	p.FirstName,
	p.LastName,
	a.Manufacturer,
	a.Model,
	a.FlightHours
  FROM Pilots p
  JOIN PilotsAircraft pa ON pa.PilotId = p.Id
  JOIN Aircraft a ON pa.AircraftId = a.Id
  WHERE FlightHours <  304
  ORDER BY FlightHours DESC, FirstName ASC

--Problem 7
SELECT TOP(20) 
	fd.Id,
	fd.Start,
	p.FullName,
	a.AirportName,
	fd.TicketPrice
  FROM FlightDestinations fd
   JOIN Passengers p ON p.Id = fd.PassengerId
   JOIN Airports a ON a.Id = fd.AirportId
   WHERE DATEPART(DAY,fd.Start) % 2 = 0
  ORDER BY fd.TicketPrice DESC, a.AirportName ASC

--Problem 8
SELECT 
	a.Id,
	a.Manufacturer,
	a.FlightHours,
	(SELECT COUNT(Id) Id FROM FlightDestinations fd 
		WHERE fd.AircraftId = a.Id) FlightDestinationsCount,
		ROUND((SELECT AVG(fd.TicketPrice) FROM FlightDestinations fd 
				WHERE fd.AircraftId = a.Id), 2) AvgPrice
  FROM Aircraft a
  WHERE (SELECT COUNT(Id) Id FROM FlightDestinations fd 
				WHERE fd.AircraftId = a.Id) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id

--Problem 9
SELECT 
	p.FullName,
	COUNT(a.Id) CountOfAircraft,
	SUM(fd.TicketPrice) TotalPayed
  FROM Passengers p
  JOIN FlightDestinations fd ON fd.PassengerId = p.Id
  JOIN Aircraft a ON a.Id = fd.AircraftId
  GROUP BY p.FullName
  HAVING COUNT(a.Id) > 1 AND SUBSTRING(p.FullName, 2, 1) = 'a'
  ORDER BY p.FullName

--Problem 10
