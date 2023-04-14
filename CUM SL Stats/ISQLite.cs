using SQLite.Net;
using SQLite;

namespace SqliteAsyncExample
{
    /// <summary>
    /// SQLite.Net-PCL
    /// 
    /// https://github.com/oysteinkrog/SQLite.Net-PCL
    /// http://www.xamarinhelp.com/local-storage-day-10/
    /// </summary>
    public interface ISQLite
    {
        void CloseConnection();
        SQLite.Net.SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}