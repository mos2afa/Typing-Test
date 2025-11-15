using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SQLite.Generic;
using System.IO;
using ClosedXML.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Test
{
    public enum enMode { Words, Time };

    public class Test
    {
        public string Language { get; set; }

        public enMode Mode { get; set; }
        public double WPM { get; set; }
        public double Accuracy { get; set; } 
        public double DurationSeconds { get; set; } 
        public int CorrectWords { get; set; } 
        public int WrongWords { get; set; }
        public int CorrectStrokes { get; set; }
        public int WrongStrokes { get; set; }
        public DateTime TestDate { get; set; }

        public int CurrentWordCounter { get; set; }

        public Test()
        {
            Mode = enMode.Time;
            WPM = 0.0;
            Accuracy = 0.0;
            DurationSeconds = 0.0;
            CorrectWords = 0;
            WrongStrokes = 0;
            CorrectStrokes = 0;
            WrongWords = 0;
            TestDate = DateTime.Now;

            CurrentWordCounter = 0;
        }

        private static readonly string DbPath = Path.Combine(
            Environment.CurrentDirectory,
            "Typing_Results.db");

        private static readonly string ExcelSheetPath = Path.Combine(
            Environment.CurrentDirectory,
            "Typing_Results.xlsx");

        private static readonly string ConnectionString = $"Data Source={DbPath}";

        static Test()
        {
            CreateTableIfNotExists();
        }

        private static void CreateTableIfNotExists()
        {
            using (var conn = new SQLiteConnection(ConnectionString))
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

        public static void AddResult(Test result)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                var insertCmd = conn.CreateCommand();
                insertCmd.CommandText = @"
            INSERT INTO TypingTests
            (Language,Mode, WPM, Accuracy, DurationSeconds, CorrectWords, WrongWords, CorrectStrokes, WrongStrokes, TestDate)
            VALUES
            (@Language,@Mode, @WPM, @Accuracy, @DurationSeconds, @CorrectWords, @WrongWords, @CorrectStrokes, @WrongStrokes, @TestDate);";

                insertCmd.Parameters.AddWithValue("@Language", result.Language);
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
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT IFNULL(MAX(WPM), 0) FROM TypingTests;";
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        public static void ExportTypingTestsToExcel(string FilePath)
        {
            DataTable dt = new DataTable();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM TypingTests ORDER BY Id ASC", conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

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

        public static void ClearTypingTestsResults()
        {
            if (!File.Exists(DbPath))
                return;

            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand("DELETE FROM TypingTests;", conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DropTypingTestsResultsTable()
        {
            if (!File.Exists(DbPath))
                return;

            using (var conn = new SQLiteConnection(ConnectionString))
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
