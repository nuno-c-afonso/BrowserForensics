using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public abstract class DTObject {
        string time;
        string browser;

        public DTObject(string time, string browser) {
            this.time = time;
            this.browser = browser;
        }

        public string getTime() { return time; }
        public abstract string getType();
        public abstract string getInfo();

    }
}
