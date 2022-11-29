using Microsoft.Data.Sqlite;

namespace RescueMe.Data
{
    public static class Constants
    {
        public const string DatabaseFilename = "Filename=RescueMeDb.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;


        public static string DatabasePath() 
        {
            string documentsPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RescueMeDb.db");// ; Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsPath, DatabaseFilename);
            return path;
        }
        //Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public static string connectionString = new SqliteConnectionStringBuilder("Data Source = RescueMeDb.db")
        {
            Mode = SqliteOpenMode.ReadWriteCreate,
            
        }.ToString();
    }
}
