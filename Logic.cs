using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

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
            return tbType.Text == CurrentWords[Test.CurrentWordCounter];
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

            Test.CurrentWordCounter = 0;
            Test.CorrectWords = 0;
            Test.WrongWords = 0;
            Test.CorrectStrokes = 0;
            Test.WrongStrokes = 0;

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
            ResetTest();

            tbType.ReadOnly = false;
        }

        private bool AreAllWordsTyped()
        {
            IsTestCompleted = (Test.CurrentWordCounter >= NumberOfWords);
            return IsTestCompleted;
        }

        private bool IsWordTypingFinished()
        {
            return tbType.Text.EndsWith(" ");
        }

        private void CheckEachCharInCurrentWord()
        {
            if (Test.CurrentWordCounter >= NumberOfWords) return;

            for (int i = 0; (i < CurrentWords[Test.CurrentWordCounter].Length) && (i < tbType.Text.Length); i++)
            {
                if (tbType.Text[i] == CurrentWords[Test.CurrentWordCounter][i] && tbType.Text.Length <= CurrentWords[Test.CurrentWordCounter].Length)
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = rtbWords.BackColor;
                }
                else
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = WrongWordColor;
                    break;
                }
            }
        }

        private void DealWithCounters()
        {
            if (IsCurrentWordTypedTrue())
            {
                Test.CorrectWords++;

                Test.CorrectStrokes += CurrentWords[Test.CurrentWordCounter].Length + 1;
            }
            else
            {
                Test.WrongWords++;

                Test.WrongStrokes += CurrentWords[Test.CurrentWordCounter].Length;
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

            StartTest();

            CheckEachCharInCurrentWord();

            if (IsWordTypingFinished())
            {
                tbType.Text = tbType.Text.Trim();

                DealWithCounters();

                SetPrevWordColor();

                rtbWords.SelectionBackColor = rtbWords.BackColor;

                UpdateIndexOfFirstCharOfCurrentWord();

                Test.CurrentWordCounter++;
                tbWordsCounter.Text =  $"{Test.CurrentWordCounter}/{NumberOfWords}";

                SetCurrentWordColor();

                rtbWords.ScrollToCaret();

                tbType.Text = "";

                if (AreAllWordsTyped())
                {
                    tbType.ReadOnly = true;
                    ShowResults();
                    ResetTest();

                    tbLiveWPM.Text = "";
                }
            }
        }

        int IndexOfFirstCharOfCurrentWord = 0;

        private void SetPrevWordColor()
        {
            if (IsCurrentWordTypedTrue())
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);
                rtbWords.SelectionColor = CorrectWordColor;
            }
            else
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);
                rtbWords.SelectionColor = WrongWordColor;
            }
        }

        private void UpdateIndexOfFirstCharOfCurrentWord()
        {
            IndexOfFirstCharOfCurrentWord += 1 + CurrentWords[Test.CurrentWordCounter].Length;
        }

        private void SetCurrentWordColor()
        {
            if (Test.CurrentWordCounter < NumberOfWords)
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);
                rtbWords.SelectionColor = CurrentWordColor;
            }
        }        

        private void ChangeCurrentLanguage(string Name)
        {
            string SelectedLanguage = Languages.GetLanguageWords(Name);
            AllLanguageWords = SelectedLanguage.Split(' ');
            RestartWords();
        }

        TimeSpan SecondsCounter = TimeSpan.Zero;
        Stopwatch stopwatch = new Stopwatch();

        private double CalcWPM()
        {
            double WPM = 0.0,TotalSeconds = 0.0;

            double Words = Test.CorrectStrokes / 5.0;

            if(Test.IsTimeMode())
            {
                TotalSeconds = SecondsCounter.TotalSeconds;
            }
            else
            {
                TotalSeconds = (double)stopwatch.ElapsedMilliseconds / 1000;
            }


            if (Words == 0 || TotalSeconds == 0)
            {
                Test.WPM = 0.00;
                return 0.0;
            }   

            WPM = Words / (TotalSeconds / 60.0);

            Test.WPM = Math.Round(WPM,2);
            return WPM;
        }

        private double CalcAccuracy()
        {
            if (Test.CurrentWordCounter == 0)
            {
                return 0.0;
            }
            else
            {
                return ((double)(Test.CorrectStrokes) / (Test.CorrectStrokes + Test.WrongStrokes)) * 100;
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

            Test.Language = cbLanguage.SelectedItem.ToString();

            rtbTestType.Text = $"{Test.Mode}\n{Test.Language}";

            Test.Accuracy = Math.Round(CalcAccuracy(),2);
            rtbAccuracy.Text = Test.Accuracy.ToString("F0") + "%";

            rtbFinalWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

            Test.DurationSeconds = Math.Round(Test.IsTimeMode()? SecondsCounter.TotalSeconds :stopwatch.Elapsed.TotalSeconds,2);
            rtbDuration.Text = Test.DurationSeconds.ToString("F0") +"s";

            Diff_WPM = Test.WPM - Test.GetMaxWPM(Test.Language,Test.Mode);

            rtbWordsCounter.Text = $"{Test .CorrectWords}/{Test.WrongWords}";

            rtbCharacters.Text = $"{Test.CorrectStrokes}/{Test.WrongStrokes}";

            if (Diff_WPM >0)
                pbBest.Show();
            else
                pbBest.Hide();

            Test.TestDate = DateTime.Now;

            Test.AddResult();
        }

        private void CanType()
        {
            tbType.ReadOnly = !rtbWords.Visible;
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            Test.Mode = (enMode)int.Parse(btn.Text);

            ResetTest();

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
            Test.Mode = (enMode)int.Parse(btn.Text);

            ResetTest();

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

        

        private void StartTest()
        {
            tUpdateUI.Start();

            if(Test.IsTimeMode())
            {
                tbTimer.Text = SecondsCounter.ToString(@"mm\:ss");
            }
            else // Words mode
            {
                stopwatch.Start();
                tbWordsCounter.Text = $"{Test.CurrentWordCounter}/{NumberOfWords}";
            }

            if (tbLiveWPM.Text == "")
                tbLiveWPM.Text = "0";
        }

        private void ResetTest()
        {
            tUpdateUI.Stop();

            stopwatch = new Stopwatch();
            SecondsCounter = TimeSpan.Zero;

            tbTimer.Text = "";
            tbLiveWPM.Text = "";
            tbWordsCounter.Text = "";
        }


        private void UpdateTestTimer()
        {
            if (Test.IsTimeMode())
            {
                SecondsCounter = SecondsCounter.Add(TimeSpan.FromSeconds(1));

                tbTimer.Text = SecondsCounter.ToString(@"mm\:ss");

                if (SecondsCounter.TotalSeconds >= NumberOfSeconds)
                {
                    IsTestCompleted = true;
                    tbType.ReadOnly = true;
                    ShowResults();
                    ResetTest();
                    return;
                }
            }

            // For both modes
            tbLiveWPM.Text = Math.Round(CalcWPM()).ToString();
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
