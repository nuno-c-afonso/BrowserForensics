
using FirefoxAnalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxAnalyser
{

   
    public class FirefoxAnalyzer : BrowserAnalyzer.BrowserAnalyzer{

        private static string defaultPath = @"C:\Users\" + Environment.UserName + @"\AppData";
        private static string firefoxRelativePath = @"\Roaming\Mozilla\Firefox\Profiles";
        private static string fileLocation = Directory.GetDirectories(defaultPath + firefoxRelativePath, "storage", System.IO.SearchOption.AllDirectories).ElementAt(0) + "\\..";

        public FirefoxAnalyzer(): base(new FirefoxPasswordsAnalyzer(fileLocation + @"\signons.sqlite"),
                new FirefoxCookiesAnalyzer(fileLocation + @"\cookies.sqlite"),
                new FirefoxDownloadHistoryAnalyzer(fileLocation + @"\places.sqlite"), 
                new FirefoxSearchHistoryAnalyzer(fileLocation + @"\places.sqlite"),
                new FirefoxBrowserHistoryAnalyzer(fileLocation + @"\places.sqlite"),
                new FirefoxAutofillAnalyzer(fileLocation + @"\formhistory.sqlite"),
                fileLocation) {
            Console.WriteLine(fileLocation);
            Console.WriteLine("ON FIREFOX " + fileLocation);
        }

        public FirefoxAnalyzer(string location) :
            base(new FirefoxPasswordsAnalyzer(location + @"\Firefox" + @"\signons.sqlite"),
                new FirefoxCookiesAnalyzer(location + @"\Firefox" + @"\cookies.sqlite"),
                new FirefoxDownloadHistoryAnalyzer(location + @"\Firefox" + @"\places.sqlite"),
                new FirefoxSearchHistoryAnalyzer(location + @"\Firefox" + @"\places.sqlite"),
                new FirefoxBrowserHistoryAnalyzer(location + @"\Firefox" + @"\places.sqlite"),
                new FirefoxAutofillAnalyzer(location + @"\Firefox" + @"\formhistory.sqlite"),
                location) {
            Console.WriteLine(location);
            Console.WriteLine("ON FIREFOX " + location + @"\Firefox");
        }

    }
}
