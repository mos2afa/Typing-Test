using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using ClosedXML.Excel;

namespace Typing_Test
{
    public enum enMode { Words10 = 10, Words25 = 25, Words50 = 50, Words100 = 100, Time15 = 15,Time30 = 30,Time60 = 60,Time120 = 120};

    public static class Test
    {
        public static string Language { get; set; }

        public static enMode Mode { get; set; }
        public static double WPM { get; set; }
        public static double Accuracy { get; set; } 
        public static double DurationSeconds { get; set; } 
        public static int CorrectWords { get; set; } 
        public static int WrongWords { get; set; }
        public static int CorrectStrokes { get; set; }
        public static int WrongStrokes { get; set; }
        public static DateTime TestDate { get; set; }

        public static int CurrentWordCounter { get; set; }

        static Test()
        {
            Language = "English";

            Mode = enMode.Time15;
            WPM = 0.0;
            Accuracy = 0.0;
            DurationSeconds = 0.0;
            CorrectWords = 0;
            WrongStrokes = 0;
            CorrectStrokes = 0;
            WrongWords = 0;
            TestDate = DateTime.Now;

            CurrentWordCounter = 1;
        }

        public static bool IsTimeMode()
        {
            return Mode.ToString().Contains("Time");
        }

        public static bool IsWordsMode()
        {
            return !IsTimeMode();
        }

        private static void CreateTableIfNotExists()
        {
            using (var conn = new SQLiteConnection(Global.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS TypingTests (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Language TEXT,
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

        public static void AddResult()
        {
            using (var conn = new SQLiteConnection(Global.ConnectionString))
            {
                conn.Open();

                var insertCmd = conn.CreateCommand();
                insertCmd.CommandText = @"
            INSERT INTO TypingTests
            (Language,Mode, WPM, Accuracy, DurationSeconds, CorrectWords, WrongWords, CorrectStrokes, WrongStrokes, TestDate)
            VALUES
            (@Language,@Mode, @WPM, @Accuracy, @DurationSeconds, @CorrectWords, @WrongWords, @CorrectStrokes, @WrongStrokes, @TestDate);";

                insertCmd.Parameters.AddWithValue("@Language", Language);
                insertCmd.Parameters.AddWithValue("@Mode",Mode.ToString());
                insertCmd.Parameters.AddWithValue("@WPM", WPM);
                insertCmd.Parameters.AddWithValue("@Accuracy", Accuracy);
                insertCmd.Parameters.AddWithValue("@DurationSeconds", DurationSeconds);
                insertCmd.Parameters.AddWithValue("@CorrectWords", CorrectWords);
                insertCmd.Parameters.AddWithValue("@WrongWords", WrongWords);
                insertCmd.Parameters.AddWithValue("@CorrectStrokes", CorrectStrokes);
                insertCmd.Parameters.AddWithValue("@WrongStrokes", WrongStrokes);
                insertCmd.Parameters.AddWithValue("@TestDate", TestDate);

                insertCmd.ExecuteNonQuery();

                // Keep only the newest 1000 entries
            //    var deleteCmd = conn.CreateCommand();
            //    deleteCmd.CommandText = @"
            //DELETE FROM TypingTests
            //WHERE Id NOT IN (
            //    SELECT Id FROM TypingTests
            //    ORDER BY Id DESC
            //    LIMIT 1000
            //);";
            //    deleteCmd.ExecuteNonQuery();
            }
        }

        public static double GetMaxWPM(string LanguageName,enMode Mode)
        {
            using (var conn = new SQLiteConnection(Global.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT IFNULL(MAX(WPM), 0) FROM TypingTests " +
                    "Where Language = @LanguageName AND Mode = @Mode;";
                cmd.Parameters.AddWithValue("@LanguageName", LanguageName);
                cmd.Parameters.AddWithValue("@Mode", Mode.ToString());
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        public static DataTable GetTypingTests()
        {
            DataTable dt = new DataTable();
            using (var conn = new SQLiteConnection(Global.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM TypingTests ORDER BY Id ASC", conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public static DataTable GetTypingTestsForShowing()
        {
            DataTable dt = new DataTable();
            using (var conn = new SQLiteConnection(Global.ConnectionString))
            {
                conn.Open();
                string Query = @"SELECT WPM,Mode,Language,Accuracy || '%' AS Accuracy,
                            DurationSeconds AS Seconds,CorrectWords || '/' || WrongWords AS Words,
                            CorrectStrokes || '/'  || WrongStrokes as Strokes,
                            TestDate AS Date FROM TypingTests ORDER BY TestDate DESC";
                using (var cmd = new SQLiteCommand(Query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public static void ExportTypingTestsToExcel(string FilePath)
        {
            DataTable dt = GetTypingTests();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("TypingTests");

                // Add column headers
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                }

                // Add rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dt.Rows[i][j]?.ToString() ?? string.Empty;
                    }
                }

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(FilePath);
            }
        }

        public static void ClearTypingTestsResultsTable()
        {
            DropTypingTestsResultsTable();
            CreateTableIfNotExists();
        }

        private static void DropTypingTestsResultsTable()
        {
            if (!File.Exists(Global.LocalAppDataDbPath))
                return;

            using (var conn = new SQLiteConnection(Global.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand("DROP TABLE IF EXISTS TypingTests;", conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
