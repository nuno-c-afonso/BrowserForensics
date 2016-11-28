using BLOBDecipher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer {
    public class ChromeCookiesAnalyzer : BrowserAnalyzer.CookiesAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT host_key AS host, datetime(((cookies.creation_utc/1000000)-11644473600), \"unixepoch\") AS creation, " +
                "datetime(((cookies.last_access_utc/1000000)-11644473600), \"unixepoch\") AS lastAccess, " +
                 "datetime(((cookies.expires_utc/1000000)-11644473600), \"unixepoch\") AS expiration, " +
                 "encrypted_value AS value " +
            "FROM cookies " +
            "ORDER BY creation ASC";

        public ChromeCookiesAnalyzer(string location) {
            client = new SQLite.Client(location);
        }

        public string getCookies() {
            if (queryResult == null) {
                queryResult = client.select(QUERY);
                WindowsBLOBDecipher.decipherQueryResultField("value", queryResult);
            }

            string s = "";
            foreach (DataRow r in queryResult.Rows) {
                string value = System.Text.Encoding.Default.GetString((byte[])r["value"]);
                string expiration = (string)r["expiration"];
                expiration = expiration.StartsWith("16") ? "the expiration date is set to zero" : expiration;

                s += r["host"] + " : " + value +
                "\r\n\tCreation date: " + r["creation"] +
                "\r\n\tLast accessed: " + r["lastAccess"] +
                "\r\n\tExpiration date: " + expiration + "\r\n";
            }
            return s;
        }
    }
}
