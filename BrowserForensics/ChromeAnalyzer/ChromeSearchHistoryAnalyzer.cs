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

        private const string HISTORY_QUERY =
            "SELECT datetime(((visits.visit_time/1000000)-11644473600), \"unixepoch\") AS date, urls.url " +
            "FROM urls, visits " +
            "WHERE visits.url = urls.id " +
            "ORDER BY date ASC";
        List<SearchDTO> result= null;

        public ChromeSearchHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        //public List<string> getSearches() {
          public override List<SearchDTO> getSearches() {

            DataTable browsed = null;
            List<SearchDTO> res_searchs = new List<SearchDTO>();
            List<string> output = new List<string>();
            List<SearchDTO> res_history_searchs = new List<SearchDTO>();

            if (result == null) {
                try {
                    queryResult = client.select(QUERY);

                    foreach (DataRow r in queryResult.Rows)
                        res_searchs.Add(new SearchDTO("", "Chrome", "" + r["term"]));

                    result = res_searchs;


                    // find search words in history urls
                    browsed = client.select(HISTORY_QUERY);
                    foreach (DataRow r in browsed.Rows)
                    {
                        string[] search = getSearchInURL((string)r["url"]);
                        if (search != null)
                        {
                            string line = r["date"] + " SEARCH in " + search[0] + search[1];
                            if (!output.Contains(line))
                            {
                                output.Add(line);
                                res_history_searchs.Add(new SearchDTO("" + r["date"], "Chrome", search[1], search[0]));
                            }
                        }
                    }
                    result.AddRange(res_history_searchs);

                                       
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }

            }
            return result;
        }
    }
}
