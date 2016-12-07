using BLOBDecipher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SQLite;

namespace ChromeAnalyzer {
    public class ChromeCookiesAnalyzer : BrowserAnalyzer.CookiesAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private string location;
        private const string QUERY =
            "SELECT host_key AS host, datetime(((cookies.creation_utc/1000000)-11644473600), \"unixepoch\") AS creation, " +
                "datetime(((cookies.last_access_utc/1000000)-11644473600), \"unixepoch\") AS lastAccess, " +
                "datetime(((cookies.expires_utc/1000000)-11644473600), \"unixepoch\") AS expiration, " +
                "encrypted_value AS value " +
            "FROM cookies " +
            "WHERE cookies.expires_utc > 0 " +
            "ORDER BY creation ASC";
        private List<CookiesDTO> result = null;

        public ChromeCookiesAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        //private List<string> convertToList() {
        private List<CookiesDTO> convertToList() {
            //List<string> res = new List<string>();
            List<CookiesDTO> res = new List<CookiesDTO>();

            foreach (DataRow r in queryResult.Rows) {
                string value = System.Text.Encoding.Default.GetString((byte[])r["value"]);

                //res.Add(r["creation"] + " COOKIE CREATION\r\n\tFROM HOST: " + r["host"] + "\r\n\tWITH VALUE: " + value);
                //res.Add(r["lastAccess"] + " COOKIE LAST ACCESS\r\n\tFROM HOST: " + r["host"] + "\r\n\tWITH VALUE: " + value);
                //res.Add(r["expiration"] + " COOKIE EXPIRATION DATE\r\n\tFROM HOST: " + r["host"] + "\r\n\tWITH VALUE: " + value);
                res.Add(new CookiesDTO("" + r["creation"], "Chrome", ""+ r["host"], ""+ r["lastAccess"], ""+ r["expiration"], value));
            }

            return res;
        }

        //public List<string> getCookies() {
        public List<CookiesDTO> getCookies() {
            if (result == null) {
                List<CookiesDTO> res = new List<CookiesDTO>();
                try {
                    
                    queryResult = client.select(QUERY);
                    WindowsBLOBDecipher.decipherQueryResultField("value", queryResult);
                    res = convertToList();
                
                } catch (System.Data.SQLite.SQLiteException e) {
                    Console.WriteLine(location + " not Found");
                    client.dbConnection.Close();
                }
                result = res;
            }
            return result;
        }
    }
}
