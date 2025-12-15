using System.Collections.Generic;
using System.Windows.Forms;

namespace Typing_Test
{
    public class Languages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Words { get; set; }

        public static void CreateLanguagesTableIfNotExists()
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={Global.Clean_DB_Path}"))
            {
                connection.Open();
                using (var command = new System.Data.SQLite.SQLiteCommand(connection))
                {
                    command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Languages (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Words TEXT NOT NULL
                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string GetLanguageWords(string Name)
        {
            string Words = "";

            using (var connection = new System.Data.SQLite.SQLiteConnection(Global.ConnectionString))
            {
                connection.Open();
                using (var command = new System.Data.SQLite.SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Words FROM Languages WHERE Name = @Name";
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        Words = command.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        Words = "?";
                        MessageBox.Show(Name + " language words not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return Words;
        }

        public static List<string> GetAllLanguageNames()
        {
            List<string> languageNames = new List<string>();
            using (var connection = new System.Data.SQLite.SQLiteConnection(Global.ConnectionString))
            {
                connection.Open();
                using (var command = new System.Data.SQLite.SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Name FROM Languages";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            languageNames.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return languageNames;
        }

        public static void AddLanguageInDataBase(string Name, string Words)
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={Global.Clean_DB_Path}"))
            {
                connection.Open();
                using (var command = new System.Data.SQLite.SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Languages (Name, Words) VALUES (@Name, @Words)";
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Words", Words);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateLanguageInDataBase(string Name, string Words)
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={Global.Clean_DB_Path}"))
            {
                connection.Open();
                using (var command = new System.Data.SQLite.SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE Languages SET Words = @Words WHERE Name=@Name";
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Words", Words);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
