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

        public Controller(string location=null) {
            // Add the wanted browsers analyzers
            // TODO: Ask for the directory. If none, choose the default one.
            if (location == null) {
                try {
                    analyzers.Add(new ChromeAnalyzer.ChromeAnalyzer());
                } catch (Exception e) { Console.WriteLine("Chrome File not found"); }
                try {
                    analyzers.Add(new FirefoxAnalyser.FirefoxAnalyzer());
                } catch (Exception e) { Console.WriteLine("FIREFOX File not found"); }
            }
            else {
                try {
                    analyzers.Add(new ChromeAnalyzer.ChromeAnalyzer(location));
                } catch (Exception e) { Console.WriteLine("Chrome File not found"); }
                try {
                    analyzers.Add(new FirefoxAnalyser.FirefoxAnalyzer(location));
                }catch(Exception e) { Console.WriteLine("FIREFOX File not found"); }
            }
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
                    l.Add(dto.getSmallString());
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

        public string detectIncoherencies() {
            string result = "";
            List<string> l = new List<string>();


            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers) {
                List<string[]> history = new List<string[]>();
                List<string[]> cookies = new List<string[]>();
                foreach (HistoryDTO dto in ba.getHistory())
                    history.Add(new string[] { dto.getTime(), dto.getDomain() });
                foreach (CookiesDTO dto in ba.getCookies())
                    cookies.Add(new string[] { dto.getTime(), dto.getDomain() });
            
                history = history.ToList().OrderBy(o => o[0]).ToList();
                cookies = cookies.ToList().OrderBy(o => o[0]).ToList();

                List<string[]> history2 = new List<string[]>();
                string[] prev = { "x", "x" };
                foreach (string[] x in history)
                    if (x[0] != prev[0] || x[0] != prev[0]) {
                        history2.Add(x);
                        prev = x;
                    }

                List<string[]> cookies2 = new List<string[]>();
                prev =new string[] { "x", "x" };
                foreach (string[] x in cookies)
                    if (x[0] != prev[0] || x[0] != prev[0]) {
                        cookies2.Add(x);
                        prev = x;
                    }
  
                Boolean found = false;
                foreach (string[] cookie in cookies2) {
                    found = false;
                    foreach (string[] visit in history2)
                        if (visit[1].EndsWith(cookie[1]))
                            found = true;
                    if (!found)
                        l.Add(cookie[1]);

                }
                l = l.Distinct().ToList();
            }

            result += "-->Have been found cookies for the next domains that are not in the history:\r\n";
            foreach (string s in l)
                result += s+ "\r\n";
            return result;

        }

        public string getAllDomains() {
            List<string> l = new List<string>();

            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers) {
                foreach (HistoryDTO dto in ba.getHistory())
                    l.Add(dto.getDomain());

                foreach (CookiesDTO dto in ba.getCookies())
                    l.Add(dto.getDomain());

                foreach (DownloadsDTO dto in ba.getDownloads())
                    l.Add(dto.getDomain());

                foreach (PasswordDTO dto in ba.getPasswords())
                    l.Add(dto.getDomain());
            }

            l.Sort();

            List<string> lout = new List<string>();
            string prev = "";
            foreach (string x in l)
                if (x != prev) {
                    lout.Add(x);
                    prev = x;
                }

            string result = "-->All the Domains found in browser \r\n";

            foreach (string s in lout)
                result += s + "\r\n";

            return result;



        }
    }
}
