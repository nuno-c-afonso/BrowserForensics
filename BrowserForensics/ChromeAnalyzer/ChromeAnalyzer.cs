using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer
{
    public class ChromeAnalyzer : BrowserAnalyzer.BrowserAnalyzer {
        private static string defaultPath = @"C:\Users\" + Environment.UserName +
                                            @"\AppData";

        private static string chromeRelativePath = @"\Local\Google\Chrome\User Data\Profile 2";

        public ChromeAnalyzer(string location) :
            base(new ChromePasswordsAnalyzer(location + chromeRelativePath + @"\Login Data"),
            new ChromeCookiesAnalyzer(location + chromeRelativePath + @"\Cookies"),
            new ChromeDownloadHistoryAnalyzer(location + chromeRelativePath + @"\History"),
            new ChromeSearchHistoryAnalyzer(location + chromeRelativePath + @"\History"),
            new ChromeBrowserHistoryAnalyzer(location + chromeRelativePath + @"\History"),
            new ChromeAutofillAnalyzer(location  + chromeRelativePath + @"\Web Data"),
            location) { Console.WriteLine("ON CHROME " + location + chromeRelativePath); }

        public ChromeAnalyzer() :
            base(new ChromePasswordsAnalyzer(defaultPath + chromeRelativePath + @"\Login Data"),
            new ChromeCookiesAnalyzer(defaultPath + chromeRelativePath + @"\Cookies"),
            new ChromeDownloadHistoryAnalyzer(defaultPath + chromeRelativePath + @"\History"),
            new ChromeSearchHistoryAnalyzer(defaultPath + chromeRelativePath + @"\History"),
            new ChromeBrowserHistoryAnalyzer(defaultPath + chromeRelativePath + @"\History"),
            new ChromeAutofillAnalyzer(defaultPath + chromeRelativePath + @"\Web Data"),
            defaultPath) { Console.WriteLine("ON CHROME " + defaultPath + chromeRelativePath); }
    }
}
