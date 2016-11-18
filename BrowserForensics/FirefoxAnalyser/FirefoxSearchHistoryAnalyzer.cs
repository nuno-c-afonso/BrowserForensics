using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyzer {
    public class FirefoxSearchHistoryAnalyzer : BrowserAnalyzer.SearchHistoryAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxSearchHistoryAnalyzer(string location) {
            //client = new SQLite.Client(location);
            this.location = location;
        }

        public string getSearches() {
            /*DataTable searched;
            string s = "SELECT term " +
                       "FROM keyword_search_terms;";

            searched = client.select(s);

            s = "";
            foreach (DataRow r in searched.Rows) {
                s += r["term"] + "\r\n";
            }*/

            return location;
        }
    }
}
