using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1
    {
        Button CurrentBtn;

        private void PerformBtnTimeClick()
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

        private void PerformBtnWordsClick()
        {
            if (CurrentTest.Mode == enMode.Words) return;

            CurrentTest.Mode = enMode.Words;

            btnWords.BackColor = SelectColor;
            btnTime.BackColor = Color.White;

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
            if (pnlSettings.Visible) return;
            else
            {
                ShowTypingTestScreen();
            }

            Restart();
        }

        private void lbExportResultsToExcel_Click(object sender, EventArgs e)
        {
            sfdExportResultsToExcel.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            sfdExportResultsToExcel.FileName = "Typing_Results.xlsx";

            if (sfdExportResultsToExcel.ShowDialog() == DialogResult.OK)
            {
                Test.ExportTypingTestsToExcel(sfdExportResultsToExcel.FileName);
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
                SetFirstWordColor();
            }
        }

        private void lbChangeCurrentWordColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = CurrentWordColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentWordColor = colorDialog1.Color;
                SaveSettings();
                SetFirstWordColor();
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

                CurrentBtn.BackColor = SelectColor;

                if (CurrentTest.Mode == enMode.Time)
                {
                    btnTime.BackColor = SelectColor;
                }
                else
                {
                    btnWords.BackColor = SelectColor;
                }
            }
        }
    }
}
