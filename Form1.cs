using System;
using System.Drawing;
using System.Windows.Forms;
using Typing_Test.Properties;
//using System.Text.Json;


namespace Typing_Test
{
   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public string JsonSettings;

        short CurrentWordCounter = 1;

        short CorrectWordsCounter = 0;
        short WrongWordsCounter = 0;

        int CorrectStrokes = 0;
        int WrongStrokes = 0;

        static string AllWords10FastFingers = "about|above|add|after|again|air|all|almost|along|also|always|America|an|and|animal|another|answer|any|are|around|as|ask|at|away|back|be|because|been|before|began|begin|being|below|between|big|book|both|boy|but|by|call|came|can|car|carry|change|children|city|close|come|could|country|cut|day|did|different|do|does|don't|down|each|earth|eat|end|enough|even|every|example|eye|face|family|far|father|feet|few|find|first|follow|food|for|form|found|four|from|get|girl|give|go|good|got|great|group|grow|had|hand|hard|has|have|he|head|hear|help|her|here|high|him|his|home|house|how|idea|if|important|in|Indian|into|is|it|its|it's|just|keep|kind|know|land|large|last|later|learn|leave|left|let|letter|life|light|like|line|list|little|live|long|look|made|make|man|many|may|me|mean|men|might|mile|miss|more|most|mother|mountain|move|much|must|my|name|near|need|never|new|next|night|no|not|now|number|of|off|often|oil|old|on|once|one|only|open|or|other|our|out|over|own|page|paper|part|people|picture|place|plant|play|point|put|question|quick|quickly|quite|read|really|right|river|run|said|same|saw|say|school|sea|second|see|seem|sentence|set|she|should|show|side|small|so|some|something|sometimes|song|soon|sound|spell|start|state|still|stop|story|study|such|take|talk|tell|than|that|the|their|them|then|there|these|they|thing|think|this|those|thought|three|through|time|to|together|too|took|tree|try|turn|two|under|until|up|us|use|very|walk|want|was|watch|water|way|we|well|went|were|what|when|where|which|while|white|who|why|will|with|without|word|work|world|would|write|year|you|young|your";
        // 302 words

        static string AllWordsMonkeyType = "a about and any as ask at back be but by can come do down end few find for go group have he help home house how if in into it large last late lead life line man many may more move new no not now of on one open or other out own part plan play point real run same say set she so some take the this those time to turn up use want we what who with work you against also another before begin both change child could course day each early face form from get give great hand hold just know leave like long make mean might most most must number old only over person place right should show since stand such than then they thing think very way when while word would write year again all call even eye fact feel good here high increase keep nation off order see seem small still tell that these too well where which will without after because become between consider develop during first follow general however interest little look need never people present problem program public school state system there through under world";
        // 196 words

        string[] word = AllWords10FastFingers.Split('|');

        static short NumberOfSeconds = 15;

        static short NumberOfWords = 1000;

        string[] CurrentWords = new string[NumberOfWords];

        Random rndWord = new Random();

        bool IsStartedTimeMode = true;
        bool IsStartedWordsMode = true;

        private TimeSpan _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

        private TimeSpan _TimeCounterForWords = TimeSpan.FromSeconds(0);

        Color CurrentWordColor = Color.DodgerBlue;
        Color CorrectWordColor = Color.Green;
        Color WrongWordColor   = Color.Red;
        Color SelectColor      = Color.DodgerBlue;

        enum enMode {Words,Time };

        enMode Mode = enMode.Time;



        private void Form1_Load(object sender, EventArgs e)
        {
            tbType.Select();

            this.BackColor = Color.FromArgb(1, 2, 26);
            rtbWords.BackColor = this.BackColor;
            rtbWords.ForeColor = Color.FromArgb(60, 77, 120);

            Restart();
            SetFirstWordColor();

            rtbWords.BringToFront();

            btn15.BackColor = SelectColor;
            btnTime.BackColor = SelectColor;

            rtbFinalWPM.BackColor = this.BackColor;
            richTextBox2.BackColor = this.BackColor;
            tbTimer.BackColor = this.BackColor;
            tbLiveWPM.BackColor = this.BackColor;

            rtbCorrectWords.SelectAll();
            rtbCorrectWords.SelectionAlignment = HorizontalAlignment.Right;

            rtbWrongWords.SelectAll();
            rtbWrongWords.SelectionAlignment = HorizontalAlignment.Right;

            rtbKeyStrokes.SelectAll();
            rtbKeyStrokes.SelectionAlignment = HorizontalAlignment.Right;

            rtbAccuracy.SelectAll();
            rtbAccuracy.SelectionAlignment = HorizontalAlignment.Right;

            rtbFinalWPM.SelectAll();
            rtbFinalWPM.SelectionAlignment = HorizontalAlignment.Center;

            cbWhichWords.SelectedIndex = 0;
        }


