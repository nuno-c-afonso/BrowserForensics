using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class AutofillDTO : DTObject {

        string value;

        public AutofillDTO(string time, string browser, string value) : base(time, browser) {
            this.value = value;
        }

        public override string getType() {
            return "Auto Fill";
        }
        public override string getInfo() {
            return "Value: "+value;
        }
    }
}
