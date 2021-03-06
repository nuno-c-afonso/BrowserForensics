﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class HistoryDTO : DTObject {
        string url;
        string domain = "";

        public String Url { get { return url; } }

        public String Domain { get { return domain; } }

        public HistoryDTO(string time, string browser, string url) : base(time, browser) {
            this.url = url;
            if (url != null && url != "") {
                Uri myUri = new Uri(url);
                string auxdomain = myUri.Host;
                domain = auxdomain.Replace("www.", "");
            }
        }
        public string getDomain() {
            return domain;
        }

        public override string getType() {
            return " HISTORY ";
        }
        public override string getInfo() {
            return "Acessed URL: " + url;
        }
    }
}
