using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SQLite;

namespace ChromeAnalyzer {
    public class ChromeSearchHistoryAnalyzer : BrowserAnalyzer.SearchHistoryAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private string location;
        private const string QUERY =
            "SELECT term " +
            "FROM keyword_search_terms";
        List<SearchDTO> result= null;

        public ChromeSearchHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        //public List<string> getSearches() {
          public override List<SearchDTO> getSearches() {
            List<SearchDTO> res = new List<SearchDTO>();
            if (result == null) {
                try {
                    queryResult = client.select(QUERY);

                    foreach (DataRow r in queryResult.Rows)
                        res.Add(new SearchDTO("", "Chrome", "" + r["term"]));
                                       
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                result = res;
            }
            return result;
        }
    }
}
