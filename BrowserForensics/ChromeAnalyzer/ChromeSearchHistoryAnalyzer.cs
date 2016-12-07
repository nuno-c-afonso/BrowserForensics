using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

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

        //public List<string> getSearches() {
          public List<SearchDTO> getSearches() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            //List<string> res = new List<string>();
            List<SearchDTO> res = new List<SearchDTO>();
            foreach (DataRow r in queryResult.Rows)
                //res.Add("SEARCHED " + r["term"]);
                res.Add(new SearchDTO("", "Chrome", ""+ r["term"]));

            return res;
        }
    }
}