        private bool CheckCurrentWordTypedTrue()
        {
            return tbType.Text == CurrentWords[CurrentWordCounter];
        }

        private void FillWords()
        {
            string TempText = "";

            if (cbWhichWords.SelectedIndex == 0) word = AllWords10FastFingers.Split('|');

            if (cbWhichWords.SelectedIndex == 1) word = AllWordsMonkeyType.Split(' ');

            for (int i = 0; i < NumberOfWords; i++)
            {
                int rndNUM = rndWord.Next(0, word.Length);

                CurrentWords[i] = word[rndNUM];
                TempText += word[rndNUM];
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

            tbType.Enabled = true;
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


        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                e.SuppressKeyPress = true;
                this.Close(); 
            }

            if (e.Control && e.KeyCode == Keys.F)
            {
                e.SuppressKeyPress = true;

                ToggleFullScreen();
            }

            if (e.KeyCode == Keys.Escape)
            {
                ToggleSettingsVisibility();
            }

        }

        private void ToggleFullScreen()
        {

            if (this.FormBorderStyle == FormBorderStyle.Fixed3D)
            {
                this.WindowState = FormWindowState.Normal; // If this line be removed, there would be a glitch.
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                rtbWords.ZoomFactor += 0.25f;
                return;
            }

            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                rtbWords.ZoomFactor -= 0.25f;
                return;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                rtbWords.ZoomFactor = 2f;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                rtbWords.ZoomFactor = 1.45f;
            }
        }

        private void SetFirstWordColor()
        {
            IndexOfFirstCharOfCurrentWord = 0;
            rtbWords.Select(IndexOfFirstCharOfCurrentWord, CurrentWords[0].Length );
            rtbWords.SelectionColor = CurrentWordColor;
        }

        private void Restart()
        {
            RestartWords();
            ResetTimer();
            groupBox1.Visible = false;
            tbType.ReadOnly = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (IsSettingOpened) return;

            Restart();
        }

        private void EndTheTest()
        {
            IsStartedTimeMode = false;
            IsStartedWordsMode = false;

            tbType.ReadOnly = true;

            TimerForSeconds.Stop();
            TimerForWords.Stop();
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

                CorrectStrokes += CurrentWords[CurrentWordCounter].Length+ 1;
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
                rtbWords.SelectionBackColor = rtbWords.BackColor;
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

                rtbWords.SelectionBackColor = rtbWords.BackColor;

                UpdateIndexOfFirstCharOfCurrentWord();

                CurrentWordCounter++;

                SetCurrentWordColor();

                rtbWords.ScrollToCaret();

                tbType.Text = "";

                if (AreAllWordsTyped())
                {
                    EndTheTest();
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
            }
            else
            {
                IsStartedWordsMode = false;
                TimerForWords.Stop();
                _TimeCounterForWords = TimeSpan.FromSeconds(0);
            }

            tbTimer.Text = "";
            tbLiveWPM.Text = "";

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
            rtbKeyStrokes.Text = "(" + CorrectStrokes + " | " + WrongStrokes + ")  " + (CorrectStrokes + WrongStrokes);

            rtbKeyStrokes.Select(1, CorrectStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Green;

            rtbKeyStrokes.Select(1 + CorrectStrokes.ToString().Length + 3, WrongStrokes.ToString().Length);
            rtbKeyStrokes.SelectionColor = Color.Red;
        }

        private void ShowResults()
        {
            groupBox1.BringToFront();
            groupBox1.Visible = true;

            rtbCorrectWords.Text = CorrectWordsCounter.ToString();
            rtbWrongWords.Text = WrongWordsCounter.ToString();
            rtbAccuracy.Text = (Convert.ToInt16((Convert.ToDouble(CorrectStrokes) / (CorrectStrokes+WrongStrokes)) * 100)).ToString() + "%";

            rtbFinalWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

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

                tbLiveWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

            }
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

                tbLiveWPM.Text = Convert.ToInt16(CalcWPM()).ToString();

            }
        }

        private void ChangeNumberOfSeconds(Button btn)
        {
            Mode = enMode.Time;

            TimerForSeconds.Stop();
            TimerForWords.Stop();

            RestartWords();

            tbTimer.Text = "";
            tbLiveWPM.Text = "";

            groupBox1.Hide();
            tbType.ReadOnly = false;

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

        private void BringToFrontWordButtons()
        {
            btn10.BringToFront();
            btn25.BringToFront();
            btn50.BringToFront();
            btn100.BringToFront();
        }

        private void BringToFrontTimeButtons()
        {
            btn15.BringToFront();
            btn30.BringToFront();
            btn60.BringToFront();
            btn120.BringToFront();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            btnTime.BackColor = SelectColor;
            btnWords.BackColor = Color.White;

            groupBox1.Visible = false;

            tbType.ReadOnly = false;

            tbLiveWPM.Text = "";

            _TimeCounterForWords = TimeSpan.FromSeconds(0);
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

            if (Mode == enMode.Words)
            {
                TimerForWords.Stop();

                NumberOfWords = 1000;
                CurrentWords = new string[NumberOfWords];

                RestartWords();

                Mode = enMode.Time;

                BringToFrontTimeButtons();

                ChangeNumberOfSeconds(btn15);
            }
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            btnWords.BackColor = SelectColor;
            btnTime.BackColor = Color.White;

            groupBox1.Visible = false;

            tbType.ReadOnly = false;

            tbLiveWPM.Text = "";

            _TimeCounterForWords = TimeSpan.FromSeconds(0);
            _timeRemainingForSeconds = TimeSpan.FromSeconds(NumberOfSeconds);

            if (Mode == enMode.Time)
            {
                TimerForSeconds.Stop();

                Mode = enMode.Words;

                BringToFrontWordButtons();

                ChangeNumberOfWords(btn10);
            }
        }

        private double CalcWPM()
        {
            double timeInSeconds = ((Mode == enMode.Words) ? (_TimeCounterForWords.TotalSeconds) : (!IsStartedTimeMode?NumberOfSeconds: NumberOfSeconds - _timeRemainingForSeconds.TotalSeconds));

            if (timeInSeconds <= 0)
            {
                return 0.0;
            }

            double words = CorrectStrokes / 5.0; 

            double timeInMinutes = timeInSeconds / 60.0; 

            // Calculate WPM: Words / Time in Minutes.
            return words / timeInMinutes;
        }



        private void tbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true; // Prevent the default Backspace behavior (inserting space)

                tbType.Text = "";
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {     
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ContextMenuStrip cms = (ContextMenuStrip)sender;
                cms.SourceControl.BackColor = colorDialog1.Color;
            }
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            tbLiveWPM.BackColor = this.BackColor;
            tbTimer.BackColor = this.BackColor;
            rtbWords.BackColor = this.BackColor;
            rtbFinalWPM.BackColor = this.BackColor;
            richTextBox2.BackColor = this.BackColor;
        }

        public bool IsSettingOpened = false;

        private void ToggleSettingsVisibility()
        {
            if (!IsSettingOpened)
            {
                gbSetting.BringToFront();
                IsSettingOpened = true;
                tbType.ReadOnly = true;
            }
            else
            {
                gbSetting.SendToBack();
                IsSettingOpened = false;
                tbType.ReadOnly = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Restart();

            ToggleSettingsVisibility();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbWords.ForeColor = colorDialog1.Color;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentWordColor = colorDialog1.Color;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CorrectWordColor = colorDialog1.Color;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                WrongWordColor = colorDialog1.Color;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tbType.ForeColor = colorDialog1.Color;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Control.IsKeyLocked(Keys.CapsLock))
            {
                rtbCapsLock.Visible = true;
            }
            else
            {
                rtbCapsLock.Visible = false;
            }
        }
    }
}
