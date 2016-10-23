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
            analyzers.Add(new ChromeAnalyzer.ChromeAnalyzer());
        }

        public string getDownloads() {
            string res = "";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getDownloads();
            return res;
        }

        public string getPasswords() {
            string res = "";
            foreach (BrowserAnalyzer.BrowserAnalyzer ba in analyzers)
                res += ba.getPasswords();
            return res;
        }
    }
}
