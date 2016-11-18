using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer {
    public class ChromeSearchHistoryAnalyzer : BrowserAnalyzer.SearchHistoryAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT term " +
            "FROM keyword_search_terms";

        public ChromeSearchHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getSearches() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            string s = "";
            foreach (DataRow r in queryResult.Rows)
                s += r["term"] + "\r\n";

            return s;
        }
    }
}
