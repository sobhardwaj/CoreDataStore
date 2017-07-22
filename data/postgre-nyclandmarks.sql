
psql nyclandmarks postgres
pg_restore -U postgres -d nyclandmarks  /data/dump-nyclandmarks-201707200843.backup

SELECT * FROM pg_catalog.pg_tables
WHERE schemaname = 'public';

CREATE DATABASE nyclandmarks_ef;

select pg_terminate_backend(pid) from pg_stat_activity where datname='nyclandmarks_ef';
DROP DATABASE nyclandmarks_ef;


 -- LPC Report 
CREATE UNIQUE INDEX IDX_LPCReport_LPNumber ON public."LPCReport" ("LPNumber");

ALTER TABLE public."LPCReport"
ADD CONSTRAINT "FK_LPCReport_LPCLocation_LPNumber" FOREIGN KEY ("LPNumber") REFERENCES public."LPCLocation"("LPNumber") ON DELETE CASCADE;

ALTER TABLE  public."LPCReport" ALTER COLUMN  "Style" TYPE varchar(100) ;


SELECT "Id", "Architect", "Borough", "DateDesignated", "LPCId", "LPNumber", "Name", "ObjectType", "PhotoStatus", "PhotoURL", "Street", "Style"
FROM public."LPCReport"
ORDER BY "LPNumber";


-- ########### Landmarks #####################
TRUNCATE TABLE public."Landmark"
DELETE FROM public."Landmark";

ALTER TABLE  public."Landmark" ALTER COLUMN  "LM_TYPE" TYPE varchar(50) ;
ALTER TABLE  public."Landmark" ADD COLUMN "OBJECTID" int8 NOT NULL;
ALTER TABLE  public."Landmark" ADD COLUMN "Latitude" numeric(9,6) NOT NULL;
ALTER TABLE  public."Landmark" ADD COLUMN "Longitude" numeric(9,6) NOT NULL;

ALTER TABLE public."Landmark" 
ADD CONSTRAINT "FK_Landmark_LPCReport_LP_NUMBER" FOREIGN KEY ("LP_NUMBER") REFERENCES public."LPCReport"("LPNumber");

SELECT MAX("Id") FROM public."Landmark";
SELECT nextval('public."Landmark_Id_seq"');
SELECT setval('public."Landmark_Id_seq"', (SELECT MAX("Id") FROM public."LPCLocation"));
SELECT setval('public."Landmark_Id_seq"', COALESCE((SELECT MAX("Id") FROM public."Landmark"), 1), false);



SELECT COUNT(*) FROM public."Landmark";

SELECT "Id", "OBJECTID", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER" ,"BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO",  "Latitude", "Longitude", "MOST_CURRE", "NON_BLDG", "OBJECTID", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
ORDER BY "LP_NUMBER"





SELECT "Id", "LM_NAME", "LP_NUMBER",  "OBJECTID",  "LM_TYPE","NON_BLDG", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", 
"DESIG_DATE", "HIST_DISTR", "LAST_ACTIO",  "LM_TYPE", "LOT",  "Latitude", "Longitude", "MOST_CURRE", 
"NON_BLDG", "OBJECTID", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE 1 = 1
--AND "LP_NUMBER" = 'LP-00972'
AND "LM_NAME" LIKE '%Ocean Parkway%'
--AND "BBL" = 1002670019,
--AND "PLUTO_ADDR"  LIKE '%Amsterdam%' 
--AND "OBJECTID" = 3182
ORDER BY 
"LP_NUMBER" ,"OBJECTID" 
--LIMIT 100;



SELECT "BBL","BIN_NUMBER", COUNT(*)
FROM public."Landmark"
GROUP BY "BBL","BIN_NUMBER"
HAVING COUNT(*) > 1 

SELECT "LP_NUMBER","LM_TYPE", COUNT(*)
FROM public."Landmark"
GROUP BY "LP_NUMBER","LM_TYPE"

SELECT "OBJECTID", COUNT(*)
FROM public."Landmark"
GROUP BY "OBJECTID"
HAVING COUNT(*) > 1 

SELECT "Id",   "Latitude", "Longitude"
FROM public."Landmark"
WHERE "Longitude" IS  NULL



SELECT "LP_NUMBER","LM_NAME"
FROM public."Landmark"
GROUP BY "LP_NUMBER","LM_NAME"
HAVING COUNT(*) = 1
ORDER BY "LP_NUMBER"

SELECT 
     "Id", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", 
     "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", 
      "LAST_ACTIO", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER", "MOST_CURRE", 
      "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", 
       "STATUS", "STATUS_NOT", "VACANT_LOT"
  FROM "Landmark"
  WHERE 1 = 1 
  LIMIT 10;

  
  
SELECT "Id", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER", "MOST_CURRE", "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE  "LP_NUMBER" = 'LP-00836';

