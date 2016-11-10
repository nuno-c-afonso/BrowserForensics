using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ChromeAnalyzer {
    public class ChromeDownloadHistoryAnalyzer : BrowserAnalyzer.DownloadHistoryAnalyzer {
        private SQLite.Client client;

        public ChromeDownloadHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getDownloads() {
            DataTable completedDownloads;
            string s = "SELECT datetime(((downloads.start_time/1000000)-11644473600), \"unixepoch\") AS start, " +
                       "datetime(((downloads.end_time/1000000)-11644473600), \"unixepoch\") AS end, " +
                       "target_path AS path, tab_url AS url " +
                       "FROM downloads " + 
                       "WHERE received_bytes = total_bytes AND total_bytes > 0 " +
                       "ORDER BY start ASC";

            completedDownloads = client.select(s);
            
            s = "";
            foreach(DataRow r in completedDownloads.Rows) {
                s += r["start"] + " until " + r["end"] + " : " + r["path"] + " <- " + r["url"] + "\r\n";
            }

            return s;
        }
    }
}
