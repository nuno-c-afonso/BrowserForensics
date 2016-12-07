using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeAnalyzer
{
    public class ChromeAnalyzer : BrowserAnalyzer.BrowserAnalyzer {
        private static string defaultPath = @"C:\Users\" + Environment.UserName +
                                            @"\AppData\Local\Google";

        public ChromeAnalyzer(string location) :
            base(new ChromePasswordsAnalyzer(location + @"\Chrome\User Data\Default\Login Data"),
            new ChromeCookiesAnalyzer(location + @"\Chrome\User Data\Default\Cookies"),
            new ChromeDownloadHistoryAnalyzer(location + @"\Chrome\User Data\Default\History"),
            new ChromeSearchHistoryAnalyzer(location + @"\Chrome\User Data\Default\History"),
            new ChromeBrowserHistoryAnalyzer(location + @"\Chrome\User Data\Default\History"),
            new ChromeAutofillAnalyzer(location + @"\Chrome\User Data\Default\Web Data"),
            location) { }

        public ChromeAnalyzer() :
            base(new ChromePasswordsAnalyzer(defaultPath + @"\Chrome\User Data\Default\Login Data"),
            new ChromeCookiesAnalyzer(defaultPath + @"\Chrome\User Data\Default\Cookies"),
            new ChromeDownloadHistoryAnalyzer(defaultPath + @"\Chrome\User Data\Default\History"),
            new ChromeSearchHistoryAnalyzer(defaultPath + @"\Chrome\User Data\Default\History"),
            new ChromeBrowserHistoryAnalyzer(defaultPath + @"\Chrome\User Data\Default\History"),
            new ChromeAutofillAnalyzer(defaultPath + @"\Chrome\User Data\Default\Web Data"),
            defaultPath) { }
    }
}
