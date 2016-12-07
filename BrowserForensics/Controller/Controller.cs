using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Controller {
    public class Controller {
        private List<BrowserAnalyzer.BrowserAnalyzer> analyzers =
            new List<BrowserAnalyzer.BrowserAnalyzer>();

        public Controller() {
            // Add the wanted browsers analyzers
            // TODO: Ask for the directory. If none, choose the default one.
            //analyzers.Add(new ChromeAnalyzer.ChromeAnalyzer());
            analyzers.Add(new FirefoxAnalyser.FirefoxAnalyzer());
        }

        public string getDownloads() {
            string res = "--------DOWNLOADS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach (DownloadsDTO dto in ba.getDownloads())
                    res += dto.getFullString();
            return res;
        }

        public string getPasswords() {
            string res = "--------PASSWORDS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(PasswordDTO dto in ba.getPasswords())
                    res += dto.getFullString();
            return res;
        }

        public string getCookies() {
            string res = "--------COOKIES--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(CookiesDTO dto in ba.getCookies())
                    res += dto.getFullString();
            return res;
        }

        public string getSearches() {
            string res = "--------SEARCHES--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(SearchDTO dto in ba.getSearches())
                    res += dto.getFullString();
            return res;
        }

        public string getHistory() {
            string res = "--------BROWSING--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(HistoryDTO dto in ba.getHistory())
                    res += dto.getFullString();
            return res;
        }

        public string getAutofills() {
            string res = "--------AUTOFILLS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(AutofillDTO dto in ba.getAutofills())
                    res += dto.getFullString(); 
            return res;
        }

        public string getAllInfo() {
            string res = getDownloads();
            res += "\r\n" + getPasswords();
            res += "\r\n" + getCookies();
            res += "\r\n" + getSearches();
            res += "\r\n" + getHistory();
            res += "\r\n" + getAutofills();

            return res;
        }

        public string getTimeline() {
            List<string> l = new List<string>();

            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers) {
                foreach (AutofillDTO dto in ba.getAutofills())
                    l.Add(dto.getFullString());
                foreach (HistoryDTO dto in ba.getHistory())
                    l.Add(dto.getFullString());
                foreach (CookiesDTO dto in ba.getCookies())
                    l.Add(dto.getFullString());
                foreach (DownloadsDTO dto in ba.getDownloads())
                    l.Add(dto.getFullString());
                foreach (PasswordDTO dto in ba.getPasswords())
                    l.Add(dto.getFullString());
                foreach (SearchDTO dto in ba.getSearches())
                    l.Add(dto.getFullString());
            }
            l.Sort();
            string result = "";
            foreach (string s in l)
                result += s ;
            return result;
        }
    }
}
