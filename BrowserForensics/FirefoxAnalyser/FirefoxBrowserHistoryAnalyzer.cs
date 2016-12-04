using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyzer {
    public class FirefoxBrowserHistoryAnalyzer : BrowserAnalyzer.BrowserHistoryAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxBrowserHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public List<string> getHistory() {
            DataTable browsed;
            List<string> output = new List<string>();
            string s = "select datetime(last_visit_date/1000000,'unixepoch','localtime') as time, title, url, visit_count from moz_places ";
            s = "SELECT datetime(moz_historyvisits.visit_date/1000000, 'unixepoch', 'localtime')as time, moz_places.url FROM moz_places, moz_historyvisits WHERE moz_places.id = moz_historyvisits.place_id";
            browsed = client.select(s);

            foreach (DataRow r in browsed.Rows) 
                output.Add( r["time"] + " "+ r["url"] );
                     
            return output;
        }
   
       
    }



}
