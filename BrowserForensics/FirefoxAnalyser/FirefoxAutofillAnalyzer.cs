using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyzer {
    public class FirefoxAutofillAnalyzer : BrowserAnalyzer.AutofillAnalyzer {
        private SQLite.Client client;

        public FirefoxAutofillAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getAutofills() {
            DataTable inputed;
            string s = "SELECT value " +
                       "FROM autofill;";

            inputed = client.select(s);

            s = "";
            foreach (DataRow r in inputed.Rows) {
                s += r["value"] + "\r\n";
            }

            return s;
        }
    }
}
