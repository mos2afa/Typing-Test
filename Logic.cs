using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1
    {
        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] AllLanguageWords;

        string[] CurrentWords = new string[NumberOfWords];

        Random rndWord = new Random();

        public bool IsTestCompleted = false;

        

        private bool IsCurrentWordTypedTrue()
        {
            return tbType.Text == CurrentWords[Result.CurrentWordCounter];
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

            Result.CurrentWordCounter = 0;
            Result.CorrectWords = 0;
            Result.WrongWords = 0;
            Result.CorrectStrokes = 0;
            Result.WrongStrokes = 0;

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
            IsTestCompleted = (Result.CurrentWordCounter >= NumberOfWords);
            return IsTestCompleted;
        }

        private bool IsWordTypingFinished()
        {
            return tbType.Text.EndsWith(" ");
        }

        private void CheckEachCharInCurrentWord()
        {
            if (Result.CurrentWordCounter >= NumberOfWords) return;

            for (int i = 0; (i < CurrentWords[Result.CurrentWordCounter].Length) && (i < tbType.Text.Length); i++)
            {
                if (tbType.Text[i] == CurrentWords[Result.CurrentWordCounter][i] && tbType.Text.Length <= CurrentWords[Result.CurrentWordCounter].Length)
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Result.CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = rtbWords.BackColor;
                }
                else
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Result.CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = WrongWordColor;
                    break;
                }
            }
        }

        private void DealWithCounters()
        {
            if (IsCurrentWordTypedTrue())
            {
                Result.CorrectWords++;

                Result.CorrectStrokes += CurrentWords[Result.CurrentWordCounter].Length + 1;
            }
            else
            {
                Result.WrongWords++;

                Result.WrongStrokes += CurrentWords[Result.CurrentWordCounter].Length;
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

            tbWordsCounter.Text = $"{Result.CurrentWordCounter}/{NumberOfWords}";
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

                Result.CurrentWordCounter++;
                tbWordsCounter.Text =  $"{Result.CurrentWordCounter}/{NumberOfWords}";

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
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Result.CurrentWordCounter].Length);
                rtbWords.SelectionColor = CorrectWordColor;
            }
            else
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Result.CurrentWordCounter].Length);
                rtbWords.SelectionColor = WrongWordColor;
            }
        }

        private void UpdateIndexOfFirstCharOfCurrentWord()
        {
            IndexOfFirstCharOfCurrentWord += 1 + CurrentWords[Result.CurrentWordCounter].Length;
        }

        private void SetCurrentWordColor()
        {
            if (Result.CurrentWordCounter < NumberOfWords)
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Result.CurrentWordCounter].Length);
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

        

        private void ChangeCurrentLanguage(string Name)
        {
            string SelectedLanguage = Languages.GetLanguageWords(Name);
            AllLanguageWords = SelectedLanguage.Split(' ');
            RestartWords();
        }

        Stopwatch stopwatch = new Stopwatch();

        private double CalcWPM()
        {
            double WPM = 0.0;

            double Words = Result.CorrectStrokes / 5.0;

            double TotalSeconds = (double)stopwatch.ElapsedMilliseconds / 1000;

            if(Words == 0 || TotalSeconds == 0)
            {
                Result.WPM = 0.00;
                return 0.0;
            }   

            WPM = Words / (TotalSeconds / 60.0);

            Result.WPM = Math.Round(WPM,2);
            return WPM;
        }

        private double CalcAccuracy()
        {
            if (Result.CurrentWordCounter == 0)
            {
                return 0.0;
            }
            else
            {
                return ((double)(Result.CorrectStrokes) / (Result.CorrectStrokes + Result.WrongStrokes)) * 100;
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

            Result.Language = cbLanguage.SelectedItem.ToString();

            rtbTestType.Text = $"{Result.Mode}\n{Result.Language}";


            Result.Accuracy = Math.Round(CalcAccuracy(),2);
            rtbAccuracy.Text = Result.Accuracy.ToString("F0") + "%";

            rtbFinalWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

            Result.DurationSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds,2);
            rtbDuration.Text = Result.DurationSeconds.ToString("F0") +"s";

            Diff_WPM = Result.WPM - Result.GetMaxWPM(Result.Language,Result.Mode);

            rtbWordsCounter.Text = $"{Result .CorrectWords}/{Result.WrongWords}";

            rtbCharacters.Text = $"{Result.CorrectStrokes}/{Result.WrongStrokes}";

            if (Diff_WPM >0)
                pbBest.Show();
            else
                pbBest.Hide();

            Result.TestDate = DateTime.Now;

            Result.AddResult();
        }

        private void CanType()
        {
            tbType.ReadOnly = !rtbWords.Visible;
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            Result.Mode = (enMode)int.Parse(btn.Text);

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
            Result.Mode = (enMode)int.Parse(btn.Text);

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

            if (stopwatch.Elapsed.Seconds >= NumberOfSeconds)
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
