
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
WHERE  "LP_NUMBER" = 'LP-02146';

SELECT "Id", "BBL", "BIN_NUMBER", "BLOCK", "BOUNDARIES", "BoroughID", "CALEN_DATE", "COUNT_BLDG", "DESIG_ADDR", "DESIG_DATE", "HIST_DISTR", "LAST_ACTIO", "LM_NAME", "LM_TYPE", "LOT", "LP_NUMBER", "MOST_CURRE", "NON_BLDG", "OTHER_HEAR", "PLUTO_ADDR", "PUBLIC_HEA", "SECND_BLDG", "STATUS", "STATUS_NOT", "VACANT_LOT"
FROM public."Landmark"
WHERE  "LP_NUMBER" = 'LP-02146';




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
WHERE "BBL" = 3022960014
LIMIT 10;





SELECT id, "Address", "Borough",
"XCoord", "YCoord", "BBL",
"Block","Lot", "Latitude","Longitude"
FROM public."PLUTO"
WHERE "Address" = '70 PINE STREET' AND "Borough" = 'MN'
LIMIT 1000;




159 JOHN STREET
130 BOWERY
32 PRINCE STREET












-- LPC Location
SELECT "Id", "LPNumber", "Name", "BBL", "ObjectType", "Street", "Address", "Neighborhood", "Borough", "ZipCode", "Block", "Lot", "Latitude", "Longitude"
FROM public."LPCLocation"
WHERE "Latitude" isnull;

UPDATE public."LPCLocation"
SET "Address"='', "BBL"=0, "Block"=0, "Borough"='', "LPNumber"='', "Latitude"=0, "Longitude"=0, "Lot"=0, "Name"='', "Neighborhood"='', "ObjectType"='', "Street"='', "ZipCode"=''
WHERE "Id"=nextval('"LPCLocation_Id_seq"'::regclass);





select "Address","LPNumber",* from "LPCLocation"
WHERE "Latitude" ISNULL
ORDER BY  "LPNumber"
LIMIT 500;
 
 

-- LPC Lamppost
ALTER TABLE public."LPCLamppost" ADD "Neighborhood" varchar(200);


SELECT "Id", "PostId", "Type", "SubType", "Block", "Lot", "Borough" , "Located", "Latitude", "Longitude"
FROM public."LPCLamppost"
WHERE "Borough" = 'Manhattan';

--UPDATE public."LPCLamppost"
--SET "Borough" ='BK'
--WHERE "Borough" = 'Brooklyn';


















