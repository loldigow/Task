using System.Data.SqlTypes;

namespace DB
{
    public static class Constants
    {
        public const string DatabaseFilename = "Task.db3";
        public static string BancoDeDados
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}