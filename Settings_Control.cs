using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml.Presentation;
using Control = System.Windows.Forms.Control;
using static Typing_Test.AppSettings;

namespace Typing_Test
{
    public partial class Form1
    {
        System.Windows.Forms.Button CurrentBtn;

        AppSettings settings;

        private void LoadFirstTime()
        {
            settings = new AppSettings();

            CurrentBtn = btn15;

            if (!File.Exists(Global.LocalAppDataDbPath))
            {
                File.Copy(Global.Clean_DB_Path, Global.LocalAppDataDbPath);
            }

            Languages.GetAllLanguageNames().ForEach(L => cbLanguage.Items.Add(L));

            if (!File.Exists(Global.JsonSettingsPath))
            {
                settings = new AppSettings();
                using (File.Create(Global.JsonSettingsPath)) { };
                AppSettings.SaveToFile(settings);
            }

            LoadSettings(settings);

            tbType.Select();

            ShowTypingTestScreen();

            SetFirstWordColor();

            ChangeSomeColorsAccordingToFormBackColor();

            btn15.BackColor = color(settings.SelectColor);
            btnTime.BackColor = color(settings.SelectColor);

            CustomizeToolTip();

            InitializeKeyboardDictionary();

            CheckCapsLock();
        }

        private void PerformBtnTimeClick()
        {
            if (Test.IsTimeMode()) return;

            Test.Mode = enMode.Time15;

            btnTime.BackColor = color(settings.SelectColor);
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

            btnWords.BackColor = color(settings.SelectColor);
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
            string jsonString = Clipboard.GetText();

            try
            {
                settings = AppSettings.Deserialize(jsonString);

                AppSettings.SaveToFile(settings);

                LoadSettings(settings);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ExportSettingsFromClipBoard()
        {
            UpdateSettingsObject(settings);

            string jsonString = Serialize(settings);

            Clipboard.SetText(jsonString);
        }

        private void lbChangeFormBackColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = this.BackColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cdChangeColor.Color;
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
            }
        }

        private void lbChangertbWordsForeColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = rtbWords.ForeColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                rtbWords.ForeColor = cdChangeColor.Color;
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
                SetFirstWordColor();
            }
        }

        private void lbChangeCurrentWordColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = color(settings.CurrentWordColor);
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                settings.CurrentWordColor = color(cdChangeColor.Color);
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
                SetFirstWordColor();
            }
        }

        private void lbChangeCorrectWordColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = color(settings.CorrectWordColor);
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                settings.CorrectWordColor = color(cdChangeColor.Color);
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
            }
        }

        private void lbChangeWrongWordColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = color(settings.WrongWordColor);
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                settings.WrongWordColor = color(cdChangeColor.Color);
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
            }
        }

        private void lbChangetbTypeForeColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = tbType.ForeColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                tbType.ForeColor = cdChangeColor.Color;
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
            }
        }

        private void lbChangeCountersColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = tbLiveWPM.ForeColor;
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                ChangeCountersForeColor(cdChangeColor.Color);
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);
            }
        }

        private void lbChangeSelectColor_Click(object sender, EventArgs e)
        {
            cdChangeColor.Color = color(settings.SelectColor);
            if (cdChangeColor.ShowDialog() == DialogResult.OK)
            {
                settings.SelectColor = color(cdChangeColor.Color);
                UpdateSettingsObject(settings);
                AppSettings.SaveToFile(settings);

                CurrentBtn.BackColor = color(settings.SelectColor);

                if (Test.IsTimeMode()) 
                    btnTime.BackColor = color(settings.SelectColor);
                else
                    btnWords.BackColor = color(settings.SelectColor);
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
