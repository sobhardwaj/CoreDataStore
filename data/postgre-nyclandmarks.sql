

psql nyclandmarks postgres

SELECT * FROM pg_catalog.pg_tables
WHERE schemaname = 'public';


-- LPC Report
SELECT "Id", "Architect", "Borough", "DateDesignated", "LPCId", "LPNumber", "Name", "ObjectType", "PhotoStatus", "PhotoURL", "Street", "Style"
FROM public."LPCReport";




-- Landmark
ALTER TABLE "Landmark" ALTER COLUMN "CALEN_DATE" TYPE DATE 
using to_date("CALEN_DATE", 'YYYY-MM-DD');

ALTER TABLE public."Landmark" ALTER COLUMN "DESIG_DATE" TYPE DATE
using to_date("DESIG_DATE", 'YYYY-MM-DD');

ALTER TABLE public."Landmark" ALTER COLUMN "DESIG_DATE" TYPE DATE

SELECT 
     "Id", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", 
     "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", 
      "LAST_ACTIO", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER", "MOST_CURRE", 
      "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", 
       "STATUS", "STATUS_NOT", "VACANT_LOT"
  FROM "Landmark";
  LIMIT 10;

  
SELECT "Id", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER", "MOST_CURRE", "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE  "LP_NUMBER" = 'LP-00836';

SELECT "Id", "BBL", "LP_NUMBER","LM_NAME", "LM_TYPE", "BLOCK", "BOUNDARIES", "BoroughID",  "BIN_NUMBER", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO" "LOT", "LP_NUMBER", "MOST_CURRE", "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE  1 = 1 
--AND "LP_NUMBER" = 'LP-00664';
AND "LP_NUMBER" IN (
'LP-02158'
)
ORDER BY "LP_NUMBER","BBL"





SELECT "Id", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER", "MOST_CURRE", "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE  1 = 1 
AND "LP_NUMBER" = 'LP-00322'
ORDER BY "BLOCK"




SELECT id, "Borough", "Block", "Lot", "CD", "CT2010", "CB2010", "SchoolDist", "Council", "ZipCode", "FireComp", "PolicePrct", "HealthArea", "SanitBoro", "SanitDistrict", "SanitSub", "Address", "ZoneDist1", "ZoneDist2", "ZoneDist3", "ZoneDist4", "Overlay1", "Overlay2", "SPDist1", "SPDist2", "SPDist3", "LtdHeight", "SplitZone", "BldgClass", "LandUse", "Easements", "OwnerType", "OwnerName", "LotArea", "BldgArea", "ComArea", "ResArea", "OfficeArea", "RetailArea", "GarageArea", "StrgeArea", "FactryArea", "OtherArea", "AreaSource", "NumBldgs", "NumFloors", "UnitsRes", "UnitsTotal", "LotFront", "LotDepth", "BldgFront", "BldgDepth", "Ext", "ProxCode", "IrrLotCode", "LotType", "BsmtCode", "AssessLand", "AssessTot", "ExemptLand", "ExemptTot", "YearBuilt", "YearAlter1", "YearAlter2", "HistDist", "Landmark", "BuiltFAR", "ResidFAR", "CommFAR", "FacilFAR", "BoroCode", "BBL", "CondoNo", "Tract2010", "XCoord", "YCoord", "ZoneMap", "ZMCode", "Sanborn", "TaxMap", "EDesigNum", "APPBBL", "APPDate", "PLUTOMapID", "Version", "Latitude", "Longitude"
FROM public."PLUTO"
WHERE "BBL" = 1006360004 














LP-00040
LP-00070
LP-00072
LP-00080
LP-00085
LP-00088


SELECT DISTINCT("DESIG_DATE")
  FROM "Landmark";

SELECT DISTINCT("CALEN_DATE")
  FROM "Landmark";


--  Pluto
CREATE UNIQUE INDEX IDX_PLUTO_BBL ON public."PLUTO" ("BBL");


  
SELECT COUNT(*) FROM public."PLUTO"
  
  
SELECT id, "Borough", "Block", "Lot", "CD", "CT2010", "CB2010", "SchoolDist", 
"Council", "ZipCode", "FireComp", "PolicePrct", "HealthArea", "SanitBoro", "SanitDistrict", 
"SanitSub", "Address", "ZoneDist1", "ZoneDist2", "ZoneDist3", "ZoneDist4", 
"Overlay1", "Overlay2", "SPDist1", "SPDist2", "SPDist3", "LtdHeight", "SplitZone", "BldgClass", "LandUse",
"Easements", "OwnerType", "OwnerName", "LotArea", "BldgArea", "ComArea", "ResArea", "OfficeArea", "RetailArea", 
"GarageArea", "StrgeArea", "FactryArea", "OtherArea", "AreaSource", "NumBldgs", "NumFloors", "UnitsRes", "UnitsTotal", 
"LotFront", "LotDepth", "BldgFront", "BldgDepth", "Ext", "ProxCode", "IrrLotCode", "LotType", "BsmtCode", "AssessLand", 
"AssessTot", "ExemptLand", "ExemptTot", "YearBuilt", "YearAlter1", "YearAlter2", "HistDist", "Landmark", "BuiltFAR", 
"ResidFAR", "CommFAR", "FacilFAR", "BoroCode", "BBL", "CondoNo", "Tract2010", 
"XCoord", "YCoord", "ZoneMap", "ZMCode", "Sanborn", "TaxMap", "EDesigNum", "APPBBL", "APPDate", 
"PLUTOMapID", "Version", "Latitude", "Longitude"
FROM public."PLUTO"
WHERE "BBL" = 5000760200
LIMIT 1000;

  


