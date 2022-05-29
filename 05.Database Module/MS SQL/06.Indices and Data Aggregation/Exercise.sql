--Ex.1
SELECT 
   COUNT(*) 
  FROM WizzardDeposits AS [Count]

--Ex.2
SELECT MAX(MagicWandSize)
  FROM WizzardDeposits

--Ex.3
SELECT DepositGroup
	  ,MAX(MagicWandSize)
  FROM WizzardDeposits
  GROUP BY DepositGroup

--Ex.4
SELECT TOP(2)
	DepositGroup
  FROM WizzardDeposits
  GROUP BY DepositGroup
  ORDER BY AVG(MagicWandSize) ASC

--Ex.5
  SELECT
	DepositGroup
	,SUM(DepositAmount)
  FROM WizzardDeposits
  GROUP BY DepositGroup

--Ex.6
    SELECT
	DepositGroup
	,SUM(DepositAmount)
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup

--Ex.7
   SELECT
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
  ORDER BY TotalSum DESC

--Ex.8
SELECT
	DepositGroup
   ,MagicWandCreator
   ,MIN(DepositCharge) AS [MinDepositCharge]
  FROM WizzardDeposits
  GROUP BY DepositGroup,MagicWandCreator
  ORDER BY MagicWandCreator, DepositGroup

--Ex.9
SELECT 
	AgeByGroup AgeGroup, COUNT(AgeByGroup) AS [WizardCount]
FROM (SELECT 
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		 END AS AgeByGroup
		FROM WizzardDeposits) AgeByGroupTable
GROUP BY AgeByGroup

--Ex.10
SELECT 
  LEFT(FirstName, 1) AS FirstLatter
  FROM WizzardDeposits
  WHERE DepositGroup = 'Troll Chest'
  GROUP BY LEFT(FirstName, 1)
  ORDER BY FirstLatter

--Ex.11
SELECT 
	DepositGroup
	,IsDepositExpired
	,AVG(DepositInterest) [AverageInterest]
  FROM WizzardDeposits
  WHERE DepositStartDate > '1985-01-01'
  GROUP BY DepositGroup, IsDepositExpired
  ORDER BY DepositGroup DESC

  SELECT * FROM WizzardDeposits