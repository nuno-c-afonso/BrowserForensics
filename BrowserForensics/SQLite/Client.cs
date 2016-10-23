using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite {
    public class Client {
        private SQLiteConnection dbConnection;

        public Client(string location) {
            dbConnection = new SQLiteConnection("Data Source=" + location);
        }

        public DataTable select(string query) {
            DataTable table = new DataTable();

            dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(dbConnection);
            command.CommandText = query;
            SQLiteDataReader reader = command.ExecuteReader();
            table.Load(reader);
            reader.Close();
            dbConnection.Close();

            return table;
        }
    }
}
