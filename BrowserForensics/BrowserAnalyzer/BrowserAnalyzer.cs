using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

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

        public List<PasswordDTO> getPasswords() {
            List<PasswordDTO> res = pass.getPasswords();
            //if (res.Count == 0)
            //    res.Add("There are no stored passwords.");
            return res;
        }

        public List<CookiesDTO> getCookies() {
            List<CookiesDTO> res = cookies.getCookies();
            //if (res.Count == 0)
            //    res.Add("There are no stored cookies.");
            return res;
        }

        public List<DownloadsDTO> getDownloads() {
            List<DownloadsDTO> res = downloads.getDownloads();
            //if (res.Count == 0)
                //res.Add("There are no stored downloads.");
            return res;
        }

        public List<SearchDTO> getSearches() {
            List<SearchDTO> res = searches.getSearches();
            //if (res.Count == 0)
            //    res.Add("There are no stored searches.");
            return res;
        }

        public List<HistoryDTO> getHistory() {
            List<HistoryDTO> res = history.getHistory();
            //if (res.Count == 0)
                //res.Add("There is no stored browsing history.");
            return res;
        }

        public List<AutofillDTO> getAutofills() {
            List<AutofillDTO> res = autofill.getAutofills();
            //if (res.Count == 0)
            //    res.Add("There is no stored autofill history.");
            return res;
        }
    }
}
