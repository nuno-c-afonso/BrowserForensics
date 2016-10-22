using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer
{
    public class ChromeAnalyzer : BrowserAnalyzer.BrowserAnalyzer {
        public ChromeAnalyzer(ChromePasswordsAnalyzer pa, ChromeCookiesAnalyzer ca,
            ChromeDownloadHistoryAnalyzer dha, ChromeSearchHistoryAnalyzer sha,
            ChromeBrowserHistoryAnalyzer bha, ChromeAutofillAnalyzer aa) :
            base(pa, ca, dha, sha, bha, aa) { }
    }
}
