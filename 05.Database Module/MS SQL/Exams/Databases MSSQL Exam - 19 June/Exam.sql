CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT REFERENCES Owners(Id),
	AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
	CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

GO
--CRUD Operations

INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES
('Anita Kostova'	,'0896365412',	'Sofia, 5 Rosa str.',	15,	1),
('Dimitur Stoev'	,'0877564223',	null,	42,	4),
('Kalina Evtimova'	,'0896321112',	'Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov'	,'0898564100',	'Montana, 1 Bor str.',	18,	8),
('Boryana Mileva'	,'0888112233',	null,	31,	5)

INSERT INTO Animals (Name, BirthDate, OwnerId, AnimalTypeId) VALUES
('Giraffe',			'2018-09-21',	21,	1),
('Harpy Eagle',		'2015-04-17',	15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',			'2021-06-30',	2,	4)


UPDATE Animals
	SET OwnerId = 4
  WHERE OwnerId IS NULL

--Delete
DELETE Volunteers WHERE DepartmentId = 2
DELETE VolunteersDepartments WHERE DepartmentName = 'Education program assistant'

--Querying part
SELECT
	v.Name,
	v.PhoneNumber,
	v.Address,
	v.AnimalId,
	v.DepartmentId
  FROM Volunteers v
  ORDER BY Name ASC, AnimalId DESC, DepartmentId ASC

--Problem 2
SELECT 
	a.Name,
	ant.AnimalType,
	FORMAT(a.BirthDate, 'dd.MM.yyyy') BirthDate
  FROM Animals a
  JOIN AnimalTypes ant ON ant.Id = a.AnimalTypeId
  ORDER BY a.Name ASC

--Problem 3
SELECT TOP(5)
	o.Name,
	COUNT(o.Name) CountOfAnimals
  FROM Owners o
  JOIN Animals a ON a.OwnerId = o.Id
  GROUP BY o.Name
  ORDER BY COUNT(o.Name) DESC, o.Name ASC

--Problem 4
SELECT 
	CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals,
	o.PhoneNumber,
	c.Id AS CageId
  FROM Owners AS o
   JOIN Animals a ON a.OwnerId = o.Id
   JOIN AnimalTypes ant ON ant.Id = a.AnimalTypeId
   JOIN AnimalsCages ac ON ac.AnimalId = a.Id
   JOIN Cages c ON c.Id = ac.CageId
   WHERE ant.AnimalType = 'mammals'
  ORDER BY o.[Name] ASC, a.[Name] DESC

--Problem 5
SELECT 
	v.Name,
	v.PhoneNumber,
	SUBSTRING(v.Address, CHARINDEX(',', v.Address) + 2, LEN(v.[Address]))
  FROM Volunteers v
  JOIN VolunteersDepartments d ON d.Id = v.DepartmentId
  WHERE d.DepartmentName = 'Education program assistant' AND 
		v.[Address] LIKE '%Sofia%'
ORDER BY v.Name

--Problem 6
SELECT 
	a.Name,
	DATEPART(YEAR,a.BirthDate) AS BirthYear,
	aty.AnimalType
  FROM Animals a
  JOIN AnimalTypes aty ON aty.Id = a.AnimalTypeId
  WHERE a.OwnerId IS NULL AND 
       (DATEPART(YEAR,a.BirthDate) > 2017 AND aty.AnimalType != 'Birds')
	ORDER BY a.Name


--Problem 7
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	SET @result = (SELECT 
	COUNT(*)
  FROM Volunteers v
  JOIN VolunteersDepartments d ON d.Id = v.DepartmentId
  WHERE d.DepartmentName = @VolunteersDepartment
  GROUP BY d.Id)
  RETURN @result
END

GO
--Problem 8
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50))
AS
BEGIN
	SELECT
	@AnimalName,
	CASE 
	 WHEN a.OwnerId IS NULL THEN 'For adoption'
	 ELSE o.Name
	END
  FROM Animals a
  LEFT JOIN Owners o ON o.Id = a.OwnerId
  WHERE a.Name = @AnimalName
END



EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
  