using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ChromeAnalyzer {
    public class ChromeDownloadHistoryAnalyzer : BrowserAnalyzer.DownloadHistoryAnalyzer {
        private SQLiteConnection dbConnection;

        public ChromeDownloadHistoryAnalyzer(string location) {
            dbConnection = new SQLiteConnection("Data Source=" + location);
            dbConnection.Open();
        }
    }
}
