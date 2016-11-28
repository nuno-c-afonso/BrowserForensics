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
                foreach(string s in ba.getDownloads())
                    res += s + "\r\n";
            return res;
        }

        public string getPasswords() {
            string res = "--------PASSWORDS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(string s in ba.getPasswords())
                res += s + "\r\n";
            return res;
        }

        public string getCookies() {
            string res = "--------COOKIES--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(string s in ba.getCookies())
                res += s + "\r\n";
            return res;
        }

        public string getSearches() {
            string res = "--------SEARCHES--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(string s in ba.getSearches())
                res += s + "\r\n";
            return res;
        }

        public string getHistory() {
            string res = "--------BROWSING--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(string s in ba.getHistory())
                res += s + "\r\n";
            return res;
        }

        public string getAutofills() {
            string res = "--------AUTOFILLS--------\r\n";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(string s in ba.getAutofills())
                res += s + "\r\n";
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
                foreach (string s in ba.getAutofills())
                    l.Add(s);
                foreach (string s in ba.getHistory())
                    l.Add(s);
                foreach (string s in ba.getCookies())
                    l.Add(s);
                foreach (string s in ba.getDownloads())
                    l.Add(s);
                foreach (string s in ba.getPasswords())
                    l.Add(s);
                foreach (string s in ba.getSearches())
                    l.Add(s);
            }
            l.Sort();
            string result = "";
            foreach (string s in l)
                result += s + "\r\n";
            return result;
        }
    }
}
