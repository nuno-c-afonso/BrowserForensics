
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyser
{

    private static string defaultPath = @"C:\Users\" + Environment.UserName +
                                            @"\AppData\Local\Google\Chrome";
    public class FirefoxAnalyzer {
        base(new FirefoxPasswordsAnalyzer(defaultPath + @"\User Data\Default\Login Data"),
            new FirefoxCookiesAnalyzer(defaultPath + @"\User Data\Default\Cookies"),
            new FirefoxDownloadHistoryAnalyzer(defaultPath + @"\User Data\Default\History"),
            new FirefoxSearchHistoryAnalyzer(defaultPath + @"\User Data\Default\History"),
            new FirefoxBrowserHistoryAnalyzer(defaultPath + @"\User Data\Default\History"),
            new FirefoxAutofillAnalyzer(defaultPath + @"\User Data\Default\Web Data")) { }
    }
}
