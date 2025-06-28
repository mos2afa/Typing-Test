namespace Typing_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbWords = new System.Windows.Forms.RichTextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn25 = new System.Windows.Forms.Button();
            this.btn50 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.TimerForSeconds = new System.Windows.Forms.Timer(this.components);
            this.btn15 = new System.Windows.Forms.Button();
            this.btn30 = new System.Windows.Forms.Button();
            this.btn60 = new System.Windows.Forms.Button();
            this.btn120 = new System.Windows.Forms.Button();
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbKeyStrokes = new System.Windows.Forms.RichTextBox();
            this.rtbCorrectWords = new System.Windows.Forms.RichTextBox();
            this.rtbWrongWords = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TimerForWords = new System.Windows.Forms.Timer(this.components);
            this.btnTime = new System.Windows.Forms.Button();
            this.btnWords = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.tbLiveWPM = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbWords
            // 
            this.rtbWords.BackColor = System.Drawing.Color.White;
            this.rtbWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 37F);
            this.rtbWords.ForeColor = System.Drawing.Color.Black;
            this.rtbWords.Location = new System.Drawing.Point(13, 60);
            this.rtbWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.ReadOnly = true;
            this.rtbWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbWords.Size = new System.Drawing.Size(981, 425);
            this.rtbWords.TabIndex = 6;
            this.rtbWords.TabStop = false;
            this.rtbWords.Text = "";
            // 
            // tbType
            // 
            this.tbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbType.ForeColor = System.Drawing.Color.Black;
            this.tbType.Location = new System.Drawing.Point(13, 505);
            this.tbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(901, 61);
            this.tbType.TabIndex = 0;
            this.tbType.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbType_KeyDown);
            // 
            // btn10
            // 
            this.btn10.BackColor = System.Drawing.Color.Gainsboro;
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(746, 7);
            this.btn10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(60, 41);
            this.btn10.TabIndex = 8;
            this.btn10.TabStop = false;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn25
            // 
            this.btn25.BackColor = System.Drawing.Color.Gainsboro;
            this.btn25.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn25.Location = new System.Drawing.Point(806, 7);
            this.btn25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn25.Name = "btn25";
            this.btn25.Size = new System.Drawing.Size(60, 41);
            this.btn25.TabIndex = 9;
            this.btn25.TabStop = false;
            this.btn25.Text = "25";
            this.btn25.UseVisualStyleBackColor = false;
            this.btn25.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn50
            // 
            this.btn50.BackColor = System.Drawing.Color.Gainsboro;
            this.btn50.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn50.Location = new System.Drawing.Point(866, 7);
            this.btn50.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(60, 41);
            this.btn50.TabIndex = 10;
            this.btn50.TabStop = false;
            this.btn50.Text = "50";
            this.btn50.UseVisualStyleBackColor = false;
            this.btn50.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn100
            // 
            this.btn100.BackColor = System.Drawing.Color.Gainsboro;
            this.btn100.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn100.Location = new System.Drawing.Point(926, 7);
            this.btn100.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(68, 41);
            this.btn100.TabIndex = 11;
            this.btn100.TabStop = false;
            this.btn100.Text = "100";
            this.btn100.UseVisualStyleBackColor = false;
            this.btn100.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // TimerForSeconds
            // 
            this.TimerForSeconds.Interval = 1000;
            this.TimerForSeconds.Tick += new System.EventHandler(this.TimerForSeconds_Tick);
            // 
            // btn15
            // 
            this.btn15.BackColor = System.Drawing.Color.Gainsboro;
            this.btn15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(746, 7);
            this.btn15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(60, 41);
            this.btn15.TabIndex = 14;
            this.btn15.TabStop = false;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = false;
            this.btn15.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn30
            // 
            this.btn30.BackColor = System.Drawing.Color.Gainsboro;
            this.btn30.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn30.Location = new System.Drawing.Point(806, 7);
            this.btn30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn30.Name = "btn30";
            this.btn30.Size = new System.Drawing.Size(60, 41);
            this.btn30.TabIndex = 15;
            this.btn30.TabStop = false;
            this.btn30.Text = "30";
            this.btn30.UseVisualStyleBackColor = false;
            this.btn30.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn60
            // 
            this.btn60.BackColor = System.Drawing.Color.Gainsboro;
            this.btn60.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn60.Location = new System.Drawing.Point(866, 7);
            this.btn60.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn60.Name = "btn60";
            this.btn60.Size = new System.Drawing.Size(60, 41);
            this.btn60.TabIndex = 16;
            this.btn60.TabStop = false;
            this.btn60.Text = "60";
            this.btn60.UseVisualStyleBackColor = false;
            this.btn60.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn120
            // 
            this.btn120.BackColor = System.Drawing.Color.Gainsboro;
            this.btn120.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn120.Location = new System.Drawing.Point(926, 7);
            this.btn120.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn120.Name = "btn120";
            this.btn120.Size = new System.Drawing.Size(68, 41);
            this.btn120.TabIndex = 17;
            this.btn120.TabStop = false;
            this.btn120.Text = "120";
            this.btn120.UseVisualStyleBackColor = false;
            this.btn120.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // tbTimer
            // 
            this.tbTimer.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimer.Location = new System.Drawing.Point(12, 7);
            this.tbTimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTimer.Multiline = true;
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.ReadOnly = true;
            this.tbTimer.Size = new System.Drawing.Size(157, 47);
            this.tbTimer.TabIndex = 18;
            this.tbTimer.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Keystrokes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Correct words";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Wrong words";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbKeyStrokes);
            this.groupBox1.Controls.Add(this.rtbCorrectWords);
            this.groupBox1.Controls.Add(this.rtbWrongWords);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1031, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(359, 507);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rtbKeyStrokes
            // 
            this.rtbKeyStrokes.BackColor = System.Drawing.Color.White;
            this.rtbKeyStrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbKeyStrokes.ForeColor = System.Drawing.Color.Black;
            this.rtbKeyStrokes.Location = new System.Drawing.Point(160, 257);
            this.rtbKeyStrokes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbKeyStrokes.Name = "rtbKeyStrokes";
            this.rtbKeyStrokes.ReadOnly = true;
            this.rtbKeyStrokes.Size = new System.Drawing.Size(177, 30);
            this.rtbKeyStrokes.TabIndex = 29;
            this.rtbKeyStrokes.Text = "";
            // 
            // rtbCorrectWords
            // 
            this.rtbCorrectWords.BackColor = System.Drawing.Color.White;
            this.rtbCorrectWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCorrectWords.ForeColor = System.Drawing.Color.Green;
            this.rtbCorrectWords.Location = new System.Drawing.Point(160, 308);
            this.rtbCorrectWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbCorrectWords.Name = "rtbCorrectWords";
            this.rtbCorrectWords.ReadOnly = true;
            this.rtbCorrectWords.Size = new System.Drawing.Size(177, 30);
            this.rtbCorrectWords.TabIndex = 28;
            this.rtbCorrectWords.Text = "";
            // 
            // rtbWrongWords
            // 
            this.rtbWrongWords.BackColor = System.Drawing.Color.White;
            this.rtbWrongWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWrongWords.ForeColor = System.Drawing.Color.Red;
            this.rtbWrongWords.Location = new System.Drawing.Point(160, 354);
            this.rtbWrongWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbWrongWords.Name = "rtbWrongWords";
            this.rtbWrongWords.ReadOnly = true;
            this.rtbWrongWords.Size = new System.Drawing.Size(177, 30);
            this.rtbWrongWords.TabIndex = 27;
            this.rtbWrongWords.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.DeepPink;
            this.richTextBox1.Location = new System.Drawing.Point(11, 21);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(327, 156);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // TimerForWords
            // 
            this.TimerForWords.Interval = 1000;
            this.TimerForWords.Tick += new System.EventHandler(this.TimerForWords_Tick);
            // 
            // btnTime
            // 
            this.btnTime.BackColor = System.Drawing.Color.White;
            this.btnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTime.Location = new System.Drawing.Point(518, 7);
            this.btnTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(101, 41);
            this.btnTime.TabIndex = 24;
            this.btnTime.TabStop = false;
            this.btnTime.Text = "time";
            this.btnTime.UseVisualStyleBackColor = false;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnWords
            // 
            this.btnWords.BackColor = System.Drawing.Color.White;
            this.btnWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWords.Location = new System.Drawing.Point(626, 7);
            this.btnWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWords.Name = "btnWords";
            this.btnWords.Size = new System.Drawing.Size(101, 41);
            this.btnWords.TabIndex = 25;
            this.btnWords.TabStop = false;
            this.btnWords.Text = "words";
            this.btnWords.UseVisualStyleBackColor = false;
            this.btnWords.Click += new System.EventHandler(this.btnWords_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::Typing_Test.Properties.Resources.Restart;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestart.Location = new System.Drawing.Point(919, 505);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 62);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // tbLiveWPM
            // 
            this.tbLiveWPM.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbLiveWPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLiveWPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLiveWPM.Location = new System.Drawing.Point(175, 7);
            this.tbLiveWPM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLiveWPM.Multiline = true;
            this.tbLiveWPM.Name = "tbLiveWPM";
            this.tbLiveWPM.ReadOnly = true;
            this.tbLiveWPM.Size = new System.Drawing.Size(157, 47);
            this.tbLiveWPM.TabIndex = 26;
            this.tbLiveWPM.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(292, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 41);
            this.button1.TabIndex = 27;
            this.button1.TabStop = false;
            this.button1.Text = "Fingers position";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1488, 642);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbLiveWPM);
            this.Controls.Add(this.btnWords);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.btn120);
            this.Controls.Add(this.btn60);
            this.Controls.Add(this.btn30);
            this.Controls.Add(this.btn15);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn25);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.rtbWords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Typing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnRestart;
        public System.Windows.Forms.RichTextBox rtbWords;
        public System.Windows.Forms.TextBox tbType;
        public System.Windows.Forms.Button btn10;
        public System.Windows.Forms.Button btn25;
        public System.Windows.Forms.Button btn50;
        public System.Windows.Forms.Button btn100;
        public System.Windows.Forms.Timer TimerForSeconds;
        public System.Windows.Forms.Button btn15;
        public System.Windows.Forms.Button btn30;
        public System.Windows.Forms.Button btn60;
        public System.Windows.Forms.Button btn120;
        public System.Windows.Forms.TextBox tbTimer;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Timer TimerForWords;
        public System.Windows.Forms.Button btnTime;
        public System.Windows.Forms.Button btnWords;
        public System.Windows.Forms.RichTextBox rtbKeyStrokes;
        public System.Windows.Forms.RichTextBox rtbCorrectWords;
        public System.Windows.Forms.RichTextBox rtbWrongWords;
        public System.Windows.Forms.TextBox tbLiveWPM;
        private System.Windows.Forms.Button button1;
    }
}

