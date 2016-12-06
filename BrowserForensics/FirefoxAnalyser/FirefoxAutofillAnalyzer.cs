using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FirefoxAnalyzer {
    public class FirefoxAutofillAnalyzer : BrowserAnalyzer.AutofillAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxAutofillAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public List<string> getAutofills() {
        //public List<AutofillDTO> getAutofills() {
            DataTable inputed;
            string s = "select fieldname, value, timesUsed, datetime(firstUsed / 1000000, 'unixepoch', 'localtime') as first,datetime(lastUsed / 1000000, 'unixepoch', 'localtime') as last from moz_formhistory";
            List<string> output = new List<string>();
            //List<AutofillDTO> res = new List<AutofillDTO>();
            inputed = client.select(s);

            foreach (DataRow r in inputed.Rows) {
                output.Add(r["first"]+ "  "+ "fieldname:" + r["fieldname"] + "  value:" + r["value"] + "  timesUsed:" + r["timesUsed"] + "  last:" + r["last"] + "\r\n");
                //output.Add(new AutofillDTO(""+r["first"], "Firefox",""+ r["value"],""+ r["fieldname"]));
            }

            return output;
        }
    }
}
