using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLOBDecipher {
    public class WindowsBLOBDecipher {
        public static DataTable decipherQueryResultField(string id, DataTable result) {
            foreach (DataRow r in result.Rows) {
                byte[] valueBytes = (byte[]) r[id];

                try {
                    valueBytes = ProtectedData.Unprotect(valueBytes, null, DataProtectionScope.CurrentUser);
                    r[id] = valueBytes;
                } catch (CryptographicException e) {
                    Console.WriteLine("Data could not be decrypted. An error occurred.");
                    Console.WriteLine(e.ToString());
                    continue; // Try the next row.
                }
            }

            return result;
        }
    }
}
