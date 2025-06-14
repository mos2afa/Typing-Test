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
            this.btn250 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbWPM = new System.Windows.Forms.TextBox();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn30 = new System.Windows.Forms.Button();
            this.btn60 = new System.Windows.Forms.Button();
            this.btn120 = new System.Windows.Forms.Button();
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbCorrectWordsCounter
            // 
            this.lbCorrectWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCorrectWordsCounter.Location = new System.Drawing.Point(1236, 20);
            this.lbCorrectWordsCounter.Name = "lbCorrectWordsCounter";
            this.lbCorrectWordsCounter.Size = new System.Drawing.Size(134, 70);
            this.lbCorrectWordsCounter.TabIndex = 2;
            // 
            // lbWrongWordsCounter
            // 
            this.lbWrongWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbWrongWordsCounter.Location = new System.Drawing.Point(1236, 105);
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
            this.rtbWords.BackColor = System.Drawing.SystemColors.ControlLight;
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
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(95, 32);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(53, 40);
            this.btn10.TabIndex = 8;
            this.btn10.TabStop = false;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btnPickTotalWords_Click);
            // 
            // btn25
            // 
            this.btn25.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn25.Location = new System.Drawing.Point(154, 32);
            this.btn25.Name = "btn25";
            this.btn25.Size = new System.Drawing.Size(53, 40);
            this.btn25.TabIndex = 9;
            this.btn25.TabStop = false;
            this.btn25.Text = "25";
            this.btn25.UseVisualStyleBackColor = true;
            this.btn25.Click += new System.EventHandler(this.btnPickTotalWords_Click);
            // 
            // btn50
            // 
            this.btn50.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn50.Location = new System.Drawing.Point(213, 32);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(72, 40);
            this.btn50.TabIndex = 10;
            this.btn50.TabStop = false;
            this.btn50.Text = "50";
            this.btn50.UseVisualStyleBackColor = true;
            this.btn50.Click += new System.EventHandler(this.btnPickTotalWords_Click);
            // 
            // btn100
            // 
            this.btn100.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn100.Location = new System.Drawing.Point(291, 32);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(89, 40);
            this.btn100.TabIndex = 11;
            this.btn100.TabStop = false;
            this.btn100.Text = "100";
            this.btn100.UseVisualStyleBackColor = true;
            this.btn100.Click += new System.EventHandler(this.btnPickTotalWords_Click);
            // 
            // btn250
            // 
            this.btn250.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn250.Location = new System.Drawing.Point(386, 32);
            this.btn250.Name = "btn250";
            this.btn250.Size = new System.Drawing.Size(94, 40);
            this.btn250.TabIndex = 12;
            this.btn250.TabStop = false;
            this.btn250.Text = "250";
            this.btn250.UseVisualStyleBackColor = true;
            this.btn250.Click += new System.EventHandler(this.btnPickTotalWords_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbWPM
            // 
            this.tbWPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWPM.Location = new System.Drawing.Point(1181, 520);
            this.tbWPM.Multiline = true;
            this.tbWPM.Name = "tbWPM";
            this.tbWPM.ReadOnly = true;
            this.tbWPM.Size = new System.Drawing.Size(170, 60);
            this.tbWPM.TabIndex = 13;
            this.tbWPM.TabStop = false;
            // 
            // btn15
            // 
            this.btn15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(540, 32);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(53, 40);
            this.btn15.TabIndex = 14;
            this.btn15.TabStop = false;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn120_Click);
            // 
            // btn30
            // 
            this.btn30.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn30.Location = new System.Drawing.Point(599, 32);
            this.btn30.Name = "btn30";
            this.btn30.Size = new System.Drawing.Size(53, 40);
            this.btn30.TabIndex = 15;
            this.btn30.TabStop = false;
            this.btn30.Text = "30";
            this.btn30.UseVisualStyleBackColor = true;
            this.btn30.Click += new System.EventHandler(this.btn120_Click);
            // 
            // btn60
            // 
            this.btn60.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn60.Location = new System.Drawing.Point(658, 32);
            this.btn60.Name = "btn60";
            this.btn60.Size = new System.Drawing.Size(53, 40);
            this.btn60.TabIndex = 16;
            this.btn60.TabStop = false;
            this.btn60.Text = "60";
            this.btn60.UseVisualStyleBackColor = true;
            this.btn60.Click += new System.EventHandler(this.btn120_Click);
            // 
            // btn120
            // 
            this.btn120.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn120.Location = new System.Drawing.Point(717, 32);
            this.btn120.Name = "btn120";
            this.btn120.Size = new System.Drawing.Size(67, 40);
            this.btn120.TabIndex = 17;
            this.btn120.TabStop = false;
            this.btn120.Text = "120";
            this.btn120.UseVisualStyleBackColor = true;
            this.btn120.Click += new System.EventHandler(this.btn120_Click);
            // 
            // tbTimer
            // 
            this.tbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimer.Location = new System.Drawing.Point(826, 536);
            this.tbTimer.Multiline = true;
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.ReadOnly = true;
            this.tbTimer.Size = new System.Drawing.Size(170, 60);
            this.tbTimer.TabIndex = 18;
            this.tbTimer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 710);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.btn120);
            this.Controls.Add(this.btn60);
            this.Controls.Add(this.btn30);
            this.Controls.Add(this.btn15);
            this.Controls.Add(this.tbWPM);
            this.Controls.Add(this.btn250);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn25);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lbWrongWordsCounter);
            this.Controls.Add(this.lbCorrectWordsCounter);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button btn250;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbWPM;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn30;
        private System.Windows.Forms.Button btn60;
        private System.Windows.Forms.Button btn120;
        private System.Windows.Forms.TextBox tbTimer;
    }
}

