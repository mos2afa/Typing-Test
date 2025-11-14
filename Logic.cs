using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        static string AllWords10FastFingers = "about|above|add|after|again|air|all|almost|along|also|always|America|an|and|animal|another|answer|any|are|around|as|ask|at|away|back|be|because|been|before|began|begin|being|below|between|big|book|both|boy|but|by|call|came|can|car|carry|change|children|city|close|come|could|country|cut|day|did|different|do|does|don't|down|each|earth|eat|end|enough|even|every|example|eye|face|family|far|father|feet|few|find|first|follow|food|for|form|found|four|from|get|girl|give|go|good|got|great|group|grow|had|hand|hard|has|have|he|head|hear|help|her|here|high|him|his|home|house|how|idea|if|important|in|Indian|into|is|it|its|it's|just|keep|kind|know|land|large|last|later|learn|leave|left|let|letter|life|light|like|line|list|little|live|long|look|made|make|man|many|may|me|mean|men|might|mile|miss|more|most|mother|mountain|move|much|must|my|name|near|need|never|new|next|night|no|not|now|number|of|off|often|oil|old|on|once|one|only|open|or|other|our|out|over|own|page|paper|part|people|picture|place|plant|play|point|put|question|quick|quickly|quite|read|really|right|river|run|said|same|saw|say|school|sea|second|see|seem|sentence|set|she|should|show|side|small|so|some|something|sometimes|song|soon|sound|spell|start|state|still|stop|story|study|such|take|talk|tell|than|that|the|their|them|then|there|these|they|thing|think|this|those|thought|three|through|time|to|together|too|took|tree|try|turn|two|under|until|up|us|use|very|walk|want|was|watch|water|way|we|well|went|were|what|when|where|which|while|white|who|why|will|with|without|word|work|world|would|write|year|you|young|your";
        // 302 words

        static string AllWordsMonkeyType = "a about and any as ask at back be but by can come do down end few find for go group have he help home house how if in into it large last late lead life line man many may more move new no not now of on one open or other out own part plan play point real run same say set she so some take the this those time to turn up use want we what who with work you against also another before begin both change child could course day each early face form from get give great hand hold just know leave like long make mean might most most must number old only over person place right should show since stand such than then they thing think very way when while word would write year again all call even eye fact feel good here high increase keep nation off order see seem small still tell that these too well where which will without after because become between consider develop during first follow general however interest little look need never people present problem program public school state system there through under world";
        // 196 words

        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] words = AllWords10FastFingers.Split('|');

        string[] CurrentWords = new string[NumberOfWords];

        Random rndWord = new Random();

        public bool IsTestCompleted = false;

        private bool CheckCurrentWordTypedTrue()
        {
            return tbType.Text == CurrentWords[CurrentTest.CurrentWordCounter];
        }

        private void FillWords()
        {
            string TempText = "";

            for (int i = 0; i < NumberOfWords; i++)
            {
                int RandomNumber = rndWord.Next(0, words.Length);

                CurrentWords[i] = words[RandomNumber];
                TempText += words[RandomNumber];
                TempText += " ";
            }

            rtbWords.Text = TempText;
            rtbWords.Text += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"; // because there was a glitch in 50 / 100 words mode because of rtbwords.scrolltocaret() function.

            tbType.Text = "";
        }

        private void RestartWords()
        {
            rtbWords.SelectAll();
            rtbWords.SelectionColor = DefaultBackColor;

            FillWords();

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
            if (tbType.Text == CurrentWords[CurrentTest.CurrentWordCounter])
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
            if (CheckCurrentWordTypedTrue())
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

            CurrentTest.WPM = Convert.ToDouble(WPM.ToString("F2"));
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

        private void ShowResults()
        {
            ShowResultScreen();

            rtbCorrectWords.Text = CurrentTest.CorrectWords.ToString();
            rtbWrongWords.Text = CurrentTest.WrongWords.ToString();

            CurrentTest.Accuracy = Convert.ToDouble(CalcAccuracy().ToString("F2"));
            rtbAccuracy.Text = CurrentTest.Accuracy.ToString("F0") + "%";

            rtbFinalWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

            CurrentTest.DurationSeconds = stopwatch.Elapsed.TotalSeconds;
            rtbDuration.Text = CurrentTest.DurationSeconds.ToString("F2") +" s";

            SetKeyStrokesColors();

            Test.AddResult(CurrentTest);
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            CurrentTest.Mode = enMode.Time;

            ResetTimer();

            RestartWords();

            NumberOfSeconds = Convert.ToInt16(btn.Text);

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Gainsboro;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Gainsboro;

            CurrentBtn = btn;
            CurrentBtn.BackColor = SelectColor;
        }

        private void ChangeNumberOfWords(Button btn)
        {
            CurrentTest.Mode = enMode.Words;

            ResetTimer();

            NumberOfWords = Convert.ToInt16(btn.Text);
            CurrentWords = new string[NumberOfWords];
            RestartWords();

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Gainsboro;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Gainsboro;

            CurrentBtn = btn;
            CurrentBtn.BackColor = SelectColor;
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

        private void tUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateTestTimer();
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
