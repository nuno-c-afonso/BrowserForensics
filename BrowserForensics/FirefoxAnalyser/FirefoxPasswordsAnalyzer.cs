using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DTO;

namespace FirefoxAnalyzer {
    public class FirefoxPasswordsAnalyzer : BrowserAnalyzer.PasswordsAnalyzer {
        private SQLite.Client client;
        string location;

        public FirefoxPasswordsAnalyzer(string location) {
            //client = new SQLite.Client(location);
            this.location = location;
        }

        public List<PasswordDTO> getPasswords() { 
            List<PasswordDTO> output = new List<PasswordDTO>();

            /*  DataTable storedSignOns;
             *  
              string s = "select formSubMitURL,usernameField,passwordField ,encryptedUsername,encryptedPassword,encType,datetime(timeCreated/1000,'unixepoch','localtime'),datetime(timeLastUsed/1000,'unixepoch','localtime'),datetime(timePasswordChanged/1000,'unixepoch','localtime'),timesUsed FROM moz_logins";

              storedSignOns = client.select(s);

              s = "";
              foreach (DataRow r in storedSignOns.Rows) {

                  string pass;
                  string user;
                  byte[] passBytes = (byte[])r["encryptedPassword"];
                  byte[] userBytes = (byte[])r["encryptedUsername"];
                  try {
                      passBytes = ProtectedData.Unprotect(passBytes, null, DataProtectionScope.CurrentUser);
                      pass = System.Text.Encoding.Default.GetString(passBytes);
                      userBytes = ProtectedData.Unprotect(passBytes, null, DataProtectionScope.CurrentUser);
                      user = System.Text.Encoding.Default.GetString(userBytes);
                  } catch(CryptographicException e) {
                      Console.WriteLine("Data could not be decrypted. An error occurred.");
                      Console.WriteLine(e.ToString());
                      continue; // Try the next row.
                  }

                  s += r["formSubMitURL"] + " -> " + user + " : " + pass + "\r\n";
              }*/
            //output.Add(location);
            return output;
        }
    }
}
