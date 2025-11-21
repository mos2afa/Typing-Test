using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Typing_Test
{
    public partial class Form1
    {
        Typing_Test.Test CurrentTest = new Typing_Test.Test();

        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] AllLanguageWords;

        string[] CurrentWords = new string[NumberOfWords];

        Random rndWord = new Random();

        public bool IsTestCompleted = false;

        private void LoadForm()
        {
            CurrentBtn = btn15;

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

            SetFirstWordColor();

            ChangeSomeControlColorsAccordingToFormBackColor();

            btn15.BackColor = SelectColor;
            btnTime.BackColor = SelectColor;

            rtbFinalWPM.SelectAll();
            rtbFinalWPM.SelectionAlignment = HorizontalAlignment.Center;

            CustomizeToolTip();

            CheckCapsLock();
        }

        private bool IsCurrentWordTypedTrue()
        {
            return tbType.Text == CurrentWords[CurrentTest.CurrentWordCounter];
        }

        private void FillWords()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < NumberOfWords; i++)
            {
                int RandomNumber = rndWord.Next(0, AllLanguageWords.Length);

                CurrentWords[i] = AllLanguageWords[RandomNumber];
                sb.Append(CurrentWords[i]);
                sb.Append(" ");
            }

            sb.Append("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            rtbWords.Text = sb.ToString();
        }

        private void RestartWords()
        {
            rtbWords.SelectAll();
            rtbWords.SelectionColor = DefaultBackColor;

            FillWords();

            tbType.Text = "";
            tbType.Focus();

            CurrentTest.CurrentWordCounter = 0;
            CurrentTest.CorrectWords = 0;
            CurrentTest.WrongWords = 0;
            CurrentTest.CorrectStrokes = 0;
            CurrentTest.WrongStrokes = 0;

            SetFirstWordColor();

            rtbWords.Select(0, 1);
            rtbWords.ScrollToCaret();
        }

        private void SetFirstWordColor()
        {
            IndexOfFirstCharOfCurrentWord = 0;
            rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[0].Length);
            rtbWords.SelectionColor = CurrentWordColor;
        }

        private void Restart()
        {
            if (pnlSettings.Visible) return;

            RestartWords();
            ResetTimer();

            tbType.ReadOnly = false;
        }

        private bool AreAllWordsTyped()
        {
            IsTestCompleted = (CurrentTest.CurrentWordCounter >= NumberOfWords);
            return IsTestCompleted;
        }

        private bool IsWordTypingFinished()
        {
            return tbType.Text.EndsWith(" ");
        }

        private void CheckEachCharInCurrentWord()
        {
            if (CurrentTest.CurrentWordCounter >= NumberOfWords) return;

            for (int i = 0; (i < CurrentWords[CurrentTest.CurrentWordCounter].Length) && (i < tbType.Text.Length); i++)
            {
                if (tbType.Text[i] == CurrentWords[CurrentTest.CurrentWordCounter][i] && tbType.Text.Length <= CurrentWords[CurrentTest.CurrentWordCounter].Length)
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentTest.CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = rtbWords.BackColor;
                }
                else
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentTest.CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = WrongWordColor;
                    break;
                }
            }
        }

        private void DealWithCounters()
        {
            if (IsCurrentWordTypedTrue())
            {
                CurrentTest.CorrectWords++;

                CurrentTest.CorrectStrokes += CurrentWords[CurrentTest.CurrentWordCounter].Length + 1;
            }
            else
            {
                CurrentTest.WrongWords++;

                CurrentTest.WrongStrokes += CurrentWords[CurrentTest.CurrentWordCounter].Length;
            }
        }

        private void tbTypeTextChanged()
        {
            if (tbType.Text.Trim() == "")
            {
                rtbWords.SelectionBackColor = rtbWords.BackColor;
                tbType.Text = "";
                return;
            }

            tbWordsCounter.Text = CurrentTest.CurrentWordCounter.ToString() + $"/{NumberOfWords}";
            tbTimer.Text = stopwatch.Elapsed.ToString(@"mm\:ss");

            StartTimer();

            CheckEachCharInCurrentWord();

            if (IsWordTypingFinished())
            {
                tbType.Text = tbType.Text.Trim();

                DealWithCounters();

                SetPrevWordColor();

                rtbWords.SelectionBackColor = rtbWords.BackColor;

                UpdateIndexOfFirstCharOfCurrentWord();

                CurrentTest.CurrentWordCounter++;

                SetCurrentWordColor();

                rtbWords.ScrollToCaret();

                tbType.Text = "";

                if (AreAllWordsTyped())
                {
                    tbType.ReadOnly = true;
                    ShowResults();
                    ResetTimer();

                    tbLiveWPM.Text = "";
                }
            }
        }

        int IndexOfFirstCharOfCurrentWord = 0;

        private void SetPrevWordColor()
        {
            if (IsCurrentWordTypedTrue())
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentTest.CurrentWordCounter].Length);
                rtbWords.SelectionColor = CorrectWordColor;
            }
            else
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentTest.CurrentWordCounter].Length);
                rtbWords.SelectionColor = WrongWordColor;
            }
        }

        private void UpdateIndexOfFirstCharOfCurrentWord()
        {
            IndexOfFirstCharOfCurrentWord += 1 + CurrentWords[CurrentTest.CurrentWordCounter].Length;
        }

        private void SetCurrentWordColor()
        {
            if (CurrentTest.CurrentWordCounter < NumberOfWords)
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentTest.CurrentWordCounter].Length);
                rtbWords.SelectionColor = CurrentWordColor;
            }
        }

        private void StartTimer()
        {
            stopwatch.Start();
            tUpdateUI.Start();
        }

        private void ResetTimer()
        {
            stopwatch.Reset();
            tUpdateUI.Stop();

            tbTimer.Text = "";
            tbLiveWPM.Text = "";
            tbWordsCounter.Text = "";
        }

        private void SetKeyStrokesColors()
        {
            rtbKeyStrokes.Text = "(" + CurrentTest.CorrectStrokes + " | " + CurrentTest.WrongStrokes + ")  " + (CurrentTest.CorrectStrokes + CurrentTest.WrongStrokes);

            rtbKeyStrokes.Select(1, CurrentTest.CorrectStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Green;

            rtbKeyStrokes.Select(1 + CurrentTest.CorrectStrokes.ToString().Length + 3, CurrentTest.WrongStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Red;
        }

        Stopwatch stopwatch = new Stopwatch();

        private double CalcWPM()
        {
            double WPM = 0.0;

            double Words = CurrentTest.CorrectStrokes / 5.0;

            double TotalSeconds = (double)stopwatch.ElapsedMilliseconds / 1000;

            if(Words == 0 || TotalSeconds == 0)
            {
                CurrentTest.WPM = 0.00;
                return 0.0;
            }   

            WPM = Words / (TotalSeconds / 60.0);

            CurrentTest.WPM = Math.Round(WPM,2);
            return WPM;
        }

        private double CalcAccuracy()
        {
            if (CurrentTest.CurrentWordCounter == 0)
            {
                return 0.0;
            }
            else
            {
                return ((double)(CurrentTest.CorrectStrokes) / (CurrentTest.CorrectStrokes + CurrentTest.WrongStrokes)) * 100;
            }
        }


        private void ShowResultScreen()
        {
            pnlResults.Show();
            rtbWords.Hide();
            pnlSettings.Hide();
        }

        private void ShowTypingTestScreen()
        {
            rtbWords.Show();
            pnlResults.Hide();
            pnlSettings.Hide();
        }

        private void ShowSettingsScreen()
        {
            pnlSettings.Show();
            pnlResults.Hide();
            rtbWords.Hide();
        }

        double Diff_WPM = -1;

        private void ShowResults()
        {
            ShowResultScreen();

            rtbCorrectWords.Text = CurrentTest.CorrectWords.ToString();
            rtbWrongWords.Text = CurrentTest.WrongWords.ToString();

            CurrentTest.Language = cbLanguage.SelectedItem.ToString();

            CurrentTest.TestDate = DateTime.Now;

            CurrentTest.Accuracy = Math.Round(CalcAccuracy(),2);
            rtbAccuracy.Text = CurrentTest.Accuracy.ToString("F0") + "%";

            rtbFinalWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

            CurrentTest.DurationSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds,2);
            rtbDuration.Text = CurrentTest.DurationSeconds.ToString("F2") +" s";

            Diff_WPM = CurrentTest.WPM - Test.GetMaxWPM(CurrentTest.Language,CurrentTest.Mode);

            if (Diff_WPM >0)
                pbBest.Show();
            else
                pbBest.Hide();

            SetKeyStrokesColors();

            Test.AddResult(CurrentTest);
        }

        private void CanType()
        {
            tbType.ReadOnly = !rtbWords.Visible;
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            CurrentTest.Mode = (enMode)int.Parse(btn.Text);

            ResetTimer();

            RestartWords();

            IsTestCompleted = false;

            NumberOfSeconds = Convert.ToInt16(btn.Text);

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Black;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Black;

            CurrentBtn = btn;
            CurrentBtn.BackColor = SelectColor;

            ShowTypingTestScreen();

            CanType();
        }

        private void ChangeNumberOfWords(Button btn)
        {
            CurrentTest.Mode = (enMode)int.Parse(btn.Text);

            ResetTimer();

            NumberOfWords = Convert.ToInt16(btn.Text);
            CurrentWords = new string[NumberOfWords];
            RestartWords();

            IsTestCompleted = false;

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Black;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Black;

            CurrentBtn = btn;
            CurrentBtn.BackColor = SelectColor;

            ShowTypingTestScreen();

            CanType();
        }

        private void UpdateTestTimer()
        {
            tbLiveWPM.Text = Math.Round(CalcWPM()).ToString();

            tbTimer.Text = stopwatch.Elapsed.ToString(@"mm\:ss");

            if (stopwatch.Elapsed.Seconds >= NumberOfSeconds || AreAllWordsTyped())
            {
                IsTestCompleted = true;
                tbType.ReadOnly = true;
                ShowResults();
                ResetTimer();
            }
        }

        private void PerformCtrlBackSpace(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true; // Prevent the default Backspace behavior (inserting space)

                tbType.Text = "";
            }
        }
    }
}