SELECT "Id", "BBL", "LP_NUMBER","LM_NAME", "LM_TYPE", "BLOCK", "BOUNDARIES", "BoroughID",  "BIN_NUMBER", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO" "LOT", "LP_NUMBER", "MOST_CURRE", "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE  1 = 1 
--AND "LP_NUMBER" = 'LP-00664';
AND "LP_NUMBER" IN (
'LP-00892'
)
ORDER BY "LP_NUMBER","BBL"


--  Pluto

  SELECT max(length("Landmark")) FROM public."PLUTO"
LIMIT 10;

SELECT DISTINCT("DESIG_DATE")
  FROM "Landmark";

SELECT DISTINCT("CALEN_DATE")
  FROM "Landmark";
  
    
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
--WHERE "BBL" = 1005320020
LIMIT 100;

  







SELECT id, "Borough", "Block", "Lot", "CD", "CT2010", "CB2010", "SchoolDist", "Council", "ZipCode", "FireComp", "PolicePrct", "HealthArea", "SanitBoro", "SanitDistrict", "SanitSub", "Address", "ZoneDist1", "ZoneDist2", "ZoneDist3", "ZoneDist4", "Overlay1", "Overlay2", "SPDist1", "SPDist2", "SPDist3", "LtdHeight", "SplitZone", "BldgClass", "LandUse", "Easements", "OwnerType", "OwnerName", "LotArea", "BldgArea", "ComArea", "ResArea", "OfficeArea", "RetailArea", "GarageArea", "StrgeArea", "FactryArea", "OtherArea", "AreaSource", "NumBldgs", "NumFloors", "UnitsRes", "UnitsTotal", "LotFront", "LotDepth", "BldgFront", "BldgDepth", "Ext", "ProxCode", "IrrLotCode", "LotType", "BsmtCode", "AssessLand", "AssessTot", "ExemptLand", "ExemptTot", "YearBuilt", "YearAlter1", "YearAlter2", "HistDist", "Landmark", "BuiltFAR", "ResidFAR", "CommFAR", "FacilFAR", "BoroCode", "BBL", "CondoNo", "Tract2010", "XCoord", "YCoord", "ZoneMap", "ZMCode", "Sanborn", "TaxMap", "EDesigNum", "APPBBL", "APPDate", "PLUTOMapID", "Version", "Latitude", "Longitude"
FROM public."PLUTO"
WHERE 1 = 1
--AND "Address" = '70 PINE STREET' AND "Borough" = 'MN'
LIMIT 1000;


SELECT p.*
FROM public."Landmark" l
INNER JOIN public."PLUTO" p ON 
l."BLOCK" = p."Block" AND  l."LOT" = p."Lot"  AND  l."BoroughID" = p."Borough"
WHERE 1 = 1
AND l."LP_NUMBER" = 'LP-02039'







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

-- LPC Location

ALTER TABLE  public."LPCLocation" ALTER COLUMN  "LocationType" TYPE varchar(50) ;

-- Reset Sequence
SELECT MAX("Id") FROM public."Landmark";
SELECT nextval('public."Landmark_Id_seq"');
SELECT setval('public."Landmark_Id_seq"', (SELECT MAX("Id") FROM public."LPCLocation"));
SELECT setval('public."Landmark_Id_seq"', COALESCE((SELECT MAX("Id") FROM public."Landmark"), 1), false);


SELECT "Id", "LPNumber", "Name", "BBL", "BIN", "ObjectId", "ObjectType", "Street", "Address", "Neighborhood", "Borough", "ZipCode", "Block", "Lot", "Latitude", "Longitude", "LocationType"
FROM public."LPCLocation"
WHERE 1 = 1 
AND "LocationType" = 'Object Id'
ORDER BY "LPNumber";


UPDATE public."LPCLocation"
SET "Latitude"= 40.7788082, "Longitude"= -73.9226516
WHERE "LPNumber"='LP-02196';

SELECT lpc."Name", *
FROM public."LPCReport" lpc 
LEFT OUTER JOIN public."LPCLocation" loc ON lpc."LPNumber" = loc."LPNumber"  
--WHERE loc."LPNumber" = 'LP-00063'
ORDER BY lpc."LPNumber";


SELECT lpc."Name", loc."Name"
FROM public."LPCReport" lpc 
INNER JOIN public."LPCLocation" loc ON lpc."Id" = loc."Id"
ORDER BY lpc."Id";


SELECT lpc."Name", loc."Name"
FROM public."LPCReport" lpc 
LEFT OUTER JOIN public."LPCLocation" loc ON lpc."Id" = loc."Id"
ORDER BY lpc."Id";


SELECT lpc."Name", loc."Name"
FROM public."LPCReport" lpc 
RIGHT OUTER JOIN public."LPCLocation" loc ON lpc."Id" = loc."Id"
ORDER BY lpc."Id";


SELECT "Id", "LPNumber", "Name", "BBL", "ObjectType", "Street", "Address", "Neighborhood", "Borough", "ZipCode", "Block", "Lot", "Latitude", "Longitude", "BIN"
FROM public."LPCLocation"
ORDER BY "Id" DESC;


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











