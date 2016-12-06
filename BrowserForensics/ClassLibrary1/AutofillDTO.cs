using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class AutofillDTO : DTObject {

        string value;
        string fieldname;

        public AutofillDTO(string time, string browser, string value, string fieldname) : base(time, browser) {
            this.value = value;
            this.fieldname = fieldname;
        }
        public AutofillDTO(string time, string browser, string value) : base(time, browser) {
            this.value = value;
            this.fieldname = "";
        }

        public override string getType() {
            return "Auto Fill";
        }
        public override string getInfo() {
            return "FieldName:"+ fieldname+ " Value: "+value;
        }
    }
}
