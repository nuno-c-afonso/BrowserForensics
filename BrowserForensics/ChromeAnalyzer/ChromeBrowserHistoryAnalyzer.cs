using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer {
    public class ChromeBrowserHistoryAnalyzer : BrowserAnalyzer.BrowserHistoryAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT datetime(((visits.visit_time/1000000)-11644473600), \"unixepoch\") AS date, urls.url " +
            "FROM urls, visits " +
            "WHERE visits.url = urls.id " +
            "ORDER BY date ASC";

        public ChromeBrowserHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getHistory() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            string s = "";
            foreach (DataRow r in queryResult.Rows)
                s += r["date"] + " : " + r["url"] + "\r\n";
            
            return s;
        }
    }
}
