using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadForm()
        {
            foreach (string Language in Languages.GetAllLanguageNames())
            {
                cbLanguage.Items.Add(Language);
            }

            if (!File.Exists(jsonSettingsPath))
            {
                LoadDefaultSettings();
                using (File.Create(jsonSettingsPath)) { };
                Serialize();
                SaveToFile();
            }
            else
            {
                LoadSettings();
            }

            tbType.Select();

            ShowTypingTestScreen();

            Restart();
            SetFirstWordColor();

            ChangeSomeControlColorsAccordingToFormBackColor();

            btn15.BackColor = SelectColor;
            btnTime.BackColor = SelectColor;

            rtbFinalWPM.SelectAll();
            rtbFinalWPM.SelectionAlignment = HorizontalAlignment.Center;

            CurrentBtn = btn15;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
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

            if (System.Windows.Forms.Control.IsKeyLocked(Keys.CapsLock))
                rtbCapsLock.Show();
            else
                rtbCapsLock.Hide();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            PerformBtnRestartClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbTypeTextChanged();
        }

        private void btnChangeNumberOfWords_Click(object sender, EventArgs e)
        {
            ChangeNumberOfWords((Button)sender);
        }

        private void btnChangeNumberOfSeconds_Click(object sender, EventArgs e)
        {
            ChangeNumberOfSeconds((Button)sender);
        }

        private void BringToFrontWordButtons()
        {
            btn10.BringToFront();
            btn25.BringToFront();
            btn50.BringToFront();
            btn100.BringToFront();
        }

        private void BringToFrontTimeButtons()
        {
            btn15.BringToFront();
            btn30.BringToFront();
            btn60.BringToFront();
            btn120.BringToFront();
        }


        private void btnTime_Click(object sender, EventArgs e)
        {
            PerformBtnTimeClick();
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            PerformBtnWordsClick();
        }

        private void tbType_KeyDown(object sender, KeyEventArgs e)
        {
            PerformCtrlBackSpace(e);
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            ChangeSomeControlColorsAccordingToFormBackColor();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ToggleSettingsVisibility();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void lbResetDefaultSettings_Click(object sender, EventArgs e)
        {
            ResetDefaultSettings();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedLanguage = cbLanguage.SelectedItem.ToString();
            ChangeCurrentLanguage(SelectedLanguage);
        }
    }
}
