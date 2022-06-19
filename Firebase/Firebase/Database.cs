using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Firebase
{
    class Database
    {
        public SQLiteConnection connexion;

        public Database()
        {
            connexion = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
            }
        }

        public void OpenConnection()
        {
            if (connexion.State != System.Data.ConnectionState.Open)
            {
                connexion.Open();
            }
        }

        public void CloseConnection()
        {
            if (connexion.State != System.Data.ConnectionState.Closed)
            {
                connexion.Close();
            }
        }
    }
}
