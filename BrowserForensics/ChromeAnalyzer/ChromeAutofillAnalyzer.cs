using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string getAutofills() {
            if (queryResult == null)
                queryResult = client.select(QUERY);

            string s = "";
            foreach (DataRow r in queryResult.Rows)
                s += r["value"] + "\r\n";

            return s;
        }
    }
}
