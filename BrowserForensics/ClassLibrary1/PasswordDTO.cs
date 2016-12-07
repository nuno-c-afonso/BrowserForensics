using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class PasswordDTO : DTObject {
        string url;
        string username;
        string password;
        string domain = "";

        public PasswordDTO(string time, string browser, string url, string username, string password): base(time, browser) {
            this.url = url;
            this.username = username;
            this.password = password;
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
            return " PASSWORD ";
        }
        public override string getInfo() {
            return "from: " + url + "\r\n\tUSERNAME: " + username + "\r\n\tPASSWORD: " + password;
        }
    }
}
