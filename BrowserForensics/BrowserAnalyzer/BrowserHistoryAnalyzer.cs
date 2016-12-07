using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BrowserAnalyzer {
    public interface BrowserHistoryAnalyzer {
        List<HistoryDTO> getHistory();
    }
}
