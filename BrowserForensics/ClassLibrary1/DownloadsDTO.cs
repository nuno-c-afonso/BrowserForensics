using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class DownloadsDTO : DTObject {
        string url;
        string path;
        string file;
        string domain = "";

        public String File { get { return file; } }
        public String URL { get { return url; }  }
        public String Domain { get { return domain; } }
        public String Path { get { return path; } }

        public DownloadsDTO(string time, string browser, string url, string path, string file): base(time, browser) {
            this.url = url;
            this.path =path;
            this.file = file;
            if (url != null && url != "") {
                Uri myUri = new Uri(url);
                string auxdomain = myUri.Host;
                domain = auxdomain.Replace("www.", "");
            }
        }

        public string getDomain() {
            return domain;
        }

        public override string getType() {
            return " DOWNLOAD ";
        }
        public override string getInfo() {
            return file+ " from URL: " + url + "\r\n\tto path: " + path;
        }
    }
}
