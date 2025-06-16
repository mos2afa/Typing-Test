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
            this.lbCorrectWordsCounter = new System.Windows.Forms.Label();
            this.lbWrongWordsCounter = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.rtbWords = new System.Windows.Forms.RichTextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn25 = new System.Windows.Forms.Button();
            this.btn50 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.TimerForSeconds = new System.Windows.Forms.Timer(this.components);
            this.tbWPM = new System.Windows.Forms.TextBox();
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
            this.tbWrongwords = new System.Windows.Forms.TextBox();
            this.tbCorrectwords = new System.Windows.Forms.TextBox();
            this.tbKeystrokes = new System.Windows.Forms.TextBox();
            this.TimerForWords = new System.Windows.Forms.Timer(this.components);
            this.btnTime = new System.Windows.Forms.Button();
            this.btnWords = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCorrectWordsCounter
            // 
            this.lbCorrectWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCorrectWordsCounter.Location = new System.Drawing.Point(1645, 21);
            this.lbCorrectWordsCounter.Name = "lbCorrectWordsCounter";
            this.lbCorrectWordsCounter.Size = new System.Drawing.Size(134, 70);
            this.lbCorrectWordsCounter.TabIndex = 2;
            // 
            // lbWrongWordsCounter
            // 
            this.lbWrongWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbWrongWordsCounter.Location = new System.Drawing.Point(1645, 105);
            this.lbWrongWordsCounter.Name = "lbWrongWordsCounter";
            this.lbWrongWordsCounter.Size = new System.Drawing.Size(134, 70);
            this.lbWrongWordsCounter.TabIndex = 3;
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::Typing_Test.Properties.Resources.Restart;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestart.Location = new System.Drawing.Point(1002, 536);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(74, 61);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // rtbWords
            // 
            this.rtbWords.BackColor = System.Drawing.Color.White;
            this.rtbWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWords.Location = new System.Drawing.Point(95, 78);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.ReadOnly = true;
            this.rtbWords.Size = new System.Drawing.Size(981, 425);
            this.rtbWords.TabIndex = 6;
            this.rtbWords.TabStop = false;
            this.rtbWords.Text = "";
            // 
            // tbType
            // 
            this.tbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbType.Location = new System.Drawing.Point(95, 536);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(725, 61);
            this.tbType.TabIndex = 0;
            this.tbType.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn10
            // 
            this.btn10.BackColor = System.Drawing.Color.Gainsboro;
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(543, 32);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(60, 34);
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
            this.btn25.Location = new System.Drawing.Point(603, 32);
            this.btn25.Name = "btn25";
            this.btn25.Size = new System.Drawing.Size(60, 34);
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
            this.btn50.Location = new System.Drawing.Point(663, 32);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(60, 34);
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
            this.btn100.Location = new System.Drawing.Point(723, 32);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(68, 34);
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
            // tbWPM
            // 
            this.tbWPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWPM.Location = new System.Drawing.Point(1632, 178);
            this.tbWPM.Multiline = true;
            this.tbWPM.Name = "tbWPM";
            this.tbWPM.ReadOnly = true;
            this.tbWPM.Size = new System.Drawing.Size(170, 60);
            this.tbWPM.TabIndex = 13;
            this.tbWPM.TabStop = false;
            // 
            // btn15
            // 
            this.btn15.BackColor = System.Drawing.Color.Gainsboro;
            this.btn15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(543, 32);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(60, 34);
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
            this.btn30.Location = new System.Drawing.Point(603, 32);
            this.btn30.Name = "btn30";
            this.btn30.Size = new System.Drawing.Size(60, 34);
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
            this.btn60.Location = new System.Drawing.Point(663, 32);
            this.btn60.Name = "btn60";
            this.btn60.Size = new System.Drawing.Size(60, 34);
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
            this.btn120.Location = new System.Drawing.Point(723, 32);
            this.btn120.Name = "btn120";
            this.btn120.Size = new System.Drawing.Size(68, 34);
            this.btn120.TabIndex = 17;
            this.btn120.TabStop = false;
            this.btn120.Text = "120";
            this.btn120.UseVisualStyleBackColor = false;
            this.btn120.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // tbTimer
            // 
            this.tbTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimer.Location = new System.Drawing.Point(95, 27);
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
            this.label1.Location = new System.Drawing.Point(6, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Keystrokes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Correct words";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 274);
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
            this.groupBox1.Location = new System.Drawing.Point(1109, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 417);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // rtbKeyStrokes
            // 
            this.rtbKeyStrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbKeyStrokes.Location = new System.Drawing.Point(160, 177);
            this.rtbKeyStrokes.Name = "rtbKeyStrokes";
            this.rtbKeyStrokes.ReadOnly = true;
            this.rtbKeyStrokes.Size = new System.Drawing.Size(177, 30);
            this.rtbKeyStrokes.TabIndex = 29;
            this.rtbKeyStrokes.Text = "";
            // 
            // rtbCorrectWords
            // 
            this.rtbCorrectWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCorrectWords.ForeColor = System.Drawing.Color.Green;
            this.rtbCorrectWords.Location = new System.Drawing.Point(160, 228);
            this.rtbCorrectWords.Name = "rtbCorrectWords";
            this.rtbCorrectWords.ReadOnly = true;
            this.rtbCorrectWords.Size = new System.Drawing.Size(177, 30);
            this.rtbCorrectWords.TabIndex = 28;
            this.rtbCorrectWords.Text = "";
            // 
            // rtbWrongWords
            // 
            this.rtbWrongWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWrongWords.ForeColor = System.Drawing.Color.Red;
            this.rtbWrongWords.Location = new System.Drawing.Point(160, 274);
            this.rtbWrongWords.Name = "rtbWrongWords";
            this.rtbWrongWords.ReadOnly = true;
            this.rtbWrongWords.Size = new System.Drawing.Size(177, 30);
            this.rtbWrongWords.TabIndex = 27;
            this.rtbWrongWords.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(56, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(234, 96);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            // 
            // tbWrongwords
            // 
            this.tbWrongwords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWrongwords.Location = new System.Drawing.Point(1588, 412);
            this.tbWrongwords.Name = "tbWrongwords";
            this.tbWrongwords.Size = new System.Drawing.Size(177, 30);
            this.tbWrongwords.TabIndex = 25;
            this.tbWrongwords.TabStop = false;
            this.tbWrongwords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCorrectwords
            // 
            this.tbCorrectwords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCorrectwords.Location = new System.Drawing.Point(1537, 360);
            this.tbCorrectwords.Name = "tbCorrectwords";
            this.tbCorrectwords.Size = new System.Drawing.Size(177, 30);
            this.tbCorrectwords.TabIndex = 24;
            this.tbCorrectwords.TabStop = false;
            this.tbCorrectwords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbKeystrokes
            // 
            this.tbKeystrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKeystrokes.Location = new System.Drawing.Point(1551, 311);
            this.tbKeystrokes.Name = "tbKeystrokes";
            this.tbKeystrokes.Size = new System.Drawing.Size(177, 30);
            this.tbKeystrokes.TabIndex = 23;
            this.tbKeystrokes.TabStop = false;
            this.tbKeystrokes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TimerForWords
            // 
            this.TimerForWords.Interval = 1000;
            this.TimerForWords.Tick += new System.EventHandler(this.TimerForWords_Tick);
            // 
            // btnTime
            // 
            this.btnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTime.Location = new System.Drawing.Point(305, 33);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(101, 41);
            this.btnTime.TabIndex = 24;
            this.btnTime.Text = "time";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnWords
            // 
            this.btnWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWords.Location = new System.Drawing.Point(412, 33);
            this.btnWords.Name = "btnWords";
            this.btnWords.Size = new System.Drawing.Size(101, 41);
            this.btnWords.TabIndex = 25;
            this.btnWords.Text = "words";
            this.btnWords.UseVisualStyleBackColor = true;
            this.btnWords.Click += new System.EventHandler(this.btnWords_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1803, 710);
            this.Controls.Add(this.btnWords);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.tbWrongwords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbCorrectwords);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.tbKeystrokes);
            this.Controls.Add(this.btn120);
            this.Controls.Add(this.btn60);
            this.Controls.Add(this.btn30);
            this.Controls.Add(this.btn15);
            this.Controls.Add(this.tbWPM);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lbWrongWordsCounter);
            this.Controls.Add(this.lbCorrectWordsCounter);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn25);
            this.Controls.Add(this.btn10);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbCorrectWordsCounter;
        private System.Windows.Forms.Label lbWrongWordsCounter;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.RichTextBox rtbWords;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn25;
        private System.Windows.Forms.Button btn50;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Timer TimerForSeconds;
        private System.Windows.Forms.TextBox tbWPM;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn30;
        private System.Windows.Forms.Button btn60;
        private System.Windows.Forms.Button btn120;
        private System.Windows.Forms.TextBox tbTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbWrongwords;
        private System.Windows.Forms.TextBox tbCorrectwords;
        private System.Windows.Forms.TextBox tbKeystrokes;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer TimerForWords;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Button btnWords;
        private System.Windows.Forms.RichTextBox rtbKeyStrokes;
        private System.Windows.Forms.RichTextBox rtbCorrectWords;
        private System.Windows.Forms.RichTextBox rtbWrongWords;
    }
}

