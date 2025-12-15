using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1
    {
        AppSettings settings = new AppSettings();

        string jsonString { get; set; }

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
            CurrentBtn.BackColor = SelectColor;

            if(Test.IsTimeMode())
                btnTime.BackColor = SelectColor;
            else
                btnWords.BackColor = SelectColor;
            

            tbTimer.ForeColor = Color.DeepPink;
            tbLiveWPM.ForeColor = Color.DeepPink;
            tbWordsCounter.ForeColor = Color.DeepPink;
            rtbWPMWord.ForeColor = Color.DeepPink;
            rtbFinalWPM.ForeColor = Color.DeepPink;
            rtbAccuracy.ForeColor = Color.DeepPink;
            rtbAccuracyWord.ForeColor = Color.DeepPink;
            rtbTimeWord.ForeColor = Color.DeepPink;
            rtbDuration.ForeColor = Color.DeepPink;
            rtbWordsCounter.ForeColor = Color.DeepPink;
            rtbWordsWord.ForeColor = Color.DeepPink;
            rtbTestType.ForeColor = Color.DeepPink;
            rtbTestTypeWord.ForeColor = Color.DeepPink;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            cbLanguage.SelectedItem = "English";
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

            ChangeCountersColors(ColorTranslator.FromHtml(settings.CountersColor));   
        }

        private void ChangeCountersColors(Color TargetColor)
        {
            tbTimer.ForeColor = TargetColor;
            tbLiveWPM.ForeColor = TargetColor;
            tbWordsCounter.ForeColor = TargetColor;
            rtbFinalWPM.ForeColor = TargetColor;
            rtbWPMWord.ForeColor = TargetColor;
            rtbAccuracy.ForeColor = TargetColor;
            rtbAccuracyWord.ForeColor = TargetColor;
            rtbDuration.ForeColor = TargetColor;
            rtbTimeWord.ForeColor = TargetColor;
            rtbCharacters.ForeColor = TargetColor;
            rtbCharactersWord.ForeColor = TargetColor;
            rtbWordsCounter.ForeColor = TargetColor;
            rtbWordsWord.ForeColor = TargetColor;
            rtbCharacters.ForeColor = TargetColor;
            rtbCharactersWord.ForeColor = TargetColor;
            rtbTestType.ForeColor = TargetColor;
            rtbTestTypeWord.ForeColor = TargetColor;
        }

        private void LoadWindowStateSettings()
        {
            this.WindowState = settings.WindowState;
        }

        private void LoadFormBorderStyleSettings()
        {
            if (settings.FormBorderStyle == FormBorderStyle.Fixed3D)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            else if (settings.FormBorderStyle == FormBorderStyle.None)
            {
                this.WindowState = FormWindowState.Normal; // If this line be removed, there would be a glitch.
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                rtbWords.ZoomFactor += 0.25f;
            }
        }

        private void Deserialize()
        {
            settings = JsonSerializer.Deserialize<AppSettings>(jsonString);
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

            CurrentBtn.BackColor = SelectColor;

            if(Test.IsTimeMode())
                btnTime.BackColor = SelectColor;
            else
                btnWords.BackColor = SelectColor;
            

            LoadWindowStateSettings();

            LoadFormBorderStyleSettings();

            cbLanguage.SelectedItem = settings.SelectedLanguage;
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

            settings.WindowState = this.WindowState; // Normal, Maximized, Minimized
            settings.FormBorderStyle = this.FormBorderStyle; // None, Fixed3D

            settings.SelectedLanguage = cbLanguage.SelectedItem.ToString();
        }

        private void ResetDefaultSettings()
        {
            LoadDefaultSettings();
            File.Delete(Global.JsonSettingsPath);
            SaveSettings();
        }

        private void SaveToFile()
        {
            File.WriteAllText(Global.JsonSettingsPath, jsonString);
        }

        private void Serialize()
        {
            jsonString = JsonSerializer.Serialize<AppSettings>(settings);
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

            if (!pnlSettings.Visible) // to open
            {
                ShowSettingsScreen();
            }
            else// to close
            {
                if(IsTestCompleted)
                {
                    ShowResultScreen();
                }
                else
                {
                    ShowTypingTestScreen();
                }

                HideTestsScreen();
                dgvResults.Hide();
            }

            CanType();
        }

        private void ChangeSomeColorsAccordingToFormBackColor()
        {
            tbLiveWPM.BackColor = this.BackColor;
            tbTimer.BackColor = this.BackColor;
            tbWordsCounter.BackColor = this.BackColor;
            rtbWords.BackColor = this.BackColor;
            rtbFinalWPM.BackColor = this.BackColor;
            rtbWPMWord.BackColor = this.BackColor;
            rtbAccuracy.BackColor = this.BackColor;
            rtbAccuracyWord.BackColor = this.BackColor;
            rtbDuration.BackColor = this.BackColor;
            rtbCharacters.BackColor = this.BackColor;
            rtbCharactersWord.BackColor = this.BackColor;
            rtbWordsCounter.BackColor = this.BackColor;
            rtbWordsWord.BackColor = this.BackColor;
            rtbTimeWord.BackColor = this.BackColor;
            rtbTestType.BackColor = this.BackColor;
            rtbTestTypeWord.BackColor = this.BackColor;
            tbType.BackColor = this.BackColor;
            cbLanguage.BackColor = this.BackColor;
            btnRestart.BackColor = this.BackColor;
        }

        private void ToggleFullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.Fixed3D)
            {
                this.WindowState = FormWindowState.Normal; // If this line be removed, there would be a glitch.
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                rtbWords.ZoomFactor += 0.25f;
            }
            else if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                rtbWords.ZoomFactor -= 0.25f;
            }

            HideTestsScreen();
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

            HideTestsScreen();
        }

        private void PerformShowResultsButton()
        {
            dgvResults.RowTemplate.Height = 40;

            dgvResults.GridColor = Color.LightGray;

            dgvResults.DataSource = Test.GetTypingTestsForShowing();

            dgvResults.Columns[0].Width = 100;
            dgvResults.Columns[1].Width = 120;
            dgvResults.Columns[2].Width = 130;
            dgvResults.Columns[3].Width = 120;
            dgvResults.Columns[4].Width = 120;
            dgvResults.Columns[5].Width = 100;
            dgvResults.Columns[6].Width = 120;
            dgvResults.Columns[7].Width = 250;

            dgvResults.GridColor = BackColor;
            dgvResults.ForeColor = SelectColor;
            dgvResults.BackgroundColor = BackColor;
            dgvResults.DefaultCellStyle.BackColor = BackColor;

            dgvResults.EnableHeadersVisualStyles = false;

            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = BackColor;
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = CurrentWordColor;

            dgvResults.RowHeadersDefaultCellStyle.BackColor = BackColor;
            dgvResults.RowHeadersDefaultCellStyle.ForeColor = SelectColor;

            dgvResults.Size = pnlSettings.Size;
            dgvResults.Location = new Point(0, 0);
            dgvResults.Font = new Font(this.Font.FontFamily, 18);

            ShowTestsScreen();
        }



        private void PerformMouseDown(object sender, MouseEventArgs e)
        {
            e = null;
            this.ActiveControl = tbType;
        }

        ToolTip toolTip = new ToolTip();

        private void CustomizeToolTip()
        {
            toolTip.BackColor = Color.Black;
            toolTip.ForeColor = Color.White;

            // Enable custom drawing
            toolTip.OwnerDraw = true;

            toolTip.Draw += (s, m) =>
            {
                using (Font f = new Font("Segoe UI", 16, FontStyle.Bold)) // larger font
                {
                    m.Graphics.FillRectangle(new SolidBrush(toolTip.BackColor), m.Bounds);
                    m.Graphics.DrawString(m.ToolTipText, f, new SolidBrush(toolTip.ForeColor), m.Bounds);
                }
            };

            toolTip.Popup += (s, m) =>
            {
                using (Font f = new Font("Segoe UI", 16, FontStyle.Bold))
                {
                    Size size = TextRenderer.MeasureText(toolTip.GetToolTip(m.AssociatedControl), f);
                    m.ToolTipSize = new Size(size.Width + 10, size.Height + 10);
                }
            };
        }

        private void rtbFinalWPM_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                Test.WPM.ToString("F2") + " WPM",
                rtbFinalWPM,
                0,
                0
            );
        }

        private void rtbFinalWPM_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(rtbFinalWPM);
        }

        private void pbBest_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                "+" + Diff_WPM.ToString("F2"),
                pbBest,
                0,
                -30
            );
        }

        private void pbBest_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(pbBest);
        }

        private void rtbDuration_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                Test.DurationSeconds.ToString("F2") + "s",
                rtbDuration,
                0,
                -20
            );
        }

        private void rtbDuration_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(rtbDuration);
        }

        private void rtbAccuracy_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                Test.Accuracy.ToString("F2") + "%",
                rtbAccuracy,
                0 ,
                0
            );
        }
        private void rtbAccuracy_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(rtbAccuracy);
        }


        private void rtbCharacters_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                "correct\nincorrect",
                rtbCharacters,
                0,
                -50
            );
        }

        private void rtbCharacters_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(rtbCharacters);
        }

        private void rtbWordsCounter_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                "correct\nincorrect",
                rtbWordsCounter,
                0,
                -50
            );
        }

        private void rtbWordsCounter_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(rtbWordsCounter);
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

        private void ShowTestsScreen()
        {
            lbHideResults.Show();
            lbExportResultsToExcel.Show();
            lbClearResults.Show();

            dgvResults.Show();
        }

        private void HideTestsScreen()
        {
            lbHideResults.Hide();
            lbExportResultsToExcel.Hide();
            lbClearResults.Hide();

            dgvResults.Hide();
        }

    }
}
