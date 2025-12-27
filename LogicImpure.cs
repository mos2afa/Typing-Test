using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using static Typing_Test.AppSettings;

namespace Typing_Test
{
    public partial class Form1
    {
        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] AllLanguageWords;

        string[] CurrentWords = new string[NumberOfWords];

        public bool IsTestCompleted = false;

        

        private bool IsCurrentWordTypedCorrectly()
        {
            return tbType.Text == CurrentWord;
        }


        private void RestartWords()
        {
            rtbWords.SelectAll();
            rtbWords.SelectionColor = DefaultBackColor;

            CurrentWords = Logic.FillRandomWords(AllLanguageWords,NumberOfWords);
            rtbWords.Text = Logic.ConvertStringArrayToString(CurrentWords);

            tbType.Text = "";
            tbType.Focus();

            Test.CurrentWordCounter = 0;
            Test.CorrectWords = 0;
            Test.WrongWords = 0;
            Test.CorrectStrokes = 0;
            Test.WrongStrokes = 0;

            SetFirstWordColor();

            HideTestsScreen();

            rtbWords.Select(0, 1);
            rtbWords.ScrollToCaret();
        }

        private void SetFirstWordColor()
        {
            IndexOfFirstCharOfCurrentWord = 0;
            rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[0].Length);
            rtbWords.SelectionColor = color(settings.CurrentWordColor);
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
            return Test.CurrentWordCounter >= NumberOfWords;
        }

        private bool IsWordTypingFinished()
        {
            return tbType.Text.EndsWith(" ");
        }

        private void CheckEachCharInCurrentWord()
        {
            if (AreAllWordsTyped()) return;

            rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);

            if (Logic.CheckEachChar(tbType.Text, CurrentWord))
            {
                rtbWords.SelectionBackColor = rtbWords.BackColor;
            }
            else
            {
                rtbWords.SelectionBackColor = color(settings.WrongWordColor);
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

                bool TypedCorrectly = IsCurrentWordTypedCorrectly(); 

                if(TypedCorrectly)
                {
                    Test.CorrectWords++;
                    Test.CorrectStrokes += CurrentWord.Length + 1;

                    SetPrevWordColor(color(settings.CorrectWordColor));
                }
                else
                {
                    Test.WrongWords++;
                    Test.WrongStrokes += CurrentWord.Length;

                    SetPrevWordColor(color(settings.WrongWordColor));
                }

                rtbWords.SelectionBackColor = rtbWords.BackColor;

                UpdateIndexOfFirstCharOfCurrentWord();

                Test.CurrentWordCounter++;
                tbWordsCounter.Text =  $"{Test.CurrentWordCounter}/{NumberOfWords}";

                SetCurrentWordColor();

                rtbWords.ScrollToCaret();

                tbType.Text = "";

                if (AreAllWordsTyped())
                {
                    IsTestCompleted = true;
                    tbType.ReadOnly = true;
                    ShowResults();
                    ResetTest();

                    tbLiveWPM.Text = "";
                }
            }
        }

        int IndexOfFirstCharOfCurrentWord = 0;

        private void SetPrevWordColor(Color color)
        {
            rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWord.Length);

            rtbWords.SelectionColor = color;
        }

        private void UpdateIndexOfFirstCharOfCurrentWord()
        {
            IndexOfFirstCharOfCurrentWord += 1 + CurrentWords[Test.CurrentWordCounter].Length;
        }

        private void SetCurrentWordColor()
        {
            if (!AreAllWordsTyped())
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[Test.CurrentWordCounter].Length);
                rtbWords.SelectionColor = color(settings.CurrentWordColor);
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
        private string CurrentWord
        {
            get
            {
                if (Test.CurrentWordCounter >= NumberOfWords) return "";
                return CurrentWords[Test.CurrentWordCounter];
            }
        }

        private int CorrectStrokesInCurrentWord
        {
            get { return Logic.NumberOfCorrectStrokes(tbType.Text, CurrentWord); }
        }


        private double CalcWPMForCurrentTest()
        {
            double ElapsedMilliseconds = 0.00;

            if(Test.IsTimeMode())
                ElapsedMilliseconds = SecondsCounter.TotalSeconds*1000;
            else
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            
            return Logic.CalcWPM(Test.CorrectStrokes + CorrectStrokesInCurrentWord, ElapsedMilliseconds);
        }

        private double CalcAccuracyForCurrentTest()
        {
            if (Test.CurrentWordCounter == 0)
                return 0.0;
            else
                return Logic.CalcAccuracy(Test.CorrectStrokes, Test.WrongStrokes);
        }



        double Diff_WPM = -1;

        private void ShowResults()
        {
            ShowResultScreen();

            Test.Language = cbLanguage.SelectedItem.ToString();

            rtbTestType.Text = $"{Test.Mode}\n{Test.Language}";

            Test.Accuracy = Math.Round(CalcAccuracyForCurrentTest(),2);
            rtbAccuracy.Text = Test.Accuracy.ToString("F0") + "%";

            Test.WPM = CalcWPMForCurrentTest();

            rtbFinalWPM.Text = Convert.ToInt16(Test.WPM).ToString();

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
            CurrentBtn.BackColor = color(settings.SelectColor);

            ShowTypingTestScreen();

            CanType();

            tbType.Focus();
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
            CurrentBtn.BackColor = color(settings.SelectColor);

            ShowTypingTestScreen();

            CanType();

            tbType.Focus();
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
            tbLiveWPM.Text = Math.Round(CalcWPMForCurrentTest()).ToString();
        }

        private void PerformCtrlBackSpace(KeyEventArgs e)
        {
            e.SuppressKeyPress = true; // Prevent the default Backspace behavior (inserting space)

            tbType.Text = "";
        }
    }
}
