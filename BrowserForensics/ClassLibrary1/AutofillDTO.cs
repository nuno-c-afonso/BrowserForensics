using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class AutofillDTO : DTObject {

        string value;
        string fieldname;

        public String FieldName { get { return fieldname; } }
        public String Value { get { return value; } }

        public AutofillDTO(string time, string browser, string value, string fieldname) : base(time, browser) {
            this.value = value;
            this.fieldname = fieldname;
        }
        public AutofillDTO(string time, string browser, string value) : base(time, browser) {
            this.value = value;
            this.fieldname = "";
        }

        public override string getType() {
            return " AUTOFILL ";
        }
        public override string getInfo() {
            return "FieldName:"+ fieldname+ " Value: "+value;
        }
    }
}
