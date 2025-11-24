using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.CustomUI;

namespace Typing_Test
{
    public partial class Form1
    {
        System.Windows.Forms.Button CurrentBtn;

        private void PerformBtnTimeClick()
        {
            if ( CurrentTest.Mode.ToString().Contains("Time") ) return;

            CurrentTest.Mode = enMode.Time15;

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
            if (CurrentTest.Mode.ToString().Contains("Words")) return;

            CurrentTest.Mode = enMode.Words10;

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

        private void lbExportResultsToExcel_Click(object sender, EventArgs e)
        {
            sfdExportResultsToExcel.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            sfdExportResultsToExcel.FileName = "Typing_Results.xlsx";

            if (sfdExportResultsToExcel.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                Result.ExportTypingTestsToExcel(sfdExportResultsToExcel.FileName);
                Cursor = Cursors.Default;
                MessageBox.Show("Results exported to Excel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                tbLiveWPM.ForeColor = cdChangeColor.Color;
                tbWordsCounter.ForeColor = cdChangeColor.Color;
                tbTimer.ForeColor = cdChangeColor.Color;
                rtbFinalWPM.ForeColor = cdChangeColor.Color;
                rtbWPMWord.ForeColor = cdChangeColor.Color;
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

                if ( CurrentTest.Mode.ToString().Contains("Time") ) 
                {
                    btnTime.BackColor = SelectColor;
                }
                else
                {
                    btnWords.BackColor = SelectColor;
                }
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
