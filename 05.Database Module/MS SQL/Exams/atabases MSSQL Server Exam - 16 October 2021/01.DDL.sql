CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT CHECK([Length] BETWEEN 10 AND 25) NOT NULL,
	RingRange DECIMAL (18,2) CHECK(RingRange BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType NVARCHAR(20) NOT NULL,
	TasteStrength NVARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL,
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName NVARCHAR(30) UNIQUE NOT NULL,
	BrandDescription NVARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName NVARCHAR(80) NOT NULL,
	BrandId INT NOT NULL REFERENCES Brands(Id),
	TastId INT NOT NULL REFERENCES Tastes(Id),
	SizeId INT NOT NULL REFERENCES Sizes(Id),
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town NVARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP NVARCHAR(20) NOT NULL,
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars
(
	ClientId INT REFERENCES Clients(Id),
	CigarId INT REFERENCES Cigars(Id),
	PRIMARY KEY(ClientId, CigarId)
)
