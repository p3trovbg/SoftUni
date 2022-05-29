--Ex.1
SELECT TOP(5)
	e.[EmployeeID]
   ,e.[JobTitle]
   ,e.[AddressID]
   ,a.[AddressText]
  FROM Employees AS e
  JOIN Addresses AS a ON(e.AddressID = a.AddressID)
 ORDER BY a.AddressID ASC

--Ex.2
SELECT TOP(50)
     e.[FirstName]
	,e.[LastName]
	,t.[Name] AS [Town]
	,a.[AddressText]
  FROM Employees e
  JOIN Addresses a ON a.AddressID = e.AddressID
  JOIN Towns t ON t.TownID = a.TownID
  ORDER BY e.[FirstName] ASC,
		   e.[LastName]

--Ex.3
SELECT 
	e.[EmployeeID]
   ,e.[FirstName]
   ,e.[LastName]
   ,d.[Name] AS DepartmentName
 FROM Employees e
 JOIN Departments d ON d.DepartmentID = e.DepartmentID
 WHERE d.[Name] = 'Sales'
 ORDER BY e.EmployeeID ASC


--Ex.4
SELECT TOP(5)
	e.[EmployeeID]
   ,e.[FirstName]
   ,e.[Salary]
   ,d.[Name] AS [DepartmentName]
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY d.DepartmentID ASC

--Ex.5
SELECT TOP(3)
	e.[EmployeeID]
   ,e.[FirstName]
  FROM Employees e
   LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
  WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID

--Ex.6
SELECT 
	e.[FirstName]
   ,e.[LastName]
   ,e.[HireDate]
   ,d.[Name] AS [DeptName]
 FROM Employees e
 INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
 WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
 ORDER BY e.HireDate ASC

--Ex.7
SELECT TOP(5)
	e.[EmployeeID]
   ,e.[FirstName]
   ,p.[Name]
   FROM Employees e
  INNER JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
  INNER JOIN Projects p ON ep.ProjectID = p.ProjectID
   AND  p.[StartDate] > '2002-08-13'
ORDER BY ep.[EmployeeID]

--Ex.8
SELECT TOP(5)
	e.[EmployeeID]
   ,e.[FirstName]
   ,(CASE
		WHEN DATEPART(YEAR, p.[StartDate]) >= 2005 THEN NULL
		ELSE p.[Name]
	END) 
	 AS [ProjectName]
   FROM Employees e
  LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
  LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE e.[EmployeeID] = 24 


--Ex.9
SELECT 
	 e.[EmployeeID]
	,e.[FirstName]
	,e.[ManagerID]
	,m.[FirstName]
  FROM Employees e
  INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
  WHERE e.ManagerID IN (3, 7)
  ORDER BY e.EmployeeID

--Ex.10
SELECT TOP(50)
	 e.[EmployeeID]
	,e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName]
	,m.[FirstName] + ' ' + m.[LastName] AS [ManagerName]
	,d.[Name] AS [DepartmentName]
  FROM Employees e
    JOIN Employees m ON e.ManagerID = m.EmployeeID
    JOIN Departments d ON d.DepartmentID = e.DepartmentID
  ORDER BY e.EmployeeID ASC

--Ex.11
SELECT TOP(1) AVG([Salary]) AS [MinAverageSalary]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [MinAverageSalary]

--=======================================================================
USE Geography

--Ex.12
SELECT 
	c.[CountryCode]
   ,m.[MountainRange]
   ,p.[PeakName]
   ,p.[Elevation]
  FROM Countries c
  INNER JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
  INNER JOIN Mountains m ON m.Id = mc.MountainId
  INNER JOIN Peaks p ON p.MountainId = mc.MountainId
  WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
  ORDER BY p.Elevation DESC


--Ex.13
SELECT 
	c.[CountryCode]
   ,COUNT(m.[MountainRange]) AS [MountainsRanges]
  FROM Countries c
  JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  JOIN Mountains m ON mc.MountainId = m.Id
 WHERE c.CountryName IN ('United States', 'Bulgaria', 'Russia')
 GROUP BY c.[CountryCode]

--Ex.14
SELECT TOP(5) 
	c.[CountryName]
   ,r.[RiverName]
	FROM Continents cont
	 LEFT JOIN Countries c ON c.ContinentCode = cont.ContinentCode
	 LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	 LEFT JOIN Rivers r ON r.Id = cr.RiverId
	WHERE cont.ContinentName = 'Africa'
	ORDER BY c.CountryName

--Ex.15
SELECT ContinentCode, CurrencyCode, Total AS CurrencyUsage
  FROM (
     SELECT 
    	 c.[ContinentCode]
    	,c.[CurrencyCode]
    	,COUNT(c.[CurrencyCode]) AS [Total]
    	,DENSE_RANK() OVER (PARTITION BY c.[ContinentCode] ORDER BY COUNT(c.[CurrencyCode]) DESC) AS [Ranked]
     FROM Countries c
	GROUP BY ContinentCode, CurrencyCode) AS k
WHERE k.[Ranked] = 1 AND k.[Total] > 1
ORDER BY ContinentCode


--Ex.16
SELECT COUNT(c.[CountryCode])
  FROM Countries c
  LEFT JOIN MountainsCountries m ON m.CountryCode = c.CountryCode  
  WHERE m.MountainId IS NULL

--Ex.17
SELECT TOP(5)
      c.[CountryName]
	 ,MAX(p.Elevation) AS HighestPeak
	 ,MAX(r.Length) AS LongestRiver
  FROM Countries c
  LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
  LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
  LEFT JOIN Rivers r ON r.Id = cr.RiverId
  GROUP BY CountryName
  ORDER BY HighestPeak DESC, LongestRiver DESC, CountryName

--Ex.18
SELECT TOP(5)
	k.[CountryName]
   ,k.[PeakName]
   ,k.[HighestPeak]
   ,k.[MountainRange]
  FROM (
  SELECT
      c.[CountryName]
	 ,ISNULL(p.[PeakName], '(no highest peak)') AS [PeakName]
 	 ,ISNULL(m.[MountainRange], '(no mountain)') AS [MountainRange]
	 ,ISNULL(MAX(p.Elevation), 0) AS HighestPeak
	 ,DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS [Ranked]
  FROM Countries c
  LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
  GROUP BY c.[CountryName], p.[PeakName], m.[MountainRange]) AS k
  WHERE [Ranked] = 1
  ORDER BY [CountryName], [PeakName]
