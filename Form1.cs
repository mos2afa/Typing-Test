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

        short NumberOfSeconds = 60;

        Random rndWord = new Random();

        bool IsStarted = true;

        private TimeSpan _timeRemaining = TimeSpan.FromMinutes(1);

        Color CurrentWordColor = Color.Purple;
        Color CorrectWordColor = Color.Green;
        Color WrongWordColor = Color.Red;
        Color DefaultWordsColor = Color.Black;


        private bool CheckCurrentWordTypedTrue()
        {
            if (tbType.Text == CurrentWords[CurrentWordCounter])
            { 
                return true;
            }
            else
            {
                return false;
            }

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
            timer1.Stop();

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

            tbTimer.Text = TimeSpan.FromSeconds(NumberOfSeconds).ToString(@"mm\:ss");

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
        }

        private bool AreAllWordsTyped()
        {
            if (CurrentWordCounter == NumberOfWords)
            {
                IsStarted = false;
                tbType.Enabled = false;
                timer1.Stop();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbType.Text == " ")
            {
                tbType.Text = "";
                return;
            }
            
            IsStarted = true;

            timer1.Start();

            if (AreAllWordsTyped()) return;

            if (IsWordTypingFinished())
            {
                tbType.Text = tbType.Text.Trim();

                SetPrevWordColor();

                UpdateIndexOfFirstCharOfCurrentWord();

                CurrentWordCounter++;

                SetCurrentWordColor();

                tbType.Text = "";
            }

        }


        int IndexOfFirstCharOfCurrentWord = 0;
        int LastCharOfCurrentWordIndex = 0;
        int WordLength = 0;
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

        private void btnPickTotalWords_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NumberOfWords = Convert.ToInt16(btn.Text);
            CurrentWords = new string[NumberOfWords];
            RestartWords();
        }


        private void ResetTimer()
        {
            timer1.Stop();
            _timeRemaining = TimeSpan.FromSeconds(NumberOfSeconds);
            tbTimer.Text = _timeRemaining.ToString(@"mm\:ss");
        }

        private void UpdateTimerDisplay()
        {
            tbTimer.Text = _timeRemaining.ToString(@"mm\:ss");
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(IsStarted)
            {
                _timeRemaining = _timeRemaining.Subtract(TimeSpan.FromSeconds(1));

                if (_timeRemaining <= TimeSpan.Zero)
                {
                    ResetTimer();
                }

                UpdateTimerDisplay();
            }

            
        }

        private void ChangeTimerSeconds(Button btn)
        {
            NumberOfSeconds = Convert.ToInt16(btn.Text);
            timer1.Stop();
            _timeRemaining = TimeSpan.FromSeconds(NumberOfSeconds);
            tbTimer.Text = _timeRemaining.ToString(@"mm\:ss");

        }

        private void btn120_Click(object sender, EventArgs e)
        {
            ChangeTimerSeconds((Button)sender);
        }



        // ********** Coming extensions **********:
        //
        //
        //
        //
        //
        //
        //
        //
        //
    }
}
