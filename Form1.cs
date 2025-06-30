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
using Typing_Test.Properties;
using System.IO.Pipes;

namespace Typing_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            //this.WindowState = FormWindowState.Maximized;
        }

        short CurrentWordCounter = 1;

        short CorrectWordsCounter = 0;
        short WrongWordsCounter = 0;

        int CorrectStrokes = 0;
        int WrongStrokes = 0;

        static string AllWords = "about|above|add|after|again|air|all|almost|along|also|always|America|an|and|animal|another|answer|any|are|around|as|ask|at|away|back|be|because|been|before|began|begin|being|below|between|big|book|both|boy|but|by|call|came|can|car|carry|change|children|city|close|come|could|country|cut|day|did|different|do|does|don't|down|each|earth|eat|end|enough|even|every|example|eye|face|family|far|father|feet|few|find|first|follow|food|for|form|found|four|from|get|girl|give|go|good|got|great|group|grow|had|hand|hard|has|have|he|head|hear|help|her|here|high|him|his|home|house|how|idea|if|important|in|Indian|into|is|it|its|it's|just|keep|kind|know|land|large|last|later|learn|leave|left|let|letter|life|light|like|line|list|little|live|long|look|made|make|man|many|may|me|mean|men|might|mile|miss|more|most|mother|mountain|move|much|must|my|name|near|need|never|new|next|night|no|not|now|number|of|off|often|oil|old|on|once|one|only|open|or|other|our|out|over|own|page|paper|part|people|picture|place|plant|play|point|put|question|quick|quickly|quite|read|really|right|river|run|said|same|saw|say|school|sea|second|see|seem|sentence|set|she|should|show|side|small|so|some|something|sometimes|song|soon|sound|spell|start|state|still|stop|story|study|such|take|talk|tell|than|that|the|their|them|then|there|these|they|thing|think|this|those|thought|three|through|time|to|together|too|took|tree|try|turn|two|under|until|up|us|use|very|walk|want|was|watch|water|way|we|well|went|were|what|when|where|which|while|white|who|why|will|with|without|word|work|world|would|write|year|you|young|your";
        // 302 words

        string[] word = AllWords.Split('|');

        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] CurrentWords = new string[NumberOfWords];


        Random rndWord = new Random();

        bool IsStartedTimeMode = true;
        bool IsStartedWordsMode = true;

        private TimeSpan _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

        private TimeSpan _TimeCounterForWords = TimeSpan.FromSeconds(0);

        // my first colors
        Color CurrentWordColor = Color.Purple;
        Color CorrectWordColor = Color.Green;
        Color WrongWordColor = Color.Red;
        Color DefaultWordsColor = Color.Black;
        //Color SelectColor = Color.DodgerBlue;
        Color SelectColor = Color.FromArgb(106, 90, 205);


        // Gemini colors
        //Color CurrentWordColor = Color.FromArgb(106, 90, 205); // Slate Blue / Lavender
        //Color CorrectWordColor = Color.FromArgb(32, 201, 151); // Teal Green
        //Color WrongWordColor = Color.FromArgb(224, 82, 82);   // Soft Red
        //Color DefaultWordsColor = Color.FromArgb(74, 74, 74); // Medium-Dark Grey
        //Color SelectColor = Color.FromArgb(106, 90, 205);     // Matching Current Word color for selected buttons




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
            rtbWords.Text += "\n\n\n\n\n\n\n"; // because there was a glitch in 50 / 100 words mode because of rtbwords.scrolltocaret() function.

            tbType.Text = "";
        }

        private void RestartWords()
        {
            rtbWords.SelectAll();
            rtbWords.SelectionColor = DefaultBackColor;

            FillWords();

            tbType.Enabled = true;
            tbType.Focus();

            CurrentWordCounter = 0;
            CorrectWordsCounter = 0;
            WrongWordsCounter = 0;
            WrongStrokes = 0;
            CorrectStrokes = 0;

            //_timeRemainingForSeconds = TimeSpan.FromSeconds(0);//
            tbLiveWPM.Text = "";

            SetFirstWordColor();

            rtbWords.Select(0, 1);
            rtbWords.ScrollToCaret();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            tbType.Select();

            RestartWords();
            SetFirstWordColor();
            rtbWords.ForeColor = DefaultWordsColor;
            btn15.BackColor = SelectColor;
            btnTime.BackColor = SelectColor;

            rtbCorrectWords.SelectAll();
            rtbCorrectWords.SelectionAlignment = HorizontalAlignment.Right;

            rtbWrongWords.SelectAll();
            rtbWrongWords.SelectionAlignment = HorizontalAlignment.Right;

            rtbKeyStrokes.SelectAll();
            rtbKeyStrokes.SelectionAlignment = HorizontalAlignment.Right;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            tbTimer.BackColor = this.BackColor;

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                e.SuppressKeyPress = true;
                this.Close(); 
            }
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
            if (CurrentWordCounter >= NumberOfWords)
            {
                IsStartedTimeMode = false;
                IsStartedWordsMode = false;

                tbType.ReadOnly = true;

                TimerForSeconds.Stop();
                TimerForWords.Stop();
                return true;
            }
            else
            {
                return false;
            }

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

        

        private void DealWithCounters()
        {
            if (tbType.Text == CurrentWords[CurrentWordCounter])
            {
                CorrectWordsCounter++;

                CorrectStrokes += CurrentWords[CurrentWordCounter].Length+ (" ".Length);
            }
            else
            {
                WrongWordsCounter++;

                WrongStrokes += CurrentWords[CurrentWordCounter].Length;
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbType.Text == " " || tbType.Text == "")
            {
                rtbWords.SelectionBackColor = Color.White;
                tbType.Text = "";
                return;
            }

            

            if (Mode == enMode.Time)
            {
                IsStartedTimeMode = true;
                TimerForSeconds.Start();
                tbTimer.Text = _timeRemainingForSeconds.ToString(@"mm\:ss"); 
            }
            else
            {
                IsStartedWordsMode = true;
                TimerForWords.Start();
                tbTimer.Text = _TimeCounterForWords.ToString(@"mm\:ss");
            }

            CheckEachCharInCurrentWord();

            if (IsWordTypingFinished())
            {
                tbType.Text = tbType.Text.Trim();

                DealWithCounters();

                SetPrevWordColor();

                rtbWords.SelectionBackColor = Color.White;

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
                    return;
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
            if (CurrentWordCounter < NumberOfWords)
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
            if(Mode == enMode.Time)
            {
                IsStartedTimeMode = false;
                TimerForSeconds.Stop();
                _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);
                tbTimer.Text = "";
            }
            else
            {
                IsStartedWordsMode = false;
                TimerForWords.Stop();
                _TimeCounterForWords = TimeSpan.FromSeconds(0);
                tbTimer.Text = "";
            }

        }

        private void UpdateTimerDisplay()
        {
            if(Mode == enMode.Time)
            { 
                tbTimer.Text = _timeRemainingForSeconds.ToString(@"mm\:ss");
            }
            else
            {
                tbTimer.Text = _TimeCounterForWords.ToString(@"mm\:ss");
            }
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

            richTextBox1.Text = Convert.ToInt16(CalcWPM()).ToString() + "\nWPM";

            SetKeyStrokesColors();
        }

        private void TimerForSeconds_Tick(object sender, EventArgs e)
        {
            if(IsStartedTimeMode && Mode == enMode.Time)
            {
                 _timeRemainingForSeconds = _timeRemainingForSeconds.Subtract(TimeSpan.FromSeconds(1));

                _TimeCounterForWords = _TimeCounterForWords.Add(TimeSpan.FromSeconds(1));

                UpdateTimerDisplay();

                if (_timeRemainingForSeconds <= TimeSpan.Zero)
                {
                    IsStartedTimeMode = false;
                    tbType.ReadOnly = true;
                    ShowResults();
                    ResetTimer();
                    tbLiveWPM.Text = "";
                    return;
                }

                tbLiveWPM.Text = Convert.ToInt16(CalcLiveWPM()).ToString();

            }
        }

        private void ResetTest()
        {

        }

        private void EndTest()
        {

        }

        private void TimerForWords_Tick(object sender, EventArgs e)
        {

            if (IsStartedWordsMode && Mode == enMode.Words)
            {
                _TimeCounterForWords = _TimeCounterForWords.Add(TimeSpan.FromSeconds(1));

                UpdateTimerDisplay();

                if( CurrentWordCounter >= NumberOfWords)
                {
                    IsStartedWordsMode = false;
                    tbType.ReadOnly = true;
                    ShowResults();
                    ResetTimer();
                }

                tbLiveWPM.Text = Convert.ToInt16(CalcLiveWPM()).ToString();

            }
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            Mode = enMode.Time;

            TimerForSeconds.Stop();
            TimerForWords.Stop();

            NumberOfSeconds = Convert.ToInt16(btn.Text);
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

            btn15.BackColor = btn30.BackColor = btn60.BackColor = btn120.BackColor = Color.Gainsboro;
            btn10.BackColor = btn25.BackColor = btn50.BackColor = btn100.BackColor = Color.Gainsboro;

            btn.BackColor = SelectColor;
        }

        private void ChangeNumberOfWords(Button btn)
        {
            Mode = enMode.Words;

            TimerForWords.Stop();
            TimerForSeconds.Stop();
            
            groupBox1.Hide();
            tbType.ReadOnly = false;

            ResetTimer();

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
            groupBox1.Visible = false;

            tbType.ReadOnly = false;

            tbLiveWPM.Text = "";

            _TimeCounterForWords = TimeSpan.FromSeconds(0);
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

            if (Mode == enMode.Words)
            {
                TimerForWords.Stop();

                NumberOfWords = 80;
                CurrentWords = new string[NumberOfWords];

                RestartWords();

                Mode = enMode.Time;

                HideWordsButtons();
                ShowSecondsButtons();

                ChangeNumberOfSeconds(btn15);

                btnTime.BackColor = SelectColor;
                btnWords.BackColor = Color.White;
            }
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;

            tbType.ReadOnly = false;

            tbLiveWPM.Text = "";

            _TimeCounterForWords = TimeSpan.FromSeconds(0);
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

            if (Mode == enMode.Time)
            {
                TimerForSeconds.Stop();

                Mode = enMode.Words;

                HideSecondsButtons();
                ShowWordsButtons();

                ChangeNumberOfWords(btn10);

                btnWords.BackColor = SelectColor;
                btnTime.BackColor = Color.White;
            }
        }

        private double CalcWPM()
        {
            double timeInSeconds = (Mode == enMode.Words) ? _TimeCounterForWords.TotalSeconds : NumberOfSeconds;
            //double timeInSeconds = _TimeCounterForWords.TotalSeconds;

            // Ensure we don't divide by zero if no time has passed.
            if (timeInSeconds <= 0)
            {
                return 0.0;
            }

            double words = CorrectStrokes / 5.0; // Use 5.0 to ensure floating-point division

            double timeInMinutes = timeInSeconds / 60.0; // Use 60.0 for floating-point division

            // Calculate WPM: Words / Time in Minutes.
            return words / timeInMinutes;

        }

        private double CalcLiveWPM()
        {
            double timeInSeconds = (Mode == enMode.Words) ? _TimeCounterForWords.TotalSeconds : (NumberOfSeconds-_timeRemainingForSeconds.TotalSeconds);
            //double timeInSeconds = _TimeCounterForWords.TotalSeconds;

            // Ensure we don't divide by zero if no time has passed.
            if (timeInSeconds <= 0)
            {
                return 0.0;
            }

            double words = CorrectStrokes / 5.0; // Use 5.0 to ensure floating-point division

            double timeInMinutes = timeInSeconds / 60.0; // Use 60.0 for floating-point division

            // Calculate WPM: Words / Time in Minutes.
            return words / timeInMinutes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\typingfingersposition.png");
        }

        private void tbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true; // Prevent the default Backspace behavior (inserting space)

                tbType.Text = "";
            }
        }
    }
}
