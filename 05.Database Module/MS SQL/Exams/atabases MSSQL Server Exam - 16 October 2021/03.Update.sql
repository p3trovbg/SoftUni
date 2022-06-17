UPDATE c
	SET PriceForSingleCigar = PriceForSingleCigar * 1.2
	FROM Cigars c
	LEFT JOIN Tastes t ON t.Id = c.TastId
	WHERE t.TasteType LIKE '%Spicy%'

UPDATE b
	SET b.BrandDescription = 'New description'
  FROM Brands b
  WHERE b.BrandDescription IS NULL 