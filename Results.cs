using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1
    {
        public class Test
        {

            public enMode Mode { get; set; }
            public double WPM { get; set; }
            public double Accuracy { get; set; }
            public double DurationSeconds { get; set; }
            public int CorrectWords { get; set; }
            public int WrongWords { get; set; }
            public int CorrectStrokes { get; set; }
            public int WrongStrokes { get; set; }
            public DateTime TestDate { get; set; }

            private static readonly string DbPath = Path.Combine(
                Environment.CurrentDirectory,
                "Typing_Results.db");

            private static readonly string ConnectionString = $"Data Source={DbPath}";

            static Test()
            {
                CreateTableIfNotExists();
            }

            private static void CreateTableIfNotExists()
            {
                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS TypingTests (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Mode TEXT,
                    WPM REAL,
                    Accuracy REAL,
                    DurationSeconds REAL,
                    CorrectWords INTEGER,
                    WrongWords INTEGER,
                    CorrectStrokes INTEGER,
                    WrongStrokes INTEGER,
                    TestDate DATETIME
                );";
                    cmd.ExecuteNonQuery();
                }
            }

            public static void AddResult(Test result)
            {
                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();

                    var insertCmd = conn.CreateCommand();
                    insertCmd.CommandText = @"
                INSERT INTO TypingTests
                (Mode, WPM, Accuracy, DurationSeconds, CorrectWords, WrongWords, CorrectStrokes, WrongStrokes, TestDate)
                VALUES
                (@Mode, @WPM, @Accuracy, @DurationSeconds, @CorrectWords, @WrongWords, @CorrectStrokes, @WrongStrokes, @TestDate);";

                    insertCmd.Parameters.AddWithValue("@Mode", result.Mode.ToString());
                    insertCmd.Parameters.AddWithValue("@WPM", result.WPM);
                    insertCmd.Parameters.AddWithValue("@Accuracy", result.Accuracy);
                    insertCmd.Parameters.AddWithValue("@DurationSeconds", result.DurationSeconds);
                    insertCmd.Parameters.AddWithValue("@CorrectWords", result.CorrectWords);
                    insertCmd.Parameters.AddWithValue("@WrongWords", result.WrongWords);
                    insertCmd.Parameters.AddWithValue("@CorrectStrokes", result.CorrectStrokes);
                    insertCmd.Parameters.AddWithValue("@WrongStrokes", result.WrongStrokes);
                    insertCmd.Parameters.AddWithValue("@TestDate", result.TestDate);

                    insertCmd.ExecuteNonQuery();

                    // Keep only the newest 1000 entries
                    var deleteCmd = conn.CreateCommand();
                    deleteCmd.CommandText = @"
                DELETE FROM TypingTests
                WHERE Id NOT IN (
                    SELECT Id FROM TypingTests
                    ORDER BY Id DESC
                    LIMIT 1000
                );";
                    deleteCmd.ExecuteNonQuery();
                }
            }

            public static double GetMaxWPM()
            {
                using (var conn = new SqliteConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT IFNULL(MAX(WPM), 0) FROM TypingTests;";
                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
        }
    }
}
