using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BrowserAnalyzer {
    public abstract class SearchHistoryAnalyzer {
        public abstract List<SearchDTO> getSearches();
    

        public string[] getSearchInURL(string url) {
            string query = "";
            string[] output = null;
            int first = url.IndexOf("search?q=");
            if (first != -1) {
                first += "search?q=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first != -1) {
                    output = new string[] { "Google:", query.Substring(0, first).Replace('+', ' ') };
                }
            }
            query = "";
            first = url.LastIndexOf("?search_query=");
            if (first != -1) {
                first += "?search_query=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first == -1) {
                    output = new string[] { "Youtube:", query.Replace('+', ' ') };
                }
            }
            query = "";
            first = url.LastIndexOf("www.facebook.com/search/top/?q=");
            if (first != -1) {
                first += "www.facebook.com/search/top/?q=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first == -1) {
                    output = new string[] { "Facebook:", query.Replace('+', ' ') };
                }
            }
            query = "";
            first = url.LastIndexOf("?url=search-alias%3Daps&field-keywords=");
            if (first != -1) {
                first += "?url=search-alias%3Daps&field-keywords=".Length;
                query = url.Substring(first);
                //Console.WriteLine("query:" + query);
                first = query.IndexOf("&");
                if (first == -1) {
                    output = new string[] { "Amazon:", query.Replace('+', ' ') };
                }
            }
            query = "";
            first = url.IndexOf("_nkw=");
            if (first != -1) {
                first += "_nkw=".Length;
                query = url.Substring(first);
                first = query.IndexOf("&");
                if (first != -1) {
                    output = new string[] { "Ebay:", query.Substring(0, first).Replace('+', ' ') };
                }
            }

            return output;

        }
    }
}
