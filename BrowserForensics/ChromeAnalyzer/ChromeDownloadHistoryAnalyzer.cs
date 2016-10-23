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
            Console.WriteLine("\n\n" + location + "\n\n");
            Console.ReadLine();

            dbConnection = new SQLiteConnection("Data Source=" + location);
        }

        public string getDownloads() {
            DataTable completedDownloads = new DataTable();
            string s = "SELECT target_path AS path, tab_url AS url FROM downloads WHERE received_bytes = total_bytes AND total_bytes > 0;";

            dbConnection.Open();
            SQLiteCommand query = new SQLiteCommand(dbConnection);
            query.CommandText = s;
            SQLiteDataReader reader = query.ExecuteReader();
            completedDownloads.Load(reader);
            reader.Close();
            dbConnection.Close();

            s = "";
            foreach(DataRow r in completedDownloads.Rows) {
                s += r["path"] + " <- " + r["url"] + "\r\n";
            }

            return s;
        }
    }
}
