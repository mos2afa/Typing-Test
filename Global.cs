using System;
using System.IO;

namespace Typing_Test
{
    public static class Global
    {
        public static readonly string JsonSettingsPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Settings.json");


        public static readonly string Clean_DB_Path = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Clean_Typing_Test.db");

        public static readonly string LocalAppDataDbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Typing_Test.db");


        public static readonly string ConnectionString = 
            $"Data Source={Global.LocalAppDataDbPath}";

    }
}
