using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLIte_
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
