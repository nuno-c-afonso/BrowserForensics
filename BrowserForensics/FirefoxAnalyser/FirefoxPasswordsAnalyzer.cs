using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FirefoxAnalyzer {
    public class FirefoxPasswordsAnalyzer : BrowserAnalyzer.PasswordsAnalyzer {
        private SQLite.Client client;

        public FirefoxPasswordsAnalyzer(string location) {
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

                string pass;
                byte[] passBytes = (byte[]) r["pass"];

                try {
                    passBytes = ProtectedData.Unprotect(passBytes, null, DataProtectionScope.CurrentUser);
                    pass = System.Text.Encoding.Default.GetString(passBytes);
                } catch(CryptographicException e) {
                    Console.WriteLine("Data could not be decrypted. An error occurred.");
                    Console.WriteLine(e.ToString());
                    continue; // Try the next row.
                }

                s += r["url"] + " -> " + r["username"] + " : " + pass + "\r\n";
            }

            return s;
        }
    }
}
