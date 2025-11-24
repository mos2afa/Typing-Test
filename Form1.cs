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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            PerformKeyDown(e);
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
            if(MessageBox.Show("Are you sure you want to reset settings to default?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetDefaultSettings();
                MessageBox.Show("Settings have been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateTestTimer();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedLanguage = cbLanguage.SelectedItem.ToString();
            ChangeCurrentLanguage(SelectedLanguage);
        }

        private void lbClearResults_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to clear results?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Result.ClearTypingTestsResultsTable();
                MessageBox.Show("Results Are Clear Now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
