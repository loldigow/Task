using System.Data.SqlTypes;
using System.IO;
using System;

public static class Constants
{
    public const string DatabaseFilename = "bancoDeDados.db3";

    public static string BancoDeDados
    {
        get
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
        }
    }
}