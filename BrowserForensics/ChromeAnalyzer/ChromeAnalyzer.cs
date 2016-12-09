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

        private static string chromeRelativePath = @"\Local\Google\Chrome\User Data\Default";

        public ChromeAnalyzer(string location) :
            base(new ChromePasswordsAnalyzer(location + @"\Chrome" + @"\Login Data"),
            new ChromeCookiesAnalyzer(location + @"\Chrome" + @"\Cookies"),
            new ChromeDownloadHistoryAnalyzer(location + @"\Chrome" + @"\History"),
            new ChromeSearchHistoryAnalyzer(location + @"\Chrome" + @"\History"),
            new ChromeBrowserHistoryAnalyzer(location + @"\Chrome" + @"\History"),
            new ChromeAutofillAnalyzer(location  + @"\Chrome" + @"\Web Data"),
            location) { Console.WriteLine("ON CHROME " + location + @"\Chrome"); }

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
