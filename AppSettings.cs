using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;


namespace Typing_Test
{
    public class AppSettings
    {
        // these are HTML colors

        public string FormBackColor    {get;set; } 
        public string FontColor        {get;set; }
        public string CurrentWordColor {get;set; }
        public string CorrectWordColor {get;set; }
        public string WrongWordColor   {get;set; }
        public string SelectColor      {get;set; }
        public string TypeBarColor     {get;set; }
        public string CountersColor    {get;set; }

        public FormWindowState WindowState      {get;set; } // Normal, Maximized, Minimized
        public FormBorderStyle FormBorderStyle  {get;set; }

        public string SelectedLanguage {get;set; }

        public bool KeyboardVisible { get; set; }

        public static Color color(string HtmlColor)
        {
            return ColorTranslator.FromHtml(HtmlColor);
        }

        public static string color(Color objectColor)
        {
            return ColorTranslator.ToHtml(objectColor);
        }

        public AppSettings()
        {
            // Default values.
            
            FormBackColor     = color(Color.FromArgb(1, 3, 25));
            FontColor         = color(Color.FromArgb(60, 77, 120));
            CurrentWordColor  = color(Color.DodgerBlue);
            CorrectWordColor  = color(Color.Green);
            WrongWordColor    = color(Color.Red);
            SelectColor       = color(Color.DodgerBlue);
            TypeBarColor      = color(Color.White);
            CountersColor     = color(Color.DodgerBlue);

            SelectedLanguage = "English";

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            KeyboardVisible = true;
        }


        public static AppSettings Deserialize(string JsonString)
        {
            return JsonSerializer.Deserialize<AppSettings>(JsonString);
        }

        private static string JsonString()
        {
            return File.ReadAllText("Settings.json");
        }

        public static void SaveToFile(AppSettings settings)
        {
            File.WriteAllText(Global.JsonSettingsPath, Serialize(settings));
        }

        public static AppSettings LoadFromFile()
        {
            return Deserialize(JsonString());
        }

        public static string Serialize(AppSettings settings)
        {
            return JsonSerializer.Serialize(settings);
        }

    }
}
