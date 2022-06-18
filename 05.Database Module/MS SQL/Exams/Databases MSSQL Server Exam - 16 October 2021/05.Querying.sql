--Problem 1
SELECT 
	CigarName,
	PriceForSingleCigar,
	ImageURL
  FROM Cigars
  ORDER BY PriceForSingleCigar ASC,
		   CigarName DESC

--Problem 2
SELECT 
	c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
  FROM Cigars c
  JOIN Tastes t ON t.Id = c.TastId
  WHERE t.TasteType IN ('Earthy', 'Woody')
  ORDER BY c.PriceForSingleCigar DESC

--Problem 3
SELECT Id,
       CONCAT(FirstName, ' ', LastName) AS ClientName,
	   Email 
  FROM Clients
 WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
 ORDER BY ClientName

--Problem 4
SELECT TOP(5) 
	CigarName,
	PriceForSingleCigar,
	ImageURL
  FROM Cigars c
   JOIN Sizes s ON s.Id = c.SizeId
  WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR
        c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
  ORDER BY c.CigarName ASC, c.PriceForSingleCigar DESC

--Problem 6
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(cig.PriceForSingleCigar)) AS CigarPrice
  FROM Clients c
  JOIN Addresses a ON a.Id = c.AddressId
  JOIN ClientsCigars cc ON cc.ClientId = c.Id
  JOIN Cigars cig ON cig.Id = cc.CigarId
 WHERE a.ZIP NOT LIKE '%[^0-9]%'
 GROUP BY c.FirstName, c.LastName, a.Id, a.Country, a.ZIP
 ORDER BY FullName

 --Problem 7
 GO

 CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
 RETURNS INT
 AS
 BEGIN 
	DECLARE @cigars INT
	SET @cigars = (SELECT COUNT(*)
      FROM Clients c
      JOIN ClientsCigars cc ON cc.ClientId = c.Id
      WHERE c.FirstName = @name)
	  RETURN @cigars
 END

 SELECT dbo.udf_ClientWithCigars('Betty')

--Problem 8

CREATE PROC usp_SearchByTaste(@taste VARCHAR(30))
AS
BEGIN	
	SELECT 
	 c.CigarName,
	 CONCAT('$', c.PriceForSingleCigar) Price,
	 t.TasteType,
	 b.BrandName,
	 CONCAT(s.Length, ' ', 'cm'),
	 CONCAT(s.RingRange, ' ', 'cm')
  FROM Cigars c
  JOIN Tastes t ON t.Id = c.TastId
  JOIN Brands b ON b.Id = c.BrandId
  JOIN Sizes s ON s.Id = c.SizeId
  WHERE t.TasteType = @taste
  ORDER BY s.Length ASC, s.RingRange DESC	
END
