using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SQLite;

namespace ChromeAnalyzer {
    public class ChromeBrowserHistoryAnalyzer : BrowserAnalyzer.BrowserHistoryAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private string location;
        private const string QUERY =
            "SELECT datetime(((visits.visit_time/1000000)-11644473600), \"unixepoch\") AS date, urls.url " +
            "FROM urls, visits " +
            "WHERE visits.url = urls.id " +
            "ORDER BY date ASC";
        private List<HistoryDTO> result = null;

        public ChromeBrowserHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        //public List<string> getHistory() {
        public List<HistoryDTO> getHistory() {          
            if (result == null) {
                List<HistoryDTO> output = new List<HistoryDTO>();
                try {
                    queryResult = client.select(QUERY);
                    var rows = queryResult.Rows;
                    Console.WriteLine("Have " + rows.Count + " to process");

                    int partes = (int)(rows.Count * 0.10f);
                    int percentagem = 0;
                    int i = 0;
                    foreach (DataRow r in rows)
                    {
                        i++;
                        if(i % partes == 0)
                        {
                            percentagem += 10;
                            Console.WriteLine("Ja vou a " + percentagem + "%");
                        }
                           

                        output.Add(new HistoryDTO("" + r["date"], "Chrome", "" + r["url"]));
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
