using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            LoadFirstTime();
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
            if (KeyboardDictionary.TryGetValue(e.KeyCode, out var label))
            {
                HighLightCharacter(label);
            }


            if (e.Control && e.KeyCode == Keys.Back)
            {
                PerformCtrlBackSpace(e);
            }
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            ChangeSomeColorsAccordingToFormBackColor();
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
            UpdateSettingsObject(settings);
            AppSettings.SaveToFile(settings);
        }
        private void lbImportSettings_Click(object sender, EventArgs e)
        {
            if (ImportSettingsFromClipBoard())
            {
                MessageBox.Show("Settings Loaded Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error while Importing Settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbExportSettings_Click(object sender, EventArgs e)
        {
            ExportSettingsFromClipBoard();

            MessageBox.Show("Settings Copied To Clipboard Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbResetDefaultSettings_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to reset settings to default?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                settings = new AppSettings();
                AppSettings.SaveToFile(settings);
                LoadSettings(settings);
                MessageBox.Show("Settings have been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateTestTimer();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test.Language = cbLanguage.SelectedItem.ToString();
            ChangeCurrentLanguage(Test.Language);
        }

        private void lbClearResults_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to clear results?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Test.ClearTypingTestsResultsTable();
                dgvResults.DataSource = null;
                MessageBox.Show("Results Are Clear Now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbExportResultsToExcel_Click(object sender, EventArgs e)
        {
            sfdExportResultsToExcel.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            sfdExportResultsToExcel.FileName = "Typing_Results.xlsx";

            if (sfdExportResultsToExcel.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                Test.ExportTypingTestsToExcel(sfdExportResultsToExcel.FileName);
                Cursor = Cursors.Default;
                MessageBox.Show("Results exported to Excel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbShowResults_Click(object sender, EventArgs e)
        {
            PerformShowResultsButton();
        }

        private void lbHideResults_Click(object sender, EventArgs e)
        {
            HideTestsScreen();

            dgvResults.DataSource = null;
        }

        private void rtbWords_VisibleChanged(object sender, EventArgs e)
        {
            pnlKeyboard.Visible = rtbWords.Visible;
        }

    }
}
