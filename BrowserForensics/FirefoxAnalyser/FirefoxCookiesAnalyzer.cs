using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyzer {
    public class FirefoxCookiesAnalyzer : BrowserAnalyzer.CookiesAnalyzer {
        private SQLite.Client client;

        public FirefoxCookiesAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getCookies() {
            DataTable storedCookies;
            string s = "SELECT host_key AS host, encrypted_value as value " +
                       "FROM cookies;";

            storedCookies = client.select(s);

            s = "";
            foreach (DataRow r in storedCookies.Rows) {
                string value;
                byte[] valueBytes = (byte[])r["value"];

                try {
                    valueBytes = ProtectedData.Unprotect(valueBytes, null, DataProtectionScope.CurrentUser);
                    value = System.Text.Encoding.Default.GetString(valueBytes);
                }
                catch (CryptographicException e) {
                    Console.WriteLine("Data could not be decrypted. An error occurred.");
                    Console.WriteLine(e.ToString());
                    continue; // Try the next row.
                }

                s += r["host"] + " : " + value + "\r\n";
            }

            return s;
        }
    }
}
