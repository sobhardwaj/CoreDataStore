using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.Helpers
{
    public static class DataLoader
    {
        public static List<LPCReport> LoadLPCReports(string filePath)
        {
            int headerRows = 1;

            var contents = File.ReadAllText(filePath).Split('\n').Skip(headerRows);
            var csv = from line in contents
                      select line.Split('|').ToArray();

            var lpcReports = new List<LPCReport>();
            foreach (var row in csv.TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
            {
                var lpcReport = new LPCReport
                {
                    Architect = row[0].Trim(),
                    Borough = row[1].Trim(),
                    DateDesignated = DateTime.Parse(row[2].Trim()),
                    LPCId = row[3].Trim(),
                    LPNumber = row[4].Trim(),
                    Name = row[5].Trim(),
                    ObjectType = row[6].Trim(),
                    PhotoStatus = bool.Parse(row[7].Trim()),
                    PhotoURL = row[8].Trim(),
                    Street = row[9].Trim(),
                    Style = row[10].Trim(),
                };

                lpcReports.Add(lpcReport);
            }

            return lpcReports;
        }

        public static List<Landmark> LoadLandmarks(string filePath)
        {
            int headerRows = 1;

            var contents = File.ReadAllText(filePath).Split('\n').Skip(headerRows).Take(5000);
            var csv = from line in contents
                      select line.Split('|').ToArray();

            var landmarks = new List<Landmark>();
            foreach (var row in csv.TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
            {
                var landmark = new Landmark
                {
                    BBL = long.Parse(row[0].Trim()),
                    BIN_NUMBER = long.Parse(row[1].Trim()),
                    BoroughID = row[2].Trim(),
                    BLOCK = int.Parse(row[3].Trim()),
                    LOT = int.Parse(row[4].Trim()),
                    LP_NUMBER = row[5].Trim(),
                    LM_NAME = row[6].Trim(),
                    PLUTO_ADDR = row[7].Trim(),
                    DESIG_ADDR = row[8],
                    DESIG_DATE = row[9].Trim().Length > 0 ? row[9].Trim() : null,
                    CALEN_DATE = row[10].Trim().Length > 0 ? row[10].Trim() : null,
                    PUBLIC_HEA = row[11].Trim(),
                    LM_TYPE = row[12],
                    HIST_DISTR = row[13].Trim(),
                    OTHER_HEAR = row[14].Trim().Length > 0 ? row[14].Trim() : null,
                    BOUNDARIES = row[15].Trim().Length > 0 ? row[15].Trim() : null,
                    MOST_CURRE = row[16].Trim().Length > 0 && row[16].Trim() == "1",
                    STATUS = row[16].Trim().Length > 0 ? row[16].Trim() : null,
                    LAST_ACTIO = row[17].Trim().Length > 0 ? row[17].Trim() : null,
                    STATUS_NOT = row[18].Trim().Length > 0 ? row[18].Trim() : null,
                    COUNT_BLDG = row[19].Trim().Length > 0 && row[19].Trim() == "1",
                    NON_BLDG = row[20].Trim().Length > 0 ? row[20].Trim() : null,
                    VACANT_LOT = row[21].Trim().Length > 0 && row[21].Trim() == "1",
                    SECND_BLDG = row[22].Trim().Length > 0 && row[22].Trim() == "1",
                };
;
                landmarks.Add(landmark);

            }

            return landmarks;
        }

    }
}
