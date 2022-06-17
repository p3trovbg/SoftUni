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