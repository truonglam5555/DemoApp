using System;
using System.IO;
using SQLite;

namespace DemoApp.Common.Bussiness
{
    public class LocalDB
    {
        public static LocalDB _localDB = null;
        public static readonly object padlock = new object();
        private string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DB_DEMOAPP.db");

        private LocalDB()
        {
            Database = new SQLiteConnection(dbPath);
        }

        public static LocalDB Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_localDB == null)
                    {
                        _localDB = new LocalDB();
                    }
                    return _localDB;
                }
            }
        }

        public SQLiteConnection Database
        {
            get;
        }

        public bool TableExist(string TableName)
        {
            try
            {
                string query = string.Format("SELECT name FROM sqlite_master WHERE type='table' AND name='{0}';", TableName);
                SQLiteCommand cmd = Database.CreateCommand(query);
                var item = Database.Query<object>(query);
                if (item.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
