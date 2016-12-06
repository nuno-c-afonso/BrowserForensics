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

        public PasswordDTO(string time, string browser, string url, string username, string password): base(time, browser) {
            this.url = url;
            this.username = username;
            this.password = password;
        }

        public override string getType() {
            return "Password";
        }
        public override string getInfo() {
            return "PASSWORD FROM: " + url + "\r\n\tUSERNAME: " + username + "\r\n\tPASSWORD: " + password;
        }
    }
}