SELECT id, "Address", "ZipCode","Borough",
"Landmark",
"XCoord", "YCoord", "BBL",
"Block","Lot", "Latitude","Longitude"
FROM public."PLUTO"
WHERE 1 = 1
AND HistDist = 1
--AND "Address" = '70 PINE STREET' AND "Borough" = 'MN'
AND 
LIMIT 1000;


SELECT "HistDist","Borough", COUNT(*)
FROM public."PLUTO"
GROUP BY "HistDist","Borough"
HAVING COUNT(*) > 1 AND "HistDist" != ''
ORDER BY "Borough","HistDist"



SELECT "Landmark" AS L1, * FROM public."PLUTO"
WHERE "Landmark" IS NOT NULL
ORDER BY "Landmark"

SELECT COUNT(*) FROM
(
SELECT p."BBL", * FROM public."LPCLocation" l
LEFT OUTER JOIN public."PLUTO" p ON l."BBL" = p."BBL"  
--WHERE l."BBL" IS NOT NULL
ORDER BY l."LPNumber"
) AS Total


SELECT "BBL"
FROM public."PLUTO"
GROUP BY "BBL"
HAVING COUNT(*) > 1


SELECT "Address", "BBL",id, "Borough", "Block", "Lot", "CD", "CT2010", "CB2010", "SchoolDist", "Council", "ZipCode", "FireComp", "PolicePrct", "HealthArea", "SanitBoro", "SanitDistrict", "SanitSub", "Address", "ZoneDist1", "ZoneDist2", "ZoneDist3", "ZoneDist4", "Overlay1", "Overlay2", "SPDist1", "SPDist2", "SPDist3", "LtdHeight", "SplitZone", "BldgClass", "LandUse", "Easements", "OwnerType", "OwnerName", "LotArea", "BldgArea", "ComArea", "ResArea", "OfficeArea", "RetailArea", "GarageArea", "StrgeArea", "FactryArea", "OtherArea", "AreaSource", "NumBldgs", "NumFloors", "UnitsRes", "UnitsTotal", "LotFront", "LotDepth", "BldgFront", "BldgDepth", "Ext", "ProxCode", "IrrLotCode", "LotType", "BsmtCode", "AssessLand", "AssessTot", "ExemptLand", "ExemptTot", "YearBuilt", "YearAlter1", "YearAlter2", "HistDist", "Landmark", "BuiltFAR", "ResidFAR", "CommFAR", "FacilFAR", "BoroCode", "BBL", "CondoNo", "Tract2010", "XCoord", "YCoord", "ZoneMap", "ZMCode", "Sanborn", "TaxMap", "EDesigNum", "APPBBL", "APPDate", "PLUTOMapID", "Version", "Latitude", "Longitude"
FROM public."PLUTO"
WHERE 1 = 1
AND "Address" LIKE '%STATE STREET%'
--AND "Address" = '291 STATE STREET'
ORDER BY "Address"
LIMIT 120;














159 JOHN STREET
130 BOWERY
32 PRINCE STREET












-- LPC Location
SELECT "Id", "LPNumber", "Name", "BBL", "ObjectType", "Street", "Address", "Neighborhood", "Borough", "ZipCode", "Block", "Lot", "Latitude", "Longitude"
FROM public."LPCLocation"
WHERE "Latitude" isnull;

UPDATE public."LPCLocation"
SET "Latitude"= 40.7788082, "Longitude"= -73.9226516
WHERE "LPNumber"='LP-02196';









select "Address","LPNumber",* from "LPCLocation"
WHERE "LPNumber" = 'LP-00708'
ORDER BY  "LPNumber"
LIMIT 500;
 
 

-- LPC Lamppost
ALTER TABLE public."LPCLamppost" ADD "Neighborhood" varchar(200);


SELECT "Id", "PostId", "Type", "SubType", "Block", "Lot", "Borough" , "Located", "Latitude", "Longitude"
FROM public."LPCLamppost"
WHERE "Borough" = 'Manhattan';

UPDATE public."LPCLamppost"
--SET "Borough" ='BK'
--WHERE "Borough" = 'Brooklyn';






  SELECT "l"."Id", "l"."Name", "l"."LPNumber", "l"."ObjectType", "l"."Street", "l"."Borough", CASE
	    WHEN "l"."Id" IS NOT NULL AND "l"."Address" IS NOT NULL
	    THEN "l"."Address" ELSE NULL
	END AS "Address", "l"."Neighborhood", "l"."BBL", "l"."Latitude", "l"."Longitude", "l"."Lot", "l"."Block", CASE
    WHEN "l"."Id" IS NOT NULL AND "l"."ZipCode" IS NOT NULL
	    THEN "l"."ZipCode" ELSE NULL
	END AS "ZipCode"
	FROM "LPCLocation" AS "l"













