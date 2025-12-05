using System;
using System.Drawing;
using System.Windows.Forms;
using Typing_Test.Properties;


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
    }
}
