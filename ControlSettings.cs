using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1
    {
        Settings settings = new Settings();

        string jsonString { get; set; }

        string jsonSettingsPath = Directory.GetCurrentDirectory() + "\\Settings.json";

        public bool IsSettingsOpen = false;

        Color CurrentWordColor;
        Color CorrectWordColor;
        Color WrongWordColor;
        Color SelectColor;

        private void LoadDefaultSettings()
        {
            this.BackColor = Color.FromArgb(1, 3, 25);
            rtbWords.ForeColor = Color.FromArgb(60, 77, 120);
            CurrentWordColor = Color.DodgerBlue;
            CorrectWordColor = Color.Green;
            WrongWordColor = Color.Red;
            SelectColor = Color.DodgerBlue;
            tbType.ForeColor = Color.White;

            tbTimer.ForeColor = Color.DeepPink;
            tbLiveWPM.ForeColor = Color.DeepPink;
            tbWordsCounter.ForeColor = Color.DeepPink;
            rtbWPMWord.ForeColor = Color.DeepPink;
            rtbFinalWPM.ForeColor = Color.DeepPink;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void LoadColorsSettings()
        {
            this.BackColor = ColorTranslator.FromHtml(settings.FormBackColor);
            rtbWords.ForeColor = ColorTranslator.FromHtml(settings.FontColor);
            CurrentWordColor = ColorTranslator.FromHtml(settings.CurrentWordColor);
            CorrectWordColor = ColorTranslator.FromHtml(settings.CorrectWordColor);
            WrongWordColor = ColorTranslator.FromHtml(settings.WrongWordColor);
            SelectColor = ColorTranslator.FromHtml(settings.SelectColor);
            tbType.ForeColor = ColorTranslator.FromHtml(settings.TypeBarColor);

            tbTimer.ForeColor = ColorTranslator.FromHtml(settings.CountersColor);
            tbLiveWPM.ForeColor = ColorTranslator.FromHtml(settings.CountersColor);
            tbWordsCounter.ForeColor = ColorTranslator.FromHtml(settings.CountersColor);
            rtbWPMWord.ForeColor = ColorTranslator.FromHtml(settings.CountersColor);
            rtbFinalWPM.ForeColor = ColorTranslator.FromHtml(settings.CountersColor);
        }

        private void LoadWindowStateSettings()
        {
            if (settings.WindowState == "Maximized")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (settings.WindowState == "Minimized")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else // Normal
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void LoadFormBorderStyleSettings()
        {
            if (settings.FormBorderStyle == "Fixed3D")
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            else if (settings.FormBorderStyle == "None")
            {
                this.WindowState = FormWindowState.Normal; // If this line be removed, there would be a glitch.
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                rtbWords.ZoomFactor += 0.25f;
            }
        }

        private void Deserialize()
        {
            settings = JsonSerializer.Deserialize<Settings>(jsonString);
        }

        private void LoadFromFile()
        {
            jsonString = File.ReadAllText("Settings.json");
        }

        private void LoadSettings()
        {
            LoadFromFile();

            Deserialize();

            LoadColorsSettings();

            LoadWindowStateSettings();

            LoadFormBorderStyleSettings();
        }

        private void UpdateSettingsObject()
        {
            settings.FormBackColor = ColorTranslator.ToHtml(this.BackColor);
            settings.FontColor = ColorTranslator.ToHtml(rtbWords.ForeColor);
            settings.CurrentWordColor = ColorTranslator.ToHtml(CurrentWordColor);
            settings.CorrectWordColor = ColorTranslator.ToHtml(CorrectWordColor);
            settings.WrongWordColor = ColorTranslator.ToHtml(WrongWordColor);
            settings.SelectColor = ColorTranslator.ToHtml(SelectColor);
            settings.TypeBarColor = ColorTranslator.ToHtml(tbType.ForeColor);
            settings.CountersColor = ColorTranslator.ToHtml(tbTimer.ForeColor);

            settings.WindowState = this.WindowState.ToString(); // Normal, Maximized, Minimized
            settings.FormBorderStyle = this.FormBorderStyle.ToString(); // None, Fixed3D
        }

        private void ResetDefaultSettings()
        {
            LoadDefaultSettings();
            File.Delete(jsonSettingsPath);
            SaveSettings();
            MessageBox.Show("Settings have been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveToFile()
        {
            File.WriteAllText(jsonSettingsPath, jsonString);
        }

        private void Serialize()
        {
            jsonString = JsonSerializer.Serialize<Settings>(settings);
        }

        private void SaveSettings()
        {
            UpdateSettingsObject();

            Serialize();

            SaveToFile();
        }

        private void ToggleSettingsVisibility()
        {
            Restart();

            if (!IsSettingsOpen)
            {
                pnlSettings.BringToFront();
                IsSettingsOpen = true;
                tbType.ReadOnly = true;
            }
            else
            {
                pnlSettings.SendToBack();
                IsSettingsOpen = false;
                tbType.ReadOnly = false;
            }
        }

        private void lbExportSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Clipboard.SetText(jsonString);

            MessageBox.Show("Settings Copied To Clipboard Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbImportSettings_Click(object sender, EventArgs e)
        {
            jsonString = Clipboard.GetText();

            try
            {
                SaveToFile();

                LoadSettings();

                MessageBox.Show("Settings Loaded Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error while Importing Settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbChangeFormBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void lbChangertbWordsForeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = rtbWords.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbWords.ForeColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void lbChangeCurrentWordColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = CurrentWordColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentWordColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void lbChangeCorrectWordColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = CorrectWordColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CorrectWordColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void lbChangeWrongWordColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = WrongWordColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                WrongWordColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void lbChangetbTypeForeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tbType.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tbType.ForeColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void lbChangeCountersColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = tbLiveWPM.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tbLiveWPM.ForeColor = colorDialog1.Color;
                tbWordsCounter.ForeColor = colorDialog1.Color;
                tbTimer.ForeColor = colorDialog1.Color;
                rtbFinalWPM.ForeColor = colorDialog1.Color;
                rtbWPMWord.ForeColor = colorDialog1.Color;
                SaveSettings();
            }
        }


        private void lbChangeSelectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = SelectColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectColor = colorDialog1.Color;
                SaveSettings();
            }
        }

        private void ChangeSomeControlColorsAccordingToFormBackColor()
        {
            tbLiveWPM.BackColor = this.BackColor;
            tbTimer.BackColor = this.BackColor;
            tbWordsCounter.BackColor = this.BackColor;
            rtbWords.BackColor = this.BackColor;
            rtbFinalWPM.BackColor = this.BackColor;
            rtbWPMWord.BackColor = this.BackColor;
            //richTextBox2.BackColor = this.BackColor;
            tbType.BackColor = this.BackColor;
        }

        private void ToggleFullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.Fixed3D)
            {
                this.WindowState = FormWindowState.Normal; // If this line be removed, there would be a glitch.
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                rtbWords.ZoomFactor += 0.25f;
                return;
            }

            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                rtbWords.ZoomFactor -= 0.25f;
                return;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                rtbWords.ZoomFactor = 2f;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                rtbWords.ZoomFactor = 1.45f;
            }
        }
    }
}
