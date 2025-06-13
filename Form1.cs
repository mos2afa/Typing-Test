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

namespace Typing_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        short CurrentWordCounter = 0;

        short CorrectWordsCounter = 0;
        short WrongWordsCounter = 0;

        static string AllWords = "about|above|add|after|again|air|all|almost|along|also|always|America|an|and|animal|another|answer|any|are|around|as|ask|at|away|back|be|because|been|before|began|begin|being|below|between|big|book|both|boy|but|by|call|came|can|car|carry|change|children|city|close|come|could|country|cut|day|did|different|do|does|don't|down|each|earth|eat|end|enough|even|every|example|eye|face|family|far|father|feet|few|find|first|follow|food|for|form|found|four|from|get|girl|give|go|good|got|great|group|grow|had|hand|hard|has|have|he|head|hear|help|her|here|high|him|his|home|house|how|idea|if|important|in|Indian|into|is|it|its|it's|just|keep|kind|know|land|large|last|later|learn|leave|left|let|letter|life|light|like|line|list|little|live|long|look|made|make|man|many|may|me|mean|men|might|mile|miss|more|most|mother|mountain|move|much|must|my|name|near|need|never|new|next|night|no|not|now|number|of|off|often|oil|old|on|once|one|only|open|or|other|our|out|over|own|page|paper|part|people|picture|place|plant|play|point|put|question|quick|quickly|quite|read|really|right|river|run|said|same|saw|say|school|sea|second|see|seem|sentence|set|she|should|show|side|small|so|some|something|sometimes|song|soon|sound|spell|start|state|still|stop|story|study|such|take|talk|tell|than|that|the|their|them|then|there|these|they|thing|think|this|those|thought|three|through|time|to|together|too|took|tree|try|turn|two|under|until|up|us|use|very|walk|want|was|watch|water|way|we|well|went|were|what|when|where|which|while|white|who|why|will|with|without|word|work|world|would|write|year|you|young|your";
        // 302 words

        string[] word = AllWords.Split('|');

        Random rndWord = new Random();

        static short NumberOfWords = 25;

        string[] CurrentWords = new string[NumberOfWords];

        bool IsTestFinished = false;

        private bool IsCurrentWordTypedTrue()
        {
            if (tbType.Text == "")
                return false;

            if (tbType.Text == CurrentWords[CurrentWordCounter])
            { 
                return true;
            }

            return false;
        }


        private void RestartWords()
        {
            string TempText = "";

            rtbWords.SelectAll();
            rtbWords.SelectionColor = Color.Black;

            for (int i = 0; i < NumberOfWords; i++)
            {
                int rndNUM = rndWord.Next(0, 300);

                CurrentWords[i] = word[rndNUM];
                TempText += word[rndNUM];
                TempText += " ";
            }

            rtbWords.Text = TempText;
            tbType.Text = "";

            IsTestFinished = false;
            tbType.Enabled = true;
            tbType.Focus();

            CurrentWordCounter = 0;
            CorrectWordsCounter = 0;
            WrongWordsCounter = 0;

            SetNextWordColor(Color.Purple);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            tbType.Select();

            RestartWords();
            SetNextWordColor(Color.Purple);

        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartWords();
            
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbType.Text == " ")
            {
                tbType.Text = "";
                return;
            }


            // if all words are typed.
            if (CurrentWordCounter == NumberOfWords)
            {
                IsTestFinished = true;
                tbType.Enabled = false;
                return;
            }

            if (tbType.Text.EndsWith(" "))
            {
                tbType.Text = tbType.Text.Trim();
                if (IsCurrentWordTypedTrue())
                {
                    CorrectWordsCounter++;
                    lbCorrectWordsCounter.Text = CorrectWordsCounter.ToString();
                }
                else
                {
                    WrongWordsCounter++;
                    lbWrongWordsCounter.Text = WrongWordsCounter.ToString();
                }

                SetCurrentWordColor();

                CurrentWordCounter++;
                SetNextWordColor(Color.Purple);

                tbType.Text = "";

            }
        }

        int FirstCharOfWord = 0;
        int LastCharOfWord = 0;
        int WordLength = 0;
        private void SetNextWordColor(Color color)
        {

            if (CurrentWordCounter == NumberOfWords) return;

            if(CurrentWordCounter == 0)
            {
                FirstCharOfWord = 0;
                LastCharOfWord = CurrentWords[CurrentWordCounter].Length;
                WordLength = CurrentWords[CurrentWordCounter].Length;
            }
            else
            {
                FirstCharOfWord = LastCharOfWord + 1;
                WordLength = CurrentWords[CurrentWordCounter].Length;
                LastCharOfWord = FirstCharOfWord + WordLength;
            }


            rtbWords.Select(FirstCharOfWord, WordLength);
            rtbWords.SelectionColor = color;

        }

        private void SetCurrentWordColor()
        {
            if(tbType.Text == CurrentWords[CurrentWordCounter])
            {
                rtbWords.Select(FirstCharOfWord, WordLength);
                rtbWords.SelectionColor = Color.Green;
            }
            else
            {
                rtbWords.Select(FirstCharOfWord, WordLength);
                rtbWords.SelectionColor = Color.FromArgb(235,22,22);
                //rtbWords.SelectionColor = Color.Red;

            }
        }
    }
}
