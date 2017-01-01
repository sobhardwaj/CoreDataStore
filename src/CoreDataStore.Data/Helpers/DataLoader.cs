using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var contents = File.ReadAllText(filePath).Split('\n').Skip(headerRows);
            var csv = from line in contents
                      select line.Split('|').ToArray();

            var landmarks = new List<Landmark>();

            int count = 0;
            foreach (var row in csv.TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
            {
                try
                {
                    count = count + 1;
                    var landmark = new Landmark
                    {
                        BBL        = long.Parse(row[0].Trim()),
                        BIN_NUMBER = long.Parse(row[1].Trim()),
                        BoroughID  = row[2].Trim(),
                        BLOCK      = int.Parse(row[3].Trim()),
                        LOT        = int.Parse(row[4].Trim()),
                        LP_NUMBER  = row[5].Trim(),
                        LM_NAME    = row[6].Trim(),
                        PLUTO_ADDR = row.Length >= 7 && row[7] != null ? row[7].Trim() : null,
                        DESIG_ADDR = row[8] != null && row[8].Length > 0 ? row[8].Trim() : null,
                        DESIG_DATE = row[9] != null && row[9].Length > 0 ?  (DateTime?)DateTime.Parse(row[9]) : null,
                        CALEN_DATE = row[10] != null && row[10].Length > 0 ? (DateTime?)DateTime.Parse(row[10]) : null,
                        PUBLIC_HEA = row.Length >= 11 && row[11] != null ? row[11].Trim() : null,
                        LM_TYPE    = row.Length >= 12 && row[12] != null ? row[12].Trim() : null,
                        HIST_DISTR = row.Length >= 13 && row[13] != null ? row[13].Trim() : null,
                        OTHER_HEAR = row[14] != null && row[14].Length > 0 ? row[14].Trim() : null,
                        BOUNDARIES = row.Length >= 15 && row[15] != null ? row[15].Trim() : null,
                        MOST_CURRE = row.Length >= 16 && row[16].Trim() == "1",
                        STATUS     = row.Length >= 17 && row[17] != null ? row[17].Trim() : null,
                        LAST_ACTIO = row.Length >= 18 && row[18] != null ? row[18].Trim() : null,
                        STATUS_NOT = row[19] != null && row[19].Length > 0 ? row[19].Trim() : null,
                        COUNT_BLDG = row.Length >= 20 && row[20].Trim() == "1",
                        NON_BLDG   = row[21] != null && row[21].Length > 0 ? row[21].Trim() : null,
                        VACANT_LOT = row.Length >= 22 && row[22].Trim() == "1",
                        SECND_BLDG = row.Length >= 23 && row[23].Trim() == "1",
                    };
                    ;
                    landmarks.Add(landmark);
                }
                catch (Exception ex)
                {
                    var itemRow = count;
                    throw ex;
                }

                

            }

            return landmarks;
        }

        public static string ReadFileString(string path)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(path);
            MemoryStream stream = new MemoryStream(byteArray);

            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
