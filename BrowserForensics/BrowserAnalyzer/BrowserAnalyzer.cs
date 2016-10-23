using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserAnalyzer
{
    public abstract class BrowserAnalyzer {
        private PasswordsAnalyzer pass;
        private CookiesAnalyzer cookies;
        private DownloadHistoryAnalyzer downloads;
        private SearchHistoryAnalyzer searches;
        private BrowserHistoryAnalyzer history;
        private AutofillAnalyzer autofill;

        public BrowserAnalyzer(PasswordsAnalyzer pass, CookiesAnalyzer cookies,
            DownloadHistoryAnalyzer downloads, SearchHistoryAnalyzer searches, 
            BrowserHistoryAnalyzer history, AutofillAnalyzer autofill) {
            this.pass = pass;
            this.cookies = cookies;
            this.downloads = downloads;
            this.searches = searches;
            this.history = history;
            this.autofill = autofill;
        }

        public string getPasswords() {
            string res = pass.getPasswords();
            return !res.Equals("") ? res : "There are no stored passwords.";
        }

        public string getCookies() {
            string res = cookies.getCookies();
            return !res.Equals("") ? res : "There are no stored cookies.";
        }

        public string getDownloads() {
            return downloads.getDownloads();
        }

        public string getSearches() {
            //TODO
            throw new NotImplementedException();
        }

        public string getHistory() {
            //TODO
            throw new NotImplementedException();
        }

        public string getAutofills() {
            //TODO
            throw new NotImplementedException();
        }
    }
}
