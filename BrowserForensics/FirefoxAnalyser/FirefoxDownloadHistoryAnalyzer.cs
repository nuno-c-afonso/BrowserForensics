using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;
using System.Data;

namespace FirefoxAnalyzer {
    public class FirefoxDownloadHistoryAnalyzer : BrowserAnalyzer.DownloadHistoryAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxDownloadHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public string getDownloads() {
            DataTable completedDownloads;
             string s = "SELECT datetime(moz_annos.dateAdded / 1000000, 'unixepoch', 'localtime') as dateAdded, moz_annos.content  FROM moz_annos";
            
             completedDownloads = client.select(s);

             s = "";
             foreach(DataRow r in completedDownloads.Rows) {
                 if( r["content"].ToString().Contains("Downloads") || r["content"].ToString().Contains("C:"))
                 s +=r["dateAdded"] +" "+ r["content"] + "\r\n";
             }

             return s;
            //return location;
        }
    }
}
