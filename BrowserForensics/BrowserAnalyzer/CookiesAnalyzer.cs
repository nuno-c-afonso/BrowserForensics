using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserAnalyzer {
    public interface CookiesAnalyzer {
        List<string> getCookies();
    }
}
