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

        public String Domain { get { return domain; } }
        public String Value { get { return value; } }
        public String LastAccess { get { return lastAccess; } }
        public String Expiration { get { return expiration; } }


        public CookiesDTO(string time, string browser, string domain, string lastAccess, string expiration, string value) : base(time, browser) {
            this.domain = domain;
            this.lastAccess = lastAccess;
            this.expiration = expiration;
            this.value = value;
        }

        public string getDomain() {
            return domain;
        }

        public string getSmallString() {
            return getTime() + " " + getType() + " " + "domain: " + domain  +"\r\n" ;
        }

        public override string getType() {
            return " COOKIE   ";
        }
        public override string getInfo() {
            return "domain: "+domain + "\r\n" + " Value:" + value + "\r\n";
        }

        public string getExpiration()
        {
            return expiration;
        }

    }
}
