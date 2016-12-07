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

        public FirefoxSearchHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public List<SearchDTO> getSearches() {
            DataTable browsed;
            List<string> output = new List<string>();
            List<SearchDTO> outputDTOs = new List<SearchDTO>();
            string s =  "SELECT datetime(moz_historyvisits.visit_date/1000000, 'unixepoch', 'localtime')as time, moz_places.url FROM moz_places, moz_historyvisits WHERE moz_places.id = moz_historyvisits.place_id";
            browsed = client.select(s);

            foreach (DataRow r in browsed.Rows) {
                string[] search = getSearchInURL((string)r["url"]);
                if (search != null) {
                    string line = r["time"] + " SEARCH in " + search[0]+ search[1];
                    if (!output.Contains(line)) {
                        output.Add(line);
                        outputDTOs.Add(new SearchDTO("" + r["time"], "Firefox", search[1], search[0]));
                    }
                }
            }

            return outputDTOs;
        }

        public string[] getSearchInURL(string url) {
            string query = "";
            string[] output = null;
            int first = url.IndexOf("search?q=");
            if (first != -1) {
                first += "search?q=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first != -1) {
                    output = new string[]{ "Google:", query.Substring(0, first).Replace('+', ' ') };
                }
            }
            query = "";
            first = url.LastIndexOf("?search_query=");
            if (first != -1) {
                first += "?search_query=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first == -1) {
                    output = new string[] { "Youtube:", query.Replace('+', ' ') };
                }
            }
            query = "";
            first = url.LastIndexOf("www.facebook.com/search/top/?q=");
            if (first != -1) {
                first += "www.facebook.com/search/top/?q=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first == -1) {
                    output = new string[] { "Facebook:", query.Replace('+', ' ') };
                }
            }
            query = "";
            first = url.LastIndexOf("?url=search-alias%3Daps&field-keywords=");
            if (first != -1) {
                first += "?url=search-alias%3Daps&field-keywords=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first == -1) {
                    output = new string[] { "Amazon:", query.Replace('+', ' ') };
                }
            }
            query = "";
            first = url.IndexOf("_nkw=");
            if (first != -1) {
                first += "_nkw=".Length;
                query = url.Substring(first);
                first = query.IndexOf("&");
                if (first != -1) {
                    output = new string[] { "Ebay:", query.Substring(0, first).Replace('+', ' ') };
                }
            }

            return output;

        }
    }
}
