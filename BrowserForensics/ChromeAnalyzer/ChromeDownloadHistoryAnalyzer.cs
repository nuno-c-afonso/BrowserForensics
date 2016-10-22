using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ChromeAnalyzer {
    public class ChromeDownloadHistoryAnalyzer : BrowserAnalyzer.DownloadHistoryAnalyzer {
        private SQLiteConnection dbConnection;

        public ChromeDownloadHistoryAnalyzer(string location) {
            dbConnection = new SQLiteConnection("Data Source=" + location + ";");
        }

        //TODO: Change the returned type!!!
        public void getDownloads() {
            DataTable completedDownloads = new DataTable();
            string s = "SELECT target_path AS path, tab_url AS url FROM downloads WHERE received_bytes = total_bytes AND total_bytes > 0;";

            dbConnection.Open();
            SQLiteCommand query = new SQLiteCommand(dbConnection);
            query.CommandText = s;
            SQLiteDataReader reader = query.ExecuteReader();
            completedDownloads.Load(reader);
            reader.Close();
            dbConnection.Close();

            foreach(DataRow r in completedDownloads.Rows) {
                Console.WriteLine(r["path"] + " <- " + r["url"]);
            }
        }
    }
}
