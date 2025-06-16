using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;
using System.Security;
using System.Data.SqlTypes;
using System.Drawing.Printing;
using System.Runtime.ExceptionServices;
using System.Diagnostics.Eventing.Reader;

namespace Typing_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        short CurrentWordCounter = 1;

        short CorrectWordsCounter = 0;
        short WrongWordsCounter = 0;

        static string AllWords = "about|above|add|after|again|air|all|almost|along|also|always|America|an|and|animal|another|answer|any|are|around|as|ask|at|away|back|be|because|been|before|began|begin|being|below|between|big|book|both|boy|but|by|call|came|can|car|carry|change|children|city|close|come|could|country|cut|day|did|different|do|does|don't|down|each|earth|eat|end|enough|even|every|example|eye|face|family|far|father|feet|few|find|first|follow|food|for|form|found|four|from|get|girl|give|go|good|got|great|group|grow|had|hand|hard|has|have|he|head|hear|help|her|here|high|him|his|home|house|how|idea|if|important|in|Indian|into|is|it|its|it's|just|keep|kind|know|land|large|last|later|learn|leave|left|let|letter|life|light|like|line|list|little|live|long|look|made|make|man|many|may|me|mean|men|might|mile|miss|more|most|mother|mountain|move|much|must|my|name|near|need|never|new|next|night|no|not|now|number|of|off|often|oil|old|on|once|one|only|open|or|other|our|out|over|own|page|paper|part|people|picture|place|plant|play|point|put|question|quick|quickly|quite|read|really|right|river|run|said|same|saw|say|school|sea|second|see|seem|sentence|set|she|should|show|side|small|so|some|something|sometimes|song|soon|sound|spell|start|state|still|stop|story|study|such|take|talk|tell|than|that|the|their|them|then|there|these|they|thing|think|this|those|thought|three|through|time|to|together|too|took|tree|try|turn|two|under|until|up|us|use|very|walk|want|was|watch|water|way|we|well|went|were|what|when|where|which|while|white|who|why|will|with|without|word|work|world|would|write|year|you|young|your";
        // 302 words

        string[] word = AllWords.Split('|');

        string[] CurrentWords = new string[NumberOfWords];

        static short NumberOfWords = 25;

        static short NumberOfSeconds = 15;

        Random rndWord = new Random();

        bool IsStarted = true;

        private TimeSpan _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

        private TimeSpan _TimeCounterForWords = TimeSpan.FromSeconds(0);

        Color CurrentWordColor = Color.Purple;
        Color CorrectWordColor = Color.Green;
        Color WrongWordColor = Color.Red;
        Color DefaultWordsColor = Color.Black;
        Color SelectColor = Color.Blue;


        enum enMode {Words,Time };

        enMode Mode = enMode.Time;

        private bool CheckCurrentWordTypedTrue()
        {
            return tbType.Text == CurrentWords[CurrentWordCounter];
        }

        private void FillWords()
        {
            string TempText = "";

            for (int i = 0; i < NumberOfWords; i++)
            {
                int rndNUM = rndWord.Next(0, 300);

                CurrentWords[i] = word[rndNUM];
                TempText += word[rndNUM];
                TempText += " ";
            }

            rtbWords.Text = TempText;
            tbType.Text = "";
        }

        private void RestartWords()
        {
            TimerForSeconds.Stop();

            rtbWords.SelectAll();
            rtbWords.SelectionColor = DefaultBackColor;

            FillWords();

            tbType.Enabled = true;
            tbType.Focus();

            CurrentWordCounter = 0;
            CorrectWordsCounter = 0;
            WrongWordsCounter = 0;

            SetFirstWordColor();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            tbType.Select();

            RestartWords();
            SetFirstWordColor();
            rtbWords.ForeColor = DefaultWordsColor;
            btn15.BackColor = SelectColor;

            rtbCorrectWords.SelectAll();
            rtbCorrectWords.SelectionAlignment = HorizontalAlignment.Right;

            rtbWrongWords.SelectAll();
            rtbWrongWords.SelectionAlignment = HorizontalAlignment.Right;

            rtbKeyStrokes.SelectAll();
            rtbKeyStrokes.SelectionAlignment = HorizontalAlignment.Right;



            //tbTimer.Text = TimeSpan.FromSeconds(NumberOfSeconds).ToString(@"mm\:ss");

        }

        private void SetFirstWordColor()
        {

            IndexOfFirstCharOfCurrentWord = 0;
            rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[0].Length );
            rtbWords.SelectionColor = CurrentWordColor;

        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartWords();
            ResetTimer();
            groupBox1.Visible = false;
            tbType.ReadOnly = false;
        }

        private bool AreAllWordsTyped()
        {
            if (CurrentWordCounter == NumberOfWords)
            {
                IsStarted = false;
                tbType.Enabled = false;
                TimerForSeconds.Stop();
                return true;
            }
            return false;
        }

        private bool IsWordTypingFinished()
        {
            if (tbType.Text.EndsWith(" "))
                return true;
            else
                return false;
        }


        private void CheckEachCharInCurrentWord()
        {
            if (CurrentWordCounter >= NumberOfWords) return;

            for (int i = 0; (i < CurrentWords[CurrentWordCounter].Length) && (i < tbType.Text.Length); i++)
            {
                if (tbType.Text[i] == CurrentWords[CurrentWordCounter][i] && tbType.Text.Length <= CurrentWords[CurrentWordCounter].Length)
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = Color.White;
                }
                else
                {
                    rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                    rtbWords.SelectionBackColor = Color.Red;
                    break;
                }
            }
        }

        

        private void DealWithCorrectAndWrongWordsCounter()
        {
            if (tbType.Text == CurrentWords[CurrentWordCounter])
            {
                CorrectWordsCounter++;
                tbCorrectwords.Text = CorrectWordsCounter.ToString();

                CorrectStrokes += CurrentWords[CurrentWordCounter].Length+ (" ".Length);
            }
            else
            {
                WrongWordsCounter++;
                tbWrongwords.Text = WrongWordsCounter.ToString();

                WrongStrokes += CurrentWords[CurrentWordCounter].Length;
            }
        }

        int CorrectStrokes = 0;
        int WrongStrokes = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbType.Text == " " || tbType.Text == "")
            {
                rtbWords.SelectionBackColor = Color.White;
                tbType.Text = "";
                return;
            }
            
            IsStarted = true;

            if(Mode == enMode.Time)
            {
                TimerForSeconds.Start();
                tbTimer.Text = _timeRemainingForSeconds.ToString(@"mm\:ss");
            }
            else
            {
                TimerForWords.Start();
                tbTimer.Text = "";
            }

            CheckEachCharInCurrentWord();
            
            if (AreAllWordsTyped())
            {
                return;
            }


            if (IsWordTypingFinished())
            {
                tbType.Text = tbType.Text.Trim();

                DealWithCorrectAndWrongWordsCounter();

                SetPrevWordColor();

                rtbWords.SelectionBackColor = Color.White;

                UpdateIndexOfFirstCharOfCurrentWord();

                CurrentWordCounter++;

                SetCurrentWordColor();

                tbType.Text = "";
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
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length );
                rtbWords.SelectionColor = WrongWordColor;
            }

        }

        private void UpdateIndexOfFirstCharOfCurrentWord()
        {
            IndexOfFirstCharOfCurrentWord += 1 + CurrentWords[CurrentWordCounter].Length;
        }

        private void SetCurrentWordColor()
        {
            if(CurrentWordCounter<NumberOfWords)
            {
                rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[CurrentWordCounter].Length);
                rtbWords.SelectionColor = CurrentWordColor;

            }
        }

        private void btnChangeNumberOfWords_Click(object sender, EventArgs e)
        {
            ChangeNumberOfWords((Button)sender);
        }


        private void ResetTimer()
        {
            TimerForSeconds.Stop();
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);
            tbTimer.Text = "";
        }

        private void UpdateTimerDisplay()
        {
            tbTimer.Text = _timeRemainingForSeconds.ToString(@"mm\:ss");
        }

        private void SetKeyStrokesColors()
        {
            rtbKeyStrokes.Text = "(" + CorrectStrokes + " | " + WrongStrokes + ")   " + (CorrectStrokes + WrongStrokes);

            rtbKeyStrokes.Select(1, CorrectStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Green;

            rtbKeyStrokes.Select(1 + CorrectStrokes.ToString().Length + 3, WrongStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Red;
        }

        private void ShowResults()
        {
            groupBox1.Visible = true;

            rtbCorrectWords.Text = CorrectWordsCounter.ToString();
            rtbWrongWords.Text = WrongWordsCounter.ToString();

            SetKeyStrokesColors();
        }

        private void TimerForSeconds_Tick(object sender, EventArgs e)
        {
            if(IsStarted)
            {
                 _timeRemainingForSeconds = _timeRemainingForSeconds.Subtract(TimeSpan.FromSeconds(1));

                if (_timeRemainingForSeconds <= TimeSpan.Zero)
                {
                    IsStarted = false;
                }

                UpdateTimerDisplay();
            }
            else
            {
                tbType.ReadOnly = true;

                ShowResults();

                ResetTimer();
            }

        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            Mode = enMode.Time;

            TimerForSeconds.Stop();
            TimerForWords.Stop();

            NumberOfSeconds = Convert.ToInt16(btn.Text);
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);
            //tbTimer.Text = _timeRemaining.ToString(@"mm\:ss");

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Gainsboro;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Gainsboro;

            btn.BackColor = SelectColor;
        }

        private void ChangeNumberOfWords(Button btn)
        {
            Mode = enMode.Words;

            TimerForWords.Stop();
            TimerForSeconds.Stop();
            
            NumberOfWords = Convert.ToInt16(btn.Text);
            CurrentWords = new string[NumberOfWords];
            RestartWords();

            tbTimer.Text = "";

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Gainsboro;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Gainsboro;

            btn.BackColor = SelectColor;
        }

        private void btnChangeNumberOfSeconds_Click(object sender, EventArgs e)
        {
            
            ChangeNumberOfSeconds((Button)sender);
        }

        private void TimerForWords_Tick(object sender, EventArgs e)
        {
            _TimeCounterForWords = _TimeCounterForWords.Add(TimeSpan.FromSeconds(1));
        }

        private void HideWordsButtons()
        {
            btn10.Hide();
            btn25.Hide();
            btn50.Hide();
            btn100.Hide();
        }

        private void ShowWordsButtons()
        {
            btn10.Show();
            btn25.Show();
            btn50.Show();
           btn100.Show();
        }

        private void HideSecondsButtons()
        {
            btn15.Hide();
            btn30.Hide();
            btn60.Hide();
            btn120.Hide();
        }

        private void ShowSecondsButtons()
        {
            btn15.Show();
            btn30.Show();
            btn60.Show();
           btn120.Show();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Words)
            {
                TimerForWords.Stop();

                Mode = enMode.Time;

                HideWordsButtons();
                ShowSecondsButtons();

                ChangeNumberOfSeconds(btn15);
            }
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Time)
            {
                TimerForSeconds.Stop();

                Mode = enMode.Words;

                HideSecondsButtons();
                ShowWordsButtons();

                ChangeNumberOfWords(btn10);
            }
        }






        // ********** Coming extensions **********:
        // Timer
        // WPM
        // Result Screen
        //
        //
        //
        //
        //
        //
    }
}
