using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SQLite;




namespace FirefoxAnalyzer {
    public class FirefoxBrowserHistoryAnalyzer : BrowserAnalyzer.BrowserHistoryAnalyzer {
        private SQLite.Client client;
        private string location;
        private List<HistoryDTO> result = null;

        public FirefoxBrowserHistoryAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;

        }

        public List<HistoryDTO> getHistory() {
            if (result == null) {
                DataTable browsed;
                List<HistoryDTO> output = new List<HistoryDTO>();
                string s = "select datetime(last_visit_date/1000000,'unixepoch','localtime') as time, title, url, visit_count from moz_places ";
                s = "SELECT datetime(moz_historyvisits.visit_date/1000000, 'unixepoch', 'localtime')as time, moz_places.url FROM moz_places, moz_historyvisits WHERE moz_places.id = moz_historyvisits.place_id";
                try {
                    browsed = client.select(s);
                    var rows = browsed.Rows;

                    Console.WriteLine("Have " + rows.Count + " to process");

                    int partes = (int)(rows.Count * 0.10f);
                    int percentagem = 0;
                    int i = 0;

                    foreach (DataRow r in browsed.Rows)
                    {
                        i++;
                        if (partes > 0 && (i % partes == 0))
                        {
                            percentagem += 10;
                            Console.WriteLine("Ja vou a " + percentagem + "%");
                        }

                        output.Add(new HistoryDTO("" + r["time"], "Firefox", "" + r["url"]));
                    }
                        
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                output = output.OrderBy(o => o.getTime()).ToList();
                result = output;
            }
            return result;
            }
   
       
    }



}
