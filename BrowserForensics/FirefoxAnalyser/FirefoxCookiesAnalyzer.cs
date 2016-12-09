using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SQLite;

namespace FirefoxAnalyzer {
    public class FirefoxCookiesAnalyzer : BrowserAnalyzer.CookiesAnalyzer {
        private SQLite.Client client;
        string location;
        private List<CookiesDTO> result = null;

        public FirefoxCookiesAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public List<CookiesDTO> getCookies() {
            if (result == null) {
                List<CookiesDTO> output = new List<CookiesDTO>();
                DataTable storedCookies;
                string s = "select baseDomain, name, value, host, path, datetime(expiry, 'unixepoch', 'localtime') as expiration, datetime(lastAccessed/1000000,'unixepoch','localtime') as last ,datetime(creationTime/1000000,'unixepoch','localtime') as creat, isSecure, isHttpOnly FROM moz_cookies";
                try {
                    storedCookies = client.select(s);

                    foreach (DataRow r in storedCookies.Rows) {
                        output.Add(new CookiesDTO("" + r["creat"], "Firefox", "" + r["baseDomain"], "" + r["last"], "" + r["expiration"], "" + r["value"]));
                    }
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                //output = output.OrderBy(o => o.getDomain()).ThenBy(o => o.getTime()).ToList();
                output = output.OrderByDescending(o => o.getTime()).ToList();
                result = output;
            }
            return result;
        }
    }
}
