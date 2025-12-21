using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml.Presentation;
using Control = System.Windows.Forms.Control;

namespace Typing_Test
{
    public partial class Form1
    {
        System.Windows.Forms.Button CurrentBtn;


        private void LoadFirstTime()
        {
            CurrentBtn = btn15;

            if (!File.Exists(Global.LocalAppDataDbPath))
            {
                File.Copy(Global.Clean_DB_Path, Global.LocalAppDataDbPath);
            }

            Languages.GetAllLanguageNames().ForEach(L => cbLanguage.Items.Add(L));

            if (!File.Exists(Global.JsonSettingsPath))
            {
                LoadDefaultSettings();
                using (File.Create(Global.JsonSettingsPath)) { };
                Serialize();
                SaveToFile();
            }
            else
            {
                LoadSettings();
            }

            tbType.Select();

            ShowTypingTestScreen();

            SetFirstWordColor();

            ChangeSomeColorsAccordingToFormBackColor();

            btn15.BackColor = SelectColor;
            btnTime.BackColor = SelectColor;

            CustomizeToolTip();

            InitializeKeyboardDictionary();

            CheckCapsLock();
        }

        private void PerformBtnTimeClick()
        {
            if (Test.IsTimeMode()) return;

            Test.Mode = enMode.Time15;

            btnTime.BackColor = SelectColor;
            btnWords.BackColor = Color.Black;

            tbTimer.Show();
            tbWordsCounter.Hide();

            NumberOfWords = 1000;
            CurrentWords = new string[NumberOfWords];

            Restart();

            BringToFrontTimeButtons();

            CurrentBtn = btn15;
            ChangeNumberOfSeconds(CurrentBtn);
        }

        private void PerformBtnWordsClick()
        {
            if (Test.IsWordsMode()) return;

            Test.Mode = enMode.Words10;

            btnWords.BackColor = SelectColor;
            btnTime.BackColor = Color.Black;

            tbTimer.Hide();
            tbWordsCounter.Show();

            NumberOfSeconds = short.MaxValue;

            Restart();

            BringToFrontWordButtons();

            CurrentBtn = btn10;
            ChangeNumberOfWords(CurrentBtn);
        }

        private void PerformBtnRestartClick()
        {
            IsTestCompleted = false;
            ShowTypingTestScreen();

            Restart();
        }


        private bool ImportSettingsFromClipBoard()
        {
            jsonString = Clipboard.GetText();

            try
            {
                Deserialize();

                SaveToFile();

                LoadSettings();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ExportSettingsFromClipBoard()
        {
            SaveSettings();

            Clipboard.SetText(jsonString);
        }

        private void lbChangeFormBackColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = this.BackColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cdChangeColor.Color;
                SaveSettings();
            }
        }

        private void lbChangertbWordsForeColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = rtbWords.ForeColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                rtbWords.ForeColor = cdChangeColor.Color;
                SaveSettings();
                SetFirstWordColor();
            }
        }

        private void lbChangeCurrentWordColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = CurrentWordColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                CurrentWordColor = cdChangeColor.Color;
                SaveSettings();
                SetFirstWordColor();
            }
        }

        private void lbChangeCorrectWordColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = CorrectWordColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                CorrectWordColor = cdChangeColor.Color;
                SaveSettings();
            }
        }

        private void lbChangeWrongWordColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = WrongWordColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                WrongWordColor = cdChangeColor.Color;
                SaveSettings();
            }
        }

        private void lbChangetbTypeForeColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = tbType.ForeColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                tbType.ForeColor = cdChangeColor.Color;
                SaveSettings();
            }
        }

        private void lbChangeCountersColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = tbLiveWPM.ForeColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                ChangeCountersForeColor(cdChangeColor.Color);
                SaveSettings();
            }
        }

        private void lbChangeSelectColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = SelectColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                SelectColor = cdChangeColor.Color;
                SaveSettings();

                CurrentBtn.BackColor = SelectColor;

                if (Test.IsTimeMode()) 
                    btnTime.BackColor = SelectColor;
                else
                    btnWords.BackColor = SelectColor;
            }
        }

        private void PerformKeyDown(KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.W)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }

            if (e.KeyCode == Keys.F11 || (e.Control && e.KeyCode == Keys.F))
            {
                e.SuppressKeyPress = true;
                ToggleFullScreen();
            }

            if (e.KeyCode == Keys.Escape)
            {
                ToggleSettingsVisibility();
            }

            CheckCapsLock();
        }

        private void CheckCapsLock()
        {
            if (System.Windows.Forms.Control.IsKeyLocked(Keys.CapsLock))
                rtbCapsLock.Show();
            else
                rtbCapsLock.Hide();
        }
    }
}
