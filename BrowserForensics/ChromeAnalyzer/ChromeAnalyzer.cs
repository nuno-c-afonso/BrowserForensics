using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer
{
    public class ChromeAnalyzer : BrowserAnalyzer.BrowserAnalyzer {
        private static string defaultPath = @"C:\Users\" + Environment.UserName +
                                            @"\AppData\Local\Google\Chrome";

        public ChromeAnalyzer() :
            base(new ChromePasswordsAnalyzer(defaultPath + @"\User Data\Default\Login Data"),
            new ChromeCookiesAnalyzer(defaultPath + @"\User Data\Default\Cookies"),
            new ChromeDownloadHistoryAnalyzer(defaultPath + @"\User Data\Default\History"),
            new ChromeSearchHistoryAnalyzer(defaultPath + @"\User Data\Default\History"),
            new ChromeBrowserHistoryAnalyzer(defaultPath + @"\User Data\Default\History"),
            new ChromeAutofillAnalyzer(defaultPath + @"\User Data\Default\Web Data")) { }
    }
}
