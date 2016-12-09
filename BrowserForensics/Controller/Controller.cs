using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Diagnostics;

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
            StringBuilder sb = new StringBuilder("--------DOWNLOADS--------\r\n");
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach (DownloadsDTO dto in ba.getDownloads())
                    sb.Append(dto.getFullString());
            return sb.ToString();
        }

        public string getPasswords() {
            StringBuilder sb = new StringBuilder("--------PASSWORDS--------\r\n");
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(PasswordDTO dto in ba.getPasswords())
                    sb.Append(dto.getFullString());
            return sb.ToString();
        }

        public string getCookies() {
            StringBuilder sb = new StringBuilder("--------COOKIES--------\r\n");
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(CookiesDTO dto in ba.getCookies())
                    sb.Append(dto.getFullString());
            return sb.ToString();
        }

        public string getSearches() {
            StringBuilder sb = new StringBuilder("--------SEARCHES--------\r\n");
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(SearchDTO dto in ba.getSearches())
                    sb.Append(dto.getFullString());
            return sb.ToString();
        }

        public string getHistory() {
            StringBuilder sb = new StringBuilder("--------BROWSING--------\r\n");
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)  
                foreach (HistoryDTO dto in ba.getHistory())
                    sb.Append(dto.getFullString());
        
            return sb.ToString();
        }

        public string getAutofills() {
            StringBuilder sb = new StringBuilder("--------AUTOFILLS--------\r\n");
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                foreach(AutofillDTO dto in ba.getAutofills())
                    sb.Append(dto.getFullString()); 
            return sb.ToString();
        }


        public List<DownloadsDTO> getDownloadsDTOList()
        {
            List<DownloadsDTO> ldto = new List<DownloadsDTO>();
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                ldto.AddRange(ba.getDownloads());
            return ldto;
        }

        public List<PasswordDTO> getPasswordsDTOList()
        {
            List<PasswordDTO> ldto = new List<PasswordDTO>();
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                ldto.AddRange(ba.getPasswords());
            return ldto;
        }

        public List<CookiesDTO> getCookiesDTOList()
        {
            List<CookiesDTO> ldto = new List<CookiesDTO>();
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                ldto.AddRange(ba.getCookies());
            return ldto;
        }

        public List<SearchDTO> getSearchesDTOList()
        {
            List<SearchDTO> ldto = new List<SearchDTO>();
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                ldto.AddRange(ba.getSearches());
            return ldto;
        }

        public List<HistoryDTO> getHistoryDTOList()
        {
            List<HistoryDTO> ldto = new List<HistoryDTO>();
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                ldto.AddRange(ba.getHistory());
            return ldto;
        }

        public List<AutofillDTO> getAutofillsDTOList()
        {
            List<AutofillDTO> ldto = new List<AutofillDTO>();
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                ldto.AddRange(ba.getAutofills());
            return ldto;
        }


        public string getAllInfo() {
            StringBuilder sb = new StringBuilder();
            try{ sb.Append(getDownloads());            } catch (Exception e) {}
            try{ sb.Append("\r\n" + getPasswords());   } catch (Exception e) {}
            try{ sb.Append("\r\n" + getCookies());     } catch (Exception e) {}
            try{ sb.Append("\r\n" + getSearches());    } catch (Exception e) {}
            try{ sb.Append("\r\n" + getHistory());     } catch (Exception e) {}
            try{ sb.Append("\r\n" + getAutofills());   } catch (Exception e) {}

            return sb.ToString();
        }

        public string getTimeline() {
            List<string> l = new List<string>();

            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers) {
                try{
                    foreach (AutofillDTO dto in ba.getAutofills())
                        l.Add(dto.getFullString());
                } catch (Exception e) {}
                try{
                    foreach (HistoryDTO dto in ba.getHistory())
                        l.Add(dto.getFullString());
                } catch (Exception e) {} 
                try{
                    foreach (CookiesDTO dto in ba.getCookies())
                        l.Add(dto.getSmallString());
                } catch (Exception e) {} 
                try{
                    foreach (DownloadsDTO dto in ba.getDownloads())
                        l.Add(dto.getFullString());
                } catch (Exception e) {} 
                try{
                    foreach (PasswordDTO dto in ba.getPasswords())
                        l.Add(dto.getFullString());
                } catch (Exception e) {} 
                try{
                    foreach (SearchDTO dto in ba.getSearches())
                        l.Add(dto.getFullString());
                } catch (Exception e) {}   
            }
            l.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (string s in l)
                sb.Append(s);
            return sb.ToString();
        }

        public string detectIncoherencies() {
            StringBuilder sb = new StringBuilder();
            List<string> l = new List<string>();
            List<string> l2 = new List<string>();


            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers) {
                List<string[]> history = new List<string[]>();
                List<string[]> cookies = new List<string[]>();
                foreach (HistoryDTO dto in ba.getHistory())
                    history.Add(new string[] { dto.getTime(), dto.getDomain() });
                foreach (CookiesDTO dto in ba.getCookies())
                    cookies.Add(new string[] { dto.getTime(), dto.getDomain() });

                //history = history.ToList().OrderBy(o => o[0]).ToList();
                //cookies = cookies.ToList().OrderBy(o => o[0]).ToList();

                //List<string[]> history2 = new List<string[]>();
                //string[] prev = { "x", "x" };
                //foreach (string[] x in history)
                //    if (x[0] != prev[0] || x[0] != prev[0])
                //    {
                //        history2.Add(x);
                //        prev = x;
                //    }

                //List<string[]> cookies2 = new List<string[]>();
                //prev = new string[] { "x", "x" };
                //foreach (string[] x in cookies)
                //    if (x[0] != prev[0] || x[0] != prev[0])
                //    {
                //        cookies2.Add(x);
                //        prev = x;
                //    }


                var distinctItemsHistory = history.GroupBy(x => x[1]).Select(y => y.First());
                var distinctItemsCookies = cookies.GroupBy(x => x[1]).Select(y => y.First());

                var sw = Stopwatch.StartNew();



                Console.WriteLine("Using Parallel.ForEach");
                object sync = new Object();
                Parallel.ForEach(distinctItemsCookies, cookie =>
                {
                    Boolean found2 = false;
                    foreach (string[] visit in distinctItemsHistory)
                        if (visit[1].EndsWith(cookie[1]))
                            found2 = true;
                    lock (sync)
                    {
                        if (!found2)
                            l.Add(cookie[1]);
                    }
                }
                );
                l = l.Distinct().ToList();
                l.Sort();
                Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", sw.Elapsed.TotalSeconds);

                
                
            }


            sb.Append("-->Have been found cookies for the next domains that are not in the history:\r\n");
            foreach (string s in l)
                sb.Append(s + "\r\n");
            return sb.ToString();

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

            //l.Sort();

            //List<string> lout = new List<string>();
            //string prev = "";
            //foreach (string x in l)
            //    if (x != prev) {
            //        lout.Add(x);
            //        prev = x;
            //    }

            l = l.Distinct().ToList();
            l.Sort();

            StringBuilder sb = new StringBuilder("-->All the Domains found in browser \r\n");

            foreach (string s in l)
                sb.Append(s + "\r\n");

            return sb.ToString();


        }
    }
}
