using System;
using System.Drawing;
using Typing_Test.Properties;


namespace Typing_Test
{
    public class Settings
    {
        // these are HTML colors

        public string FormBackColor    {get;set; } 
        public string FontColor        {get;set; }
        public string CurrentWordColor {get;set; }
        public string CorrectWordColor {get;set; }
        public string WrongWordColor   {get;set; }
        public string SelectColor      {get;set; }
        public string TypeBarColor     {get;set; }

        public bool IsTimerVisible        {get;set; }
        public bool IsLiveWPMVisible      {get;set; }
        public bool IsWordsCounterVisible {get;set; }

        public string WindowState      {get;set; } // Normal, Maximized, Minimized
        public string FormBorderStyle  {get;set; }
    }
}
