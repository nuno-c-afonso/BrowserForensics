using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class SearchDTO : DTObject {

        string location ;
        string term;

        public String Term { get { return term; } }
        public String Location { get { return location; } }

        public SearchDTO(string time, string browser, string term, string location) : base(time, browser) {
            this.term = term;
            this.location = location;
        }
        public SearchDTO(string time, string browser, string term) : base(time, browser) {
            this.term = term;
            this.location = "";
        }


        public override string getType() {
            return " SEARCH   ";
        }
        public override string getInfo() {
            string str = "Searched " + term;
            if (location != null && !location.Equals("") )
                str += " in: " + location;
            return str;
        }
    }
}
