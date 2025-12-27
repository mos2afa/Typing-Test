using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Forms;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using System.Linq;
using static Typing_Test.AppSettings;
using System.Net.Configuration;

namespace Typing_Test
{
    public partial class Form1
    {
        private void LoadColorsSettings(AppSettings settings)
        {
            this.BackColor = color(settings.FormBackColor);
            rtbWords.ForeColor = color(settings.FontColor);
            tbType.ForeColor = color(settings.TypeBarColor);

            ChangeCountersForeColor(color(settings.CountersColor));   
        }

        private void ChangeCountersForeColor(Color TargetColor)
        {
            tbTimer.ForeColor = TargetColor;
            tbLiveWPM.ForeColor = TargetColor;
            tbWordsCounter.ForeColor = TargetColor;

            toolTip.ForeColor = TargetColor;

            pnlResults.Controls.OfType<RichTextBox>().ToList().ForEach(lbl => lbl.ForeColor = TargetColor);

            pbBest.BackColor = TargetColor;
        }

        private void ChangeCountersBackColor(Color TargetColor)
        {
            tbTimer.BackColor = TargetColor;
            tbLiveWPM.BackColor = TargetColor;
            tbWordsCounter.BackColor = TargetColor;

            toolTip.BackColor = TargetColor;

            pnlResults.Controls.OfType<RichTextBox>().ToList().ForEach(lbl => lbl.BackColor = TargetColor);
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

        private void LoadSettings(AppSettings settings)
        {
            settings = AppSettings.LoadFromFile();

            LoadColorsSettings(settings);

            CurrentBtn.BackColor = color(settings.SelectColor);

            if(Test.IsTimeMode())
                btnTime.BackColor = color(settings.SelectColor);
            else
                btnWords.BackColor = color(settings.SelectColor);
            

            LoadWindowStateSettings();

            LoadFormBorderStyleSettings();

            cbLanguage.SelectedItem = settings.SelectedLanguage;
        }

        private void UpdateSettingsObject(AppSettings settings)
        {
            settings.FormBackColor = color(this.BackColor);
            settings.FontColor = color(rtbWords.ForeColor);
            settings.TypeBarColor = color(tbType.ForeColor);
            settings.CountersColor = color(tbTimer.ForeColor);

            settings.WindowState = this.WindowState; // Normal, Maximized, Minimized
            settings.FormBorderStyle = this.FormBorderStyle; // None, Fixed3D

            settings.SelectedLanguage = cbLanguage.SelectedItem.ToString();
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
            }

            CanType();
        }

        private void ChangeSomeColorsAccordingToFormBackColor()
        {
            ChangeCountersBackColor(this.BackColor);

            pnlKeyboard.Controls.OfType<Label>().ToList().ForEach(lbl => lbl.BackColor = this.BackColor);

            pnlKeyboard.BackColor = this.BackColor;
            rtbWords.BackColor = this.BackColor;
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

            dgvResults.Size = new Size(this.Width - 30, this.Height - tbType.Height - rtbCapsLock.Height - 50);
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

            pnlKeyboard.Location = new Point(Width/4+50, rtbWords.Height + 70);
            tbType.Location = new Point( pnlKeyboard.Location.X,tbType.Location.Y);
            btnRestart.Location = new Point(tbType.Location.X+tbType.Width+5 , btnRestart.Location.Y);

            dgvResults.Size = new Size(this.Width - 30, this.Height - tbType.Height - rtbCapsLock.Height - 50);
        }

        private void PerformShowResultsButton()
        {
            dgvResults.DataSource = Test.GetTypingTestsForShowing();

            dgvResults.GridColor = BackColor;
            dgvResults.ForeColor = color(settings.SelectColor);
            dgvResults.BackgroundColor = BackColor;
            dgvResults.DefaultCellStyle.BackColor = BackColor;

            dgvResults.EnableHeadersVisualStyles = false;

            dgvResults.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvResults.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = BackColor;
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = color(settings.CurrentWordColor);

            dgvResults.RowHeadersDefaultCellStyle.BackColor = BackColor;
            dgvResults.RowHeadersDefaultCellStyle.ForeColor = color(settings.SelectColor);

            dgvResults.RowHeadersVisible = false;

            dgvResults.RowsDefaultCellStyle.BackColor = BackColor;
            dgvResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(1,3,70);

            dgvResults.Font = new Font(this.Font.FontFamily, 18);
            dgvResults.Size = new Size(this.Width-30, this.Height - tbType.Height - rtbCapsLock.Height-50);

            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResults.RowTemplate.Height = 50;


            ShowTestsScreen();
            dgvResults.ClearSelection();
        }


