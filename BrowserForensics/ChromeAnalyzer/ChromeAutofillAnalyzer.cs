using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SQLite;

namespace ChromeAnalyzer {
    public class ChromeAutofillAnalyzer : BrowserAnalyzer.AutofillAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT value " +
            "FROM autofill";
        private string location;
        private List<AutofillDTO> result= null;

        public ChromeAutofillAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        //public List<string> getAutofills() {
        public List<AutofillDTO> getAutofills() {
            if (result == null) {
                List<AutofillDTO> res = new List<AutofillDTO>();
                try {
                    queryResult = client.select(QUERY);

                    //List<string> res = new List<string>();          
                    foreach (DataRow r in queryResult.Rows)
                        //res.Add("AUTOFILL " + r["value"]);
                        res.Add(new AutofillDTO("", "Chrome", "" + r["value"]));
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                result = res;
            }
            return result;
        }
    }
}
