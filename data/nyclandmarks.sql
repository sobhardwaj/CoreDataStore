

SELECT * FROM [dbo].[LPCReport]
SELECT * FROM [dbo].[Landmark]


SELECT * FROM [dbo].[LPCReport] r
INNER JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
WHERE r.LPNumber = 'LP-00871'

SELECT * FROM [dbo].[LPCReport] r
RIGHT JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
WHERE r.LPNumber IS NULL




SELECT r.LPNumber, Count(*) FROM [dbo].[LPCReport] r
INNER JOIN [dbo].[Landmark] l on r.LPNumber = l.LP_NUMBER
GROUP BY r.LPNumber
HAVING COUNT(*) = 





LP-00001