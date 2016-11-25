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

        public List<string> getPasswords() {
            List<string> res = pass.getPasswords();
            if (res.Count == 0)
                res.Add("There are no stored passwords.");
            return res;
        }

        public List<string> getCookies() {
            List<string> res = cookies.getCookies();
            if (res.Count == 0)
                res.Add("There are no stored cookies.");
            return res;
        }

        public List<string> getDownloads() {
            List<string> res = downloads.getDownloads();
            if (res.Count == 0)
                res.Add("There are no stored downloads.");
            return res;
        }

        public List<string> getSearches() {
            List<string> res = searches.getSearches();
            if (res.Count == 0)
                res.Add("There are no stored searches.");
            return res;
        }

        public List<string> getHistory() {
            List<string> res = history.getHistory();
            if (res.Count == 0)
                res.Add("There is no stored browsing history.");
            return res;
        }

        public List<string> getAutofills() {
            List<string> res = autofill.getAutofills();
            if (res.Count == 0)
                res.Add("There is no stored autofill history.");
            return res;
        }
    }
}
