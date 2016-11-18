using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyzer {
    public class FirefoxAutofillAnalyzer : BrowserAnalyzer.AutofillAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxAutofillAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public string getAutofills() {
           DataTable inputed;
            string s = "select fieldname, value, timesUsed, datetime(firstUsed / 1000000, 'unixepoch', 'localtime') as first,datetime(lastUsed / 1000000, 'unixepoch', 'localtime') as last from moz_formhistory";

            inputed = client.select(s);

            s = "";
            s += location + "\r\n";
            foreach (DataRow r in inputed.Rows) {
                s +=r["first"]+ "  "+ "fieldname:" + r["fieldname"] + "  value:" + r["value"] + "  timesUsed:" + r["timesUsed"] + "  last:" + r["last"] + "\r\n";
            }

            return s;
        }
    }
}
