CREATE DATABASE Airport 

CREATE TABLE Passengers
(
	Id INT IDENTITY PRIMARY KEY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
	Id INT IDENTITY PRIMARY KEY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT IDENTITY PRIMARY KEY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
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
	Id INT IDENTITY PRIMARY KEY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations 
(
	Id INT IDENTITY PRIMARY KEY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

-- Problem 9
SELECT 
	p.FullName,
	COUNT(a.Id) CountOfAircraft,
	SUM(fd.TicketPrice) TotalPayed
  FROM Passengers p
  JOIN FlightDestinations fd ON fd.PassengerId = p.Id
  JOIN Aircraft a ON a.Id = fd.AircraftId
  GROUP BY p.FullName
 HAVING COUNT(a.Id) > 1 AND
        SUBSTRING(p.FullName, 2, 1) = 'a'
  ORDER BY p.FullName

-- Problem 10
SELECT 
	a.AirportName,
	fd.Start,
	fd.TicketPrice,
	p.FullName,
	ac.Manufacturer,
	ac.Model
  FROM FlightDestinations fd
  LEFT JOIN Airports a ON a.Id = fd.AirportId
  LEFT JOIN Passengers p ON p.Id = fd.PassengerId
  LEFT JOIN Aircraft ac ON ac.Id = fd.AircraftId
  WHERE (DATEPART(HOUR, fd.Start) BETWEEN 6 AND 20) AND 
         fd.TicketPrice > 2500
  ORDER BY ac.Model ASC


--Problem 11
GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email NVARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @destinations INT
	SET @destinations = (SELECT COUNT(p.Id) 
						   FROM Passengers p
						   JOIN FlightDestinations fd ON fd.PassengerId = p.Id
						  WHERE p.Email LIKE @email)
	RETURN @destinations
END

GO
--Problem 12
CREATE PROC usp_SearchByAirportName(@airportName NVARCHAR(70))
AS
BEGIN
	SELECT 
	ap.AirportName,
	p.FullName,
	CASE 
		WHEN fd.TicketPrice <= 400 THEN 'Low'
		WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
		ELSE 'High'
	END AS [LevelOfTickerPrice],
	ac.Manufacturer,
	ac.Condition,
	act.TypeName
  FROM Airports ap
  JOIN FlightDestinations fd ON fd.AirportId = ap.Id
  JOIN Aircraft ac ON ac.Id = fd.AircraftId
  JOIN Passengers p ON p.Id = fd.PassengerId
  JOIN AircraftTypes act ON act.Id = ac.TypeId
 WHERE ap.AirportName = @airportName
 ORDER BY ac.Manufacturer, p.FullName
END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'
