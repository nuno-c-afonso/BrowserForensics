using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FirefoxAnalyzer {
    public class FirefoxSearchHistoryAnalyzer : BrowserAnalyzer.SearchHistoryAnalyzer {
        private SQLite.Client client;
        string location;
        private List<SearchDTO> result=null;

        public FirefoxSearchHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public override List<SearchDTO> getSearches() {
            if (result == null) {
                DataTable browsed;
                List<string> output = new List<string>();
                List<SearchDTO> outputDTOs = new List<SearchDTO>();
                string s = "SELECT datetime(moz_historyvisits.visit_date/1000000, 'unixepoch', 'localtime')as time, moz_places.url FROM moz_places, moz_historyvisits WHERE moz_places.id = moz_historyvisits.place_id";
                try {
                    browsed = client.select(s);

                    foreach (DataRow r in browsed.Rows) {
                        string[] search = getSearchInURL((string)r["url"]);
                        if (search != null) {
                            string line = r["time"] + " SEARCH in " + search[0] + search[1];
                            if (!output.Contains(line)) {
                                output.Add(line);
                                outputDTOs.Add(new SearchDTO("" + r["time"], "Firefox", search[1], search[0]));
                            }
                        }
                    }
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                result = outputDTOs;
            }

            return result;
        }
    }
}
