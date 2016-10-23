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
            string s = "SELECT url, visit_count " +
                       "FROM urls;";

            browsed = client.select(s);

            s = "";
            foreach (DataRow r in browsed.Rows) {
                s += r["url"] + " : visited " + r["visit_count"] + " times\r\n";
            }

            return s;
        }
    }
}
