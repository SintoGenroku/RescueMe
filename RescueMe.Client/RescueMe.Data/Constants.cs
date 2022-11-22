namespace RescueMe.Data
{
    public static class Constants
    {
        public const string DatabaseFilename = "Filename=RescueMeDb.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;


        public static string DatabasePath() 
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, DatabaseFilename);
            return path;
        }
        //Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
