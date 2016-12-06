using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class SearchDTO : DTObject {

        string location ;
        string term;

        public SearchDTO(string time, string browser, string term, string location) : base(time, browser) {
            this.term = term;
            this.location = location;
        }
        public SearchDTO(string time, string browser, string term) : base(time, browser) {
            this.term = term;
            this.location = "";
        }


        public override string getType() {
            return "Auto Fill";
        }
        public override string getInfo() {
            return "SEARCHED " + term +" in. "+location;
        }
    }
}
