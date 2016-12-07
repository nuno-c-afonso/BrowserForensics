using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BLOBDecipher;
using DTO;
using System.Data.SQLite;

namespace ChromeAnalyzer {
    public class ChromePasswordsAnalyzer : BrowserAnalyzer.PasswordsAnalyzer {
        private SQLite.Client client;
        private DataTable queryResult = null;
        private const string QUERY =
            "SELECT signon_realm AS url, username_value AS username, password_value AS pass " +
            "FROM logins " +
            "WHERE username != ''";
        private string location;
        private List<PasswordDTO> result = null;

        public ChromePasswordsAnalyzer(string location) {
            client = new SQLite.Client(location);
            this.location = location;
        }

        //public List<string> getPasswords() {
        public List<PasswordDTO> getPasswords() {
            if (result == null) {
                List<PasswordDTO> res = new List<PasswordDTO>();
                try {
                    if (queryResult == null) {
                        queryResult = client.select(QUERY);
                        WindowsBLOBDecipher.decipherQueryResultField("pass", queryResult);
                    }

                    //List<string> res = new List<string>();

                    foreach (DataRow r in queryResult.Rows) {
                        string pass = System.Text.Encoding.Default.GetString((byte[])r["pass"]);
                        //TODO missing time
                        res.Add(new PasswordDTO("", "Chrome", "" + r["url"], "" + r["username"], pass));
                    }
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
