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

        public DownloadsDTO(string time, string browser, string url, string path, string file): base(time, browser) {
            this.url = url;
            this.path =path;
            this.file = file;
        }

        public override string getType() {
            return "Download";
        }
        public override string getInfo() {
            return file+ " FROM URL: " + url + "\r\n\tTO PATH: " + path;
        }
    }
}
