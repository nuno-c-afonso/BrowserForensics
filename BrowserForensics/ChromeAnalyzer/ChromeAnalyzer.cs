using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer
{
    public class ChromeAnalyzer : BrowserAnalyzer.BrowserAnalyzer {
        public ChromeAnalyzer() : base(new ChromePasswordsAnalyzer(), new ChromeCookiesAnalyzer(),
            new ChromeDownloadHistoryAnalyzer(@"C:\Users\" + Environment.UserName + 
                @"\AppData\Local\Google\Chrome\User Data\Default\History"),
            new ChromeSearchHistoryAnalyzer(),
            new ChromeBrowserHistoryAnalyzer(), new ChromeAutofillAnalyzer()) { }
    }
}
