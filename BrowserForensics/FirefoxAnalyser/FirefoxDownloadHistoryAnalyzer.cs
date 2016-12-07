using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;
using System.Data;
using DTO;
using System.Data.SQLite;

namespace FirefoxAnalyzer {
    public class FirefoxDownloadHistoryAnalyzer : BrowserAnalyzer.DownloadHistoryAnalyzer {
        private SQLite.Client client;
        string location;
        public List<DownloadsDTO> result = null;

        public FirefoxDownloadHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public List<DownloadsDTO>  getDownloads() {
            if (result == null) {
                List<DownloadsDTO> output = new List<DownloadsDTO>();
                DataTable completedDownloads;
                string s = "SELECT datetime(moz_annos.dateAdded / 1000000, 'unixepoch', 'localtime') as dateAdded, moz_annos.content  FROM moz_annos";
                try {
                    completedDownloads = client.select(s);

                    foreach (DataRow r in completedDownloads.Rows) {
                        if (r["content"].ToString().Contains("Downloads") || r["content"].ToString().Contains("C:"))
                            output.Add(new DownloadsDTO("" + r["dateAdded"], "Firefox", "", "", "" + r["content"]));
                    }
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                result = output;
            }
            return result;
        }
    }
}
