/*
use [NycLandmarks]
ALTER DATABASE [NycLandmarks] SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
ALTER DATABASE [NycLandmarks] SET MULTI_USER

TRUNCATE TABLE [dbo].[LPCReport]
TRUNCATE TABLE [dbo].[Landmark]

ALTER TABLE [dbo].[Landmark] 
DROP CONSTRAINT FK_Landmark_LPCReport

*/

/** LPC Report **/

SELECT Name, Street, * FROM [dbo].[LPCReport]
WHERE Borough = 'Queens'

SELECT DISTINCT [Style] FROM [dbo].[LPCReport]

SELECT MAX(LEN([PhotoURL])) FROM [dbo].[LPCReport]

SELECT [Style], Count ([Style]) FROM [dbo].[LPCReport]
GROUP BY [Style]
ORDER BY Count ([Style]) DESC

SELECT  [Style] FROM [dbo].[LPCReport]
GROUP BY [Style]
ORDER BY [Style] ASC

SELECT 
CASE WHEN LEN(PhotoURL) <> 0 
THEN 1
  ELSE 0 
 END Status
 FROM [dbo].[LPCReport]
 ORDER BY ID

 UPDATE
    [dbo].[LPCReport]
    SET [PhotoStatus] =  CASE WHEN LEN(PhotoURL) <> 0 
						  THEN 1 ELSE 0 END 
    FROM [dbo].[LPCReport]

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


SELECT  l.PLUTO_ADDR FROM Landmark l 
WHERE l.LP_NUMBER = 'LP-02039'

SELECT  l.PLUTO_ADDR, l.* FROM Landmark l 
WHERE l.LP_NUMBER = 'LP-00005'
ORDER BY  l.PLUTO_ADDR

SELECT  l.* FROM Landmark l 
WHERE l.LP_NUMBER = 'LP-02039'

SELECT l.DESIG_ADDR, l.PLUTO_ADDR,  l.* FROM Landmark l 
WHERE l.DESIG_ADDR <> l.PLUTO_ADDR
ORDER BY l.DESIG_ADDR



SELECT  p.* FROM PLUTO p 
INNER JOIN Landmark l  ON l.BBL = p.BBL
WHERE l.LP_NUMBER = 'LP-02039'

SELECT * FROM [LPCReport] 
ORDER BY Id
OFFSET (0) ROWS FETCH NEXT (20) ROWS ONLY


    ALTER TABLE [dbo].[Landmark]
    ADD CONSTRAINT [FK_Landmark_LPCReport_LP_NUMBER] FOREIGN KEY ([LP_NUMBER]) REFERENCES [dbo].[LPCReport] ([LPNumber])
   
   
    ALTER TABLE [dbo].[Landmark]
	ADD CONSTRAINT [AK_Landmark_BBL] UNIQUE NONCLUSTERED ([BBL] ASC)

	SELECT BBL, COUNT(*)  FROM [dbo].[Landmark]
	GROUP BY BBL
    HAVING COUNT(*) > 1
	
	SELECT *  FROM [dbo].[Landmark]
	WHERE BBL = 4007990040




/** LPC Location **/

SELECT r.LPNumber as r, l.LPNumber As l, 
r.Name as RNAME, l.Name As LNAME,
r.Id as RID, l.Id as IID,  * FROM [LPCReport] r
INNER JOIN [LPCLocation] l ON r.LPNumber = l.LPNumber
WHERE 1 = 1 
--AND r.Id <> l.Id
--AND r.Name <> l.Name
ORDER BY r.LPNumber 

SELECT r.LPNumber as r, l.LPNumber As l, * FROM [LPCReport] r
LEFT OUTER JOIN [LPCLocation] l ON r.LPNumber = l.LPNumber

CREATE INDEX IDX_LPCLocation_LPNumber
ON [LPCLocation] (LPNumber);

CREATE UNIQUE INDEX UNQ_LPCLocation_LPNumber
ON [LPCLocation] (LPNumber); 


/** Landmark **/

SELECT COUNT(*) FROM [dbo].[Landmark]






/**** Pluto ****/
SELECT p.*
FROM Landmark l
INNER JOIN PLUTO p ON 
l.BLOCK = p.Block AND  l.LOT = p.Lot  AND  l.BoroughID = p.Borough
WHERE 1 = 1
AND l.LP_NUMBER = 'LP-02039'






SELECT COUNT(*) FROM PLUTO

SELECT TOP 10 * FROM PLUTO

SELECT BBL, COUNT(*) FROM PLUTO
GROUP BY BBL 
ORDER BY COUNT(*) DESC

/** LPC Lamppost **/
SELECT Id, PostId, "Type", SubType, Block, Lot, Borough, Located, Latitude, Longitude
FROM NycLandmarks.dbo.LPCLamppost
WHERE PostId = 10;


SELECT [x].[Id], [x].[Address], [x].[BBL], [x].[Block], [x].[Borough], [x].[HistDist], [x].[Latitude], [x].[Longitude], [x].[Lot], [x].[LotArea], [x].[NumBldgs], [x].[OwnerName], [x].[XCoord], [x].[YCoord], [x].[YearBuilt]
FROM [Pluto] AS [x]
WHERE ([x].[Block] = 1) AND ([x].[Lot] = 10)


