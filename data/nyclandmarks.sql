/*
TRUNCATE TABLE [dbo].[LPCReport]
TRUNCATE TABLE [dbo].[Landmark]

ALTER TABLE [dbo].[Landmark] 
DROP CONSTRAINT FK_Landmark_LPCReport

*/

SELECT Name, Street, * FROM [dbo].[LPCReport]
WHERE Borough = 'Queens'

SELECT * FROM [dbo].[Landmark]


SELECT * FROM [dbo].[LPCReport] r
INNER JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
WHERE r.LPNumber = 'LP-00871'

SELECT l.LP_NUMBER, l.LM_NAME, l.STATUS,  * FROM [dbo].[LPCReport] r
RIGHT JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
WHERE r.LPNumber IS NULL


SELECT r.LPNumber, Count(*) FROM [dbo].[LPCReport] r
INNER JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
GROUP BY r.LPNumber
HAVING COUNT(*) = 4




