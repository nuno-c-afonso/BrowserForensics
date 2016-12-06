using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class CookiesDTO : DTObject {
        string domain;
        string lastAccess;
        string expiration;
        string value;


        public CookiesDTO(string time, string browser, string domain, string lastAccess, string expiration, string value) : base(time, browser) {
            this.domain = domain;
            this.lastAccess = lastAccess;
            this.expiration = expiration;
            this.value = value;
        }

        public override string getType() {
            return "Cookie";
        }
        public override string getInfo() {
            return "domain: "+domain;
        }
    }
}
