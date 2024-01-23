using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;
using System.Linq;


[assembly: Dependency(typeof(SQLIte_.SQliteDroid))]

namespace SQLIte_
{
    class SQliteDroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "Mydatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    
    }
}
