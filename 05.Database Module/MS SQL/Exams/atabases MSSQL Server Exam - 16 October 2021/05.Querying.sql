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
