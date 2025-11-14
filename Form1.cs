using System;
using System.Drawing;
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

        private void Form1_Load(object sender, EventArgs e)
        {
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

            Restart();
            SetFirstWordColor();

            rtbWords.Show();
            pnlResults.Hide();
            pnlSettings.Hide();

            ChangeSomeControlColorsAccordingToFormBackColor();

            btn15.BackColor = SelectColor;
            btnTime.BackColor = SelectColor;

            rtbFinalWPM.SelectAll();
            rtbFinalWPM.SelectionAlignment = HorizontalAlignment.Center;

            cbWhichWords.SelectedIndex = 0;

            CurrentBtn = btn15;
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

            if (Control.IsKeyLocked(Keys.CapsLock))
                rtbCapsLock.Show();
            else
                rtbCapsLock.Hide();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (IsSettingsOpen) return;
            else
            {
                ShowTypingTestScreen();
            }

            Restart();
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

        Button CurrentBtn;

        private void btnTime_Click(object sender, EventArgs e)
        {
            if (CurrentTest.Mode == enMode.Time) return;

            CurrentTest.Mode = enMode.Time;

            btnTime.BackColor = SelectColor;
            btnWords.BackColor = Color.White;

            tbTimer.Show();
            tbWordsCounter.Hide();

            NumberOfWords = 1000;
            CurrentWords = new string[NumberOfWords];

            Restart();
            
            BringToFrontTimeButtons();

            CurrentBtn = btn15;
            ChangeNumberOfSeconds(CurrentBtn);
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            if (CurrentTest.Mode == enMode.Words) return;

            CurrentTest.Mode = enMode.Words;

            btnWords.BackColor = SelectColor;
            btnTime.BackColor = Color.White;

            tbTimer.Hide();
            tbWordsCounter.Show();

            Restart();

            BringToFrontWordButtons();

            CurrentBtn = btn10;
            ChangeNumberOfWords(CurrentBtn);
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
    }
}
