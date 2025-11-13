using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1
    {
        public enum enMode { Words, Time };

        public enMode Mode = enMode.Time;

        double CurrentWPM = 0.0;

        short CurrentWordCounter = 0;
        
        short CorrectWordsCounter = 0;
        short WrongWordsCounter = 0;

        int CorrectStrokes = 0;
        int WrongStrokes = 0;

        static string AllWords10FastFingers = "about|above|add|after|again|air|all|almost|along|also|always|America|an|and|animal|another|answer|any|are|around|as|ask|at|away|back|be|because|been|before|began|begin|being|below|between|big|book|both|boy|but|by|call|came|can|car|carry|change|children|city|close|come|could|country|cut|day|did|different|do|does|don't|down|each|earth|eat|end|enough|even|every|example|eye|face|family|far|father|feet|few|find|first|follow|food|for|form|found|four|from|get|girl|give|go|good|got|great|group|grow|had|hand|hard|has|have|he|head|hear|help|her|here|high|him|his|home|house|how|idea|if|important|in|Indian|into|is|it|its|it's|just|keep|kind|know|land|large|last|later|learn|leave|left|let|letter|life|light|like|line|list|little|live|long|look|made|make|man|many|may|me|mean|men|might|mile|miss|more|most|mother|mountain|move|much|must|my|name|near|need|never|new|next|night|no|not|now|number|of|off|often|oil|old|on|once|one|only|open|or|other|our|out|over|own|page|paper|part|people|picture|place|plant|play|point|put|question|quick|quickly|quite|read|really|right|river|run|said|same|saw|say|school|sea|second|see|seem|sentence|set|she|should|show|side|small|so|some|something|sometimes|song|soon|sound|spell|start|state|still|stop|story|study|such|take|talk|tell|than|that|the|their|them|then|there|these|they|thing|think|this|those|thought|three|through|time|to|together|too|took|tree|try|turn|two|under|until|up|us|use|very|walk|want|was|watch|water|way|we|well|went|were|what|when|where|which|while|white|who|why|will|with|without|word|work|world|would|write|year|you|young|your";
        // 302 words

        static string AllWordsMonkeyType = "a about and any as ask at back be but by can come do down end few find for go group have he help home house how if in into it large last late lead life line man many may more move new no not now of on one open or other out own part plan play point real run same say set she so some take the this those time to turn up use want we what who with work you against also another before begin both change child could course day each early face form from get give great hand hold just know leave like long make mean might most most must number old only over person place right should show since stand such than then they thing think very way when while word would write year again all call even eye fact feel good here high increase keep nation off order see seem small still tell that these too well where which will without after because become between consider develop during first follow general however interest little look need never people present problem program public school state system there through under world";
        // 196 words

        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] words = AllWords10FastFingers.Split('|');

        string[] CurrentWords = new string[NumberOfWords];

        Random rndWord = new Random();

        private bool CheckCurrentWordTypedTrue()
        {
            return tbType.Text == CurrentWords[CurrentWordCounter];
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

            CurrentWordCounter = 0;
            CorrectWordsCounter = 0;
            WrongWordsCounter = 0;
            WrongStrokes = 0;
            CorrectStrokes = 0;

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
            RestartWords();
            ResetTimer();
            pnlResults.Hide();

            if (IsSettingsOpen)
                tbType.ReadOnly = true;
            else
                tbType.ReadOnly = false;
        }

        private bool AreAllWordsTyped()
        {
            return (CurrentWordCounter >= NumberOfWords);
        }

        private bool IsWordTypingFinished()
        {
            return tbType.Text.EndsWith(" ");
        }

        private void CheckEachCharInCurrentWord()
        {
            if (CurrentWordCounter >= NumberOfWords) return;

            for (int i = 0; (i < CurrentWords[CurrentWordCounter].Length) && (i < tbType.Text.Length); i++)
            {
                if (tbType.Text[i] == CurrentWords[CurrentWordCounter][i] && tbType.Text.Length <= CurrentWords[CurrentWordCounter].Length)
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = rtbWords.BackColor;
                }
                else
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = WrongWordColor;
                    break;
                }
            }
        }

        private void DealWithCounters()
        {
            if (tbType.Text == CurrentWords[CurrentWordCounter])
            {
                CorrectWordsCounter++;

                CorrectStrokes += CurrentWords[CurrentWordCounter].Length + 1;
            }
            else
            {
                WrongWordsCounter++;

                WrongStrokes += CurrentWords[CurrentWordCounter].Length;
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

            tbWordsCounter.Text = CurrentWordCounter.ToString() + $"/{NumberOfWords}";
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

                CurrentWordCounter++;

                SetCurrentWordColor();

                rtbWords.ScrollToCaret();

                tbType.Text = "";

                if (AreAllWordsTyped())
                {
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
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                rtbWords.SelectionColor = CorrectWordColor;
            }
            else
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                rtbWords.SelectionColor = WrongWordColor;
            }
        }

        private void UpdateIndexOfFirstCharOfCurrentWord()
        {
            IndexOfFirstCharOfCurrentWord += 1 + CurrentWords[CurrentWordCounter].Length;
        }

        private void SetCurrentWordColor()
        {
            if (CurrentWordCounter < NumberOfWords)
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
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
            rtbKeyStrokes.Text = "(" + CorrectStrokes + " | " + WrongStrokes + ")  " + (CorrectStrokes + WrongStrokes);

            rtbKeyStrokes.Select(1, CorrectStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Green;

            rtbKeyStrokes.Select(1 + CorrectStrokes.ToString().Length + 3, WrongStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Red;
        }

        Stopwatch stopwatch = new Stopwatch();

        private double CalcWPM()
        {
            double WPM = 0.0;

            double Words = CorrectStrokes / 5.0;

            double TotalSeconds = (double)stopwatch.ElapsedMilliseconds / 1000;

            if(Words == 0 || TotalSeconds == 0)
            {
                CurrentWPM = WPM;
                return 0.0;
            }   

            WPM = Words / (TotalSeconds / 60.0);

            CurrentWPM = WPM;
            return WPM;
        }

        private void ShowResults()
        {
            pnlResults.BringToFront();
            pnlResults.Visible = true;

            rtbCorrectWords.Text = CorrectWordsCounter.ToString();
            rtbWrongWords.Text = WrongWordsCounter.ToString();
            if (CurrentWordCounter == 0)
            {
                rtbAccuracy.Text = "0%";
            }
            else
            {
                rtbAccuracy.Text = (Convert.ToInt16((Convert.ToDouble(CorrectStrokes) / (CorrectStrokes + WrongStrokes)) * 100)).ToString() + "%";
            }

            rtbFinalWPM.Text = Convert.ToInt16(CalcWPM()).ToString();
            
            SetKeyStrokesColors();
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            Mode = enMode.Time;

            ResetTimer();

            RestartWords();

            pnlResults.Hide();
            if (!IsSettingsOpen)
            {
                tbType.ReadOnly = false;
            }

            NumberOfSeconds = Convert.ToInt16(btn.Text);

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Gainsboro;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Gainsboro;

            CurrentBtn = btn;
            CurrentBtn.BackColor = SelectColor;
        }

        private void ChangeNumberOfWords(Button btn)
        {
            Mode = enMode.Words;

            ResetTimer();

            NumberOfWords = Convert.ToInt16(btn.Text);
            CurrentWords = new string[NumberOfWords];
            RestartWords();

            pnlResults.Hide();
            if (!IsSettingsOpen)
            {
                tbType.ReadOnly = false;
            }

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
