<<<<<<< HEAD

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(100) UNIQUE NOT NULL,
	Email NVARCHAR(50) UNIQUE NOT NULL
=======
CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) NOT NULL,
	Email VARCHAR(50) NOT NULL
>>>>>>> refs/remotes/origin/main
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
<<<<<<< HEAD
	FirstName NVARCHAR(30) UNIQUE NOT NULL,
	LastName NVARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10) 
=======
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age TINYINT CHECK(Age BETWEEN 21 AND 62) NOT NULL,
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10)
>>>>>>> refs/remotes/origin/main
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
<<<<<<< HEAD
	TypeName NVARCHAR(30) UNIQUE NOT NULL
=======
	TypeName VARCHAR(30) NOT NULL
>>>>>>> refs/remotes/origin/main
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
<<<<<<< HEAD
	Manufacturer NVARCHAR(25) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition NCHAR(1) NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
=======
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	Year INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
>>>>>>> refs/remotes/origin/main
)

CREATE TABLE PilotsAircraft
(
<<<<<<< HEAD
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id),
	PRIMARY KEY(AircraftId, PilotId)
=======
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PilotID INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL
>>>>>>> refs/remotes/origin/main
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
<<<<<<< HEAD
	AirportName NVARCHAR(70) UNIQUE NOT NULL,
	Country NVARCHAR(100) UNIQUE NOT NULL
=======
	AirportName VARCHAR(70) NOT NULL,
	Country VARCHAR(100) NOT NULL
>>>>>>> refs/remotes/origin/main
)

CREATE TABLE FlightDestinations
(
<<<<<<< HEAD
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

--Problem 2
=======
	Id INT IDENTITY PRIMARY KEY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	Start DATETIME2 NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL
)


--Insert
>>>>>>> refs/remotes/origin/main
INSERT INTO Passengers(FullName, Email)
SELECT 
	p.FirstName + ' ' + p.LastName AS FullName,
	p.FirstName + p.LastName + '@gmail.com' AS Email
  FROM Pilots p
  WHERE p.Id BETWEEN 5 AND 15

<<<<<<< HEAD
--Problem 3
=======
--Update
>>>>>>> refs/remotes/origin/main
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') AND
      (FlightHours IS NULL OR FlightHours <= 100) AND
<<<<<<< HEAD
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
=======
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

>>>>>>> refs/remotes/origin/main
SELECT 
	a.Id,
	a.Manufacturer,
	a.FlightHours,
<<<<<<< HEAD
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
=======
	COUNT(fd.AircraftId) AS d
  FROM Aircraft a
  JOIN FlightDestinations fd ON fd.AircraftId = a.Id 

SELECT * FROM Aircraft
SELECT * FROM FlightDestinations
>>>>>>> refs/remotes/origin/main
