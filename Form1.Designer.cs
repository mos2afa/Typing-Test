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
            this.lbCorrectWordsCounter = new System.Windows.Forms.Label();
            this.lbWrongWordsCounter = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.rtbWords = new System.Windows.Forms.RichTextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbCorrectWordsCounter
            // 
            this.lbCorrectWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCorrectWordsCounter.Location = new System.Drawing.Point(805, 66);
            this.lbCorrectWordsCounter.Name = "lbCorrectWordsCounter";
            this.lbCorrectWordsCounter.Size = new System.Drawing.Size(134, 70);
            this.lbCorrectWordsCounter.TabIndex = 2;
            // 
            // lbWrongWordsCounter
            // 
            this.lbWrongWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbWrongWordsCounter.Location = new System.Drawing.Point(822, 168);
            this.lbWrongWordsCounter.Name = "lbWrongWordsCounter";
            this.lbWrongWordsCounter.Size = new System.Drawing.Size(134, 70);
            this.lbWrongWordsCounter.TabIndex = 3;
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::Typing_Test.Properties.Resources.Restart;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestart.Location = new System.Drawing.Point(695, 337);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(72, 61);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // rtbWords
            // 
            this.rtbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWords.Location = new System.Drawing.Point(95, 29);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.ReadOnly = true;
            this.rtbWords.Size = new System.Drawing.Size(672, 285);
            this.rtbWords.TabIndex = 6;
            this.rtbWords.Text = "";
            // 
            // tbType
            // 
            this.tbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbType.Location = new System.Drawing.Point(95, 337);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(578, 61);
            this.tbType.TabIndex = 7;
            this.tbType.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 513);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lbWrongWordsCounter);
            this.Controls.Add(this.lbCorrectWordsCounter);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

