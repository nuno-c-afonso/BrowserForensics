using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using DTO;

namespace ChromeAnalyzer {
    public class ChromeDownloadHistoryAnalyzer : BrowserAnalyzer.DownloadHistoryAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT datetime(((downloads.start_time/1000000)-11644473600), \"unixepoch\") AS start, " +
                "datetime(((downloads.end_time/1000000)-11644473600), \"unixepoch\") AS end, " +
                "target_path AS path, tab_url AS url " +
            "FROM downloads " +
            "WHERE received_bytes = total_bytes AND total_bytes > 0 " +
            "ORDER BY start ASC";

        public ChromeDownloadHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        //private List<string> convertToList() {
        public List<DownloadsDTO> convertToList() {
            //List<string> res = new List<string>();
            List<DownloadsDTO> res = new List<DownloadsDTO>();
            foreach (DataRow r in queryResult.Rows) {
                //res.Add(r["start"] + " DOWNLOAD STARTED\r\n\tFROM URL: " + r["url"] + "\r\n\tTO PATH: " + r["path"]);
                //res.Add(r["end"] + " DOWNLOAD ENDED\r\n\tFROM URL: " + r["url"] + "\r\n\tTO PATH: " + r["path"]);
                res.Add(new DownloadsDTO(""+r["start"], "Chrome",""+ r["url"],""+ r["path"],""));
            }

            return res;
        }

        public List<DownloadsDTO> getDownloads() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            return convertToList();
        }
    }
}
