/*
TRUNCATE TABLE [dbo].[LPCReport]
TRUNCATE TABLE [dbo].[Landmark]

ALTER TABLE [dbo].[Landmark] 
DROP CONSTRAINT FK_Landmark_LPCReport

*/

SELECT Name, Street, * FROM [dbo].[LPCReport]
WHERE Borough = 'Queens'

SELECT DISTINCT [Style] FROM [dbo].[LPCReport]

SELECT [Style], Count ([Style]) FROM [dbo].[LPCReport]
GROUP BY [Style]
ORDER BY Count ([Style]) DESC

SELECT LEN( [Style]) FROM [dbo].[LPCReport]
GROUP BY [Style]
ORDER BY LEN( [Style]) DESC

SELECT * FROM [dbo].[Landmark]

SELECT * FROM [dbo].[LPCReport] r
INNER JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
WHERE r.LPNumber = 'LP-00871'

SELECT l.LP_NUMBER, l.LM_NAME, l.STATUS,  * FROM [dbo].[LPCReport] r
RIGHT JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
WHERE r.LPNumber IS NULL

SELECT r.LPNumber,BBL, Count(*) FROM [dbo].[LPCReport] r
INNER JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
GROUP BY r.LPNumber, BBL
HAVING COUNT(*) = 4


SELECT  p.* FROM Landmark l 
INNER JOIN PLUTO p ON l.BBL = p.BBL
WHERE l.LP_NUMBER = 'LP-02039'



SELECT  p.* FROM PLUTO p 
INNER JOIN Landmark l  ON l.BBL = p.BBL
WHERE l.LP_NUMBER = 'LP-02039'






SELECT * FROM [LPCReport] 
ORDER BY Id
OFFSET (0) ROWS FETCH NEXT (20) ROWS ONLY

/**** Pluto ****/
SELECT COUNT(*) FROM PLUTO

SELECT TOP 10 * FROM PLUTO

SELECT BBL, COUNT(*) FROM PLUTO
GROUP BY BBL 
ORDER BY COUNT(*) DESC


 
SELECT [x].[Id], [x].[Address], [x].[BBL], [x].[Block], [x].[Borough], [x].[HistDist], [x].[Latitude], [x].[Longitude], [x].[Lot], [x].[LotArea], [x].[NumBldgs], [x].[OwnerName], [x].[XCoord], [x].[YCoord], [x].[YearBuilt]
FROM [Pluto] AS [x]
WHERE ([x].[Block] = 1) AND ([x].[Lot] = 10)


exec sp_executesql N'SELECT [param].[Id], [param].[Architect], [param].[Borough], [param].[DateDesignated], [param].[LPCId], [param].[LPNumber], [param].[Name], [param].[ObjectType], [param].[PhotoStatus], [param].[PhotoURL], [param].[Street], [param].[Style]
FROM [LPCReport] AS [param]
WHERE [param].[Borough] = @__request_Borough_0
ORDER BY (SELECT 1)
OFFSET @__p_1 ROWS FETCH NEXT @__p_2 ROWS ONLY',N'@__request_Borough_0 nvarchar(20),@__p_1 int,@__p_2 int',@__request_Borough_0=N'Manhattan',@__p_1=0,@__p_2=20