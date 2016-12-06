using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

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

        public List<string> getHistory() {
        //public List<HistoryDTO> getHistory() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            List<string> res = new List<string>();
            //List<HistoryDTO> output = new List<HistoryDTO>();
            foreach (DataRow r in queryResult.Rows)
                res.Add(r["date"] + " ACCESSED URL " + r["url"]);
                //res.Add(new HistoryDTO("" + r["date"], "Firefox", "" + r["url"]));

            return res;
        }
    }
}
