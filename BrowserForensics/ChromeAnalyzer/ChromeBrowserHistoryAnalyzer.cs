using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer {
    public class ChromeBrowserHistoryAnalyzer : BrowserAnalyzer.BrowserHistoryAnalyzer {
        private SQLite.Client client;

        public ChromeBrowserHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getHistory() {
            DataTable browsed;
            string s = "SELECT datetime(((visits.visit_time/1000000)-11644473600), \"unixepoch\") AS date, urls.url " +
                       "FROM urls, visits " +
                       "WHERE visits.url = urls.id " +
                       "ORDER BY date ASC";

            browsed = client.select(s);

            s = "";
            foreach (DataRow r in browsed.Rows) {
                s += r["date"] + " : " + r["url"] + "\r\n";
            }

            return s;
        }
    }
}
