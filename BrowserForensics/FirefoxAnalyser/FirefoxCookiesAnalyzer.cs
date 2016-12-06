using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FirefoxAnalyzer {
    public class FirefoxCookiesAnalyzer : BrowserAnalyzer.CookiesAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxCookiesAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        public List<string> getCookies() {
        //public List<CookiesDTO> getCookies() {
            List<string> output = new List<string>();
            //List<CookiesDTO> res = new List<CookiesDTO>();
            DataTable storedCookies;
            string s = "select baseDomain, name, value, host, path, datetime(expiry, 'unixepoch', 'localtime') as expiration, datetime(lastAccessed/1000000,'unixepoch','localtime') as last ,datetime(creationTime/1000000,'unixepoch','localtime') as creat, isSecure, isHttpOnly FROM moz_cookies";

            storedCookies = client.select(s);

            foreach (DataRow r in storedCookies.Rows) {
                output.Add( r["creat"] +" domain:" + r["baseDomain"] + " name:" + r["name"] + " value:" + r["value"] + " : ");
                //output.Add(new CookiesDTO("" + r["creat"], "Firefox", "" + r["baseDomain"], "" + r["last"], "" + r["expiration"], ""+ r["value"]));
            }
            
            return output;
        }
    }
}
