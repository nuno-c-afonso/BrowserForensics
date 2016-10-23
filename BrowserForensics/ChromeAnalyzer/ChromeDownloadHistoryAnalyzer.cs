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
            string s = "SELECT target_path AS path, tab_url AS url " +
                       "FROM downloads " + 
                       "WHERE received_bytes = total_bytes AND total_bytes > 0;";

            completedDownloads = client.select(s);
            
            s = "";
            foreach(DataRow r in completedDownloads.Rows) {
                s += r["path"] + " <- " + r["url"] + "\r\n";
            }

            return s;
        }
    }
}