        Dictionary<Keys, Label> KeyboardDictionary = new Dictionary<Keys, Label>();

        private void InitializeKeyboardDictionary()
        {
            KeyboardDictionary.Add(Keys.Space, lbSpace);

            KeyboardDictionary.Add(Keys.A, lbA);
            KeyboardDictionary.Add(Keys.B, lbB);
            KeyboardDictionary.Add(Keys.C, lbC);
            KeyboardDictionary.Add(Keys.D, lbD);
            KeyboardDictionary.Add(Keys.E, lbE);
            KeyboardDictionary.Add(Keys.F, lbF);
            KeyboardDictionary.Add(Keys.G, lbG);
            KeyboardDictionary.Add(Keys.H, lbH);
            KeyboardDictionary.Add(Keys.I, lbI);
            KeyboardDictionary.Add(Keys.J, lbJ);
            KeyboardDictionary.Add(Keys.K, lbK);
            KeyboardDictionary.Add(Keys.L, lbL);
            KeyboardDictionary.Add(Keys.M, lbM);
            KeyboardDictionary.Add(Keys.N, lbN);
            KeyboardDictionary.Add(Keys.O, lbO);
            KeyboardDictionary.Add(Keys.P, lbP);
            KeyboardDictionary.Add(Keys.Q, lbQ);
            KeyboardDictionary.Add(Keys.R, lbR);
            KeyboardDictionary.Add(Keys.S, lbS);
            KeyboardDictionary.Add(Keys.T, lbT);
            KeyboardDictionary.Add(Keys.U, lbU);
            KeyboardDictionary.Add(Keys.V, lbV);
            KeyboardDictionary.Add(Keys.W, lbW);
            KeyboardDictionary.Add(Keys.X, lbX);
            KeyboardDictionary.Add(Keys.Y, lbY);
            KeyboardDictionary.Add(Keys.Z, lbZ);

            KeyboardDictionary.Add(Keys.Oemcomma, lbComma);
            KeyboardDictionary.Add(Keys.OemPeriod, lbPeriod);
            KeyboardDictionary.Add(Keys.OemQuestion, lbSlash);

            KeyboardDictionary.Add(Keys.OemSemicolon, lbSemiColon);
            KeyboardDictionary.Add(Keys.OemQuotes, lbQuote);

            KeyboardDictionary.Add(Keys.OemOpenBrackets, lbOpenBracket);
            KeyboardDictionary.Add(Keys.OemCloseBrackets, lbCloseBracket);

        }

        public void HighLightCharacter(Label lbl)
        {
            lbl.BackColor = color(settings.CurrentWordColor);

            Timer t = new Timer();
            t.Interval = 100;
            t.Tick += (s, args) =>
            {
                lbl.BackColor = this.BackColor;

                t.Stop();
                t.Dispose();
            };

            t.Start();
        }

        private void PerformMouseDown(object sender, MouseEventArgs e)
        {
            e = null;
            this.ActiveControl = tbType;
        }

        ToolTip toolTip = new ToolTip();

        private void CustomizeToolTip()
        {
            toolTip.BackColor = this.BackColor;
            toolTip.ForeColor = color( settings.CountersColor );

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
                -30
            );
        }

        private void pbBest_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                "+" + Diff_WPM.ToString("F2"),
                pbBest,
                0,
                -40
            );
        }

        private void rtbDuration_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                Test.DurationSeconds.ToString("F2") + "s",
                rtbDuration,
                0,
                -30
            );
        }

        private void rtbAccuracy_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                Test.Accuracy.ToString("F2") + "%",
                rtbAccuracy,
                0 ,
                -30
            );
        }

        private void rtbCharacters_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                "correct\nincorrect",
                rtbCharacters,
                0,
                -70
            );
        }

        private void rtbWordsCounter_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show(
                "correct\nincorrect",
                rtbWordsCounter,
                0,
                -70
            );
        }

        private void Counters_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide((Control)sender);
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


        private void ShowResultScreen()
        {
            pnlResults.Show();
            rtbWords.Hide();
            pnlSettings.Hide();
            btnRestart.Show();
            tbType.Show();
        }

        private void ShowTypingTestScreen()
        {
            rtbWords.Show();
            pnlResults.Hide();
            pnlSettings.Hide();
            btnRestart.Show();
            tbType.Show();
        }

        private void ShowSettingsScreen()
        {
            pnlSettings.Show();
            pnlResults.Hide();
            rtbWords.Hide();
            btnRestart.Hide();
            tbType.Hide();
        }

    }
}
