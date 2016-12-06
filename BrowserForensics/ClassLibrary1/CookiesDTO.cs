using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class CookiesDTO : DTObject {
        string domain;

        public CookiesDTO(string time, string browser, string domain) : base(time, browser) {
            this.domain = domain;
        }

        public override string getType() {
            return "Cookie";
        }
        public override string getInfo() {
            return "domain: "+domain;
        }
    }
}
