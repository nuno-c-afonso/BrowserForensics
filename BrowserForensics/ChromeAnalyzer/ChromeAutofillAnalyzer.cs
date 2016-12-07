using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace ChromeAnalyzer {
    public class ChromeAutofillAnalyzer : BrowserAnalyzer.AutofillAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT value " +
            "FROM autofill";

        public ChromeAutofillAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        //public List<string> getAutofills() {
        public List<AutofillDTO> getAutofills() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            //List<string> res = new List<string>();
            List<AutofillDTO> res = new List<AutofillDTO>();
            foreach (DataRow r in queryResult.Rows)
                //res.Add("AUTOFILL " + r["value"]);
                res.Add(new AutofillDTO("", "Chrome",""+ r["value"]));

            return res;
        }
    }
}
