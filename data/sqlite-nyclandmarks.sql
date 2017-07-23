DELETE FROM LPCReport;


SELECT COUNT(*) FROM LPCReport
WHERE PhotoStatus = 1; 

SELECT Id, Name, LPCId, LPNumber, ObjectType, Architect, "Style", Street, Borough, DateDesignated, PhotoStatus, PhotoURL
FROM LPCReport
WHERE PhotoStatus = 1
LIMIT 100;




 UPDATE
    LPCReport
    SET PhotoStatus =  CASE 
                       WHEN length(PhotoURL) <> 0 THEN 1 
                       ELSE 0
                       END;

