using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace LibraryApplication.Connections
{
    public class sqliteConnectionsClass
    {
        public SQLiteConnection getUserScoresConnection()
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=..\..\UserScores.db");
            return con;
        }

    }
    
}
