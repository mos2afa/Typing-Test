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
            this.cmsBackColor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeBackColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.rtbAccuracy = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.rtbKeyStrokes = new System.Windows.Forms.RichTextBox();
            this.rtbCorrectWords = new System.Windows.Forms.RichTextBox();
            this.rtbWrongWords = new System.Windows.Forms.RichTextBox();
            this.rtbFinalWPM = new System.Windows.Forms.RichTextBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.cbWhichWords = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TimerForWords = new System.Windows.Forms.Timer(this.components);
            this.btnTime = new System.Windows.Forms.Button();
            this.btnWords = new System.Windows.Forms.Button();
            this.tbLiveWPM = new System.Windows.Forms.TextBox();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsBackColor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbWords
            // 
            this.rtbWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbWords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(24)))));
            this.rtbWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWords.ContextMenuStrip = this.cmsBackColor;
            this.rtbWords.Cursor = System.Windows.Forms.Cursors.No;
            this.rtbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 37F);
            this.rtbWords.ForeColor = System.Drawing.Color.White;
            this.rtbWords.Location = new System.Drawing.Point(13, 73);
            this.rtbWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.ReadOnly = true;
            this.rtbWords.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtbWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbWords.Size = new System.Drawing.Size(981, 425);
            this.rtbWords.TabIndex = 6;
            this.rtbWords.TabStop = false;
            this.rtbWords.Text = "";
            // 
            // cmsBackColor
            // 
            this.cmsBackColor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBackColor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBackColorToolStripMenuItem});
            this.cmsBackColor.Name = "contextMenuStrip1";
            this.cmsBackColor.Size = new System.Drawing.Size(204, 28);
            this.cmsBackColor.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // changeBackColorToolStripMenuItem
            // 
            this.changeBackColorToolStripMenuItem.Name = "changeBackColorToolStripMenuItem";
            this.changeBackColorToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.changeBackColorToolStripMenuItem.Text = "Change Back Color";
            // 
            // tbType
            // 
            this.tbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(24)))));
            this.tbType.ContextMenuStrip = this.cmsBackColor;
            this.tbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbType.ForeColor = System.Drawing.Color.White;
            this.tbType.Location = new System.Drawing.Point(12, 502);
            this.tbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(901, 61);
            this.tbType.TabIndex = 0;
            this.tbType.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbType_KeyDown);
            // 
            // btn10
            // 
            this.btn10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn10.BackColor = System.Drawing.Color.Gainsboro;
            this.btn10.ContextMenuStrip = this.cmsBackColor;
            this.btn10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(746, 7);
            this.btn10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(60, 47);
            this.btn10.TabIndex = 8;
            this.btn10.TabStop = false;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn25
            // 
            this.btn25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn25.BackColor = System.Drawing.Color.Gainsboro;
            this.btn25.ContextMenuStrip = this.cmsBackColor;
            this.btn25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn25.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn25.Location = new System.Drawing.Point(806, 7);
            this.btn25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn25.Name = "btn25";
            this.btn25.Size = new System.Drawing.Size(60, 47);
            this.btn25.TabIndex = 9;
            this.btn25.TabStop = false;
            this.btn25.Text = "25";
            this.btn25.UseVisualStyleBackColor = false;
            this.btn25.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn50
            // 
            this.btn50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn50.BackColor = System.Drawing.Color.Gainsboro;
            this.btn50.ContextMenuStrip = this.cmsBackColor;
            this.btn50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn50.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn50.Location = new System.Drawing.Point(866, 7);
            this.btn50.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(60, 47);
            this.btn50.TabIndex = 10;
            this.btn50.TabStop = false;
            this.btn50.Text = "50";
            this.btn50.UseVisualStyleBackColor = false;
            this.btn50.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn100
            // 
            this.btn100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn100.BackColor = System.Drawing.Color.Gainsboro;
            this.btn100.ContextMenuStrip = this.cmsBackColor;
            this.btn100.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn100.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn100.Location = new System.Drawing.Point(926, 7);
            this.btn100.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(68, 47);
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
            this.btn15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn15.BackColor = System.Drawing.Color.Gainsboro;
            this.btn15.ContextMenuStrip = this.cmsBackColor;
            this.btn15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(746, 7);
            this.btn15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(60, 47);
            this.btn15.TabIndex = 14;
            this.btn15.TabStop = false;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = false;
            this.btn15.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn30
            // 
            this.btn30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn30.BackColor = System.Drawing.Color.Gainsboro;
            this.btn30.ContextMenuStrip = this.cmsBackColor;
            this.btn30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn30.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn30.Location = new System.Drawing.Point(806, 7);
            this.btn30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn30.Name = "btn30";
            this.btn30.Size = new System.Drawing.Size(60, 47);
            this.btn30.TabIndex = 15;
            this.btn30.TabStop = false;
            this.btn30.Text = "30";
            this.btn30.UseVisualStyleBackColor = false;
            this.btn30.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn60
            // 
            this.btn60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn60.BackColor = System.Drawing.Color.Gainsboro;
            this.btn60.ContextMenuStrip = this.cmsBackColor;
            this.btn60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn60.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn60.Location = new System.Drawing.Point(866, 7);
            this.btn60.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn60.Name = "btn60";
            this.btn60.Size = new System.Drawing.Size(60, 47);
            this.btn60.TabIndex = 16;
            this.btn60.TabStop = false;
            this.btn60.Text = "60";
            this.btn60.UseVisualStyleBackColor = false;
            this.btn60.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn120
            // 
            this.btn120.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn120.BackColor = System.Drawing.Color.Gainsboro;
            this.btn120.ContextMenuStrip = this.cmsBackColor;
            this.btn120.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn120.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn120.Location = new System.Drawing.Point(926, 7);
            this.btn120.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn120.Name = "btn120";
            this.btn120.Size = new System.Drawing.Size(68, 47);
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
            this.tbTimer.ContextMenuStrip = this.cmsBackColor;
            this.tbTimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimer.ForeColor = System.Drawing.Color.DeepPink;
            this.tbTimer.Location = new System.Drawing.Point(12, 1);
            this.tbTimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.ReadOnly = true;
            this.tbTimer.Size = new System.Drawing.Size(157, 57);
            this.tbTimer.TabIndex = 18;
            this.tbTimer.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(474, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 38);
            this.label1.TabIndex = 20;
            this.label1.Text = "Keystrokes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(474, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 38);
            this.label2.TabIndex = 21;
            this.label2.Text = "Correct words";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(474, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 38);
            this.label3.TabIndex = 22;
            this.label3.Text = "Wrong words";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.ContextMenuStrip = this.cmsBackColor;
            this.groupBox1.Controls.Add(this.rtbAccuracy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Controls.Add(this.rtbKeyStrokes);
            this.groupBox1.Controls.Add(this.rtbCorrectWords);
            this.groupBox1.Controls.Add(this.rtbWrongWords);
            this.groupBox1.Controls.Add(this.rtbFinalWPM);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(981, 439);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rtbAccuracy
            // 
            this.rtbAccuracy.BackColor = System.Drawing.Color.White;
            this.rtbAccuracy.ContextMenuStrip = this.cmsBackColor;
            this.rtbAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAccuracy.ForeColor = System.Drawing.Color.Black;
            this.rtbAccuracy.Location = new System.Drawing.Point(718, 30);
            this.rtbAccuracy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbAccuracy.Name = "rtbAccuracy";
            this.rtbAccuracy.ReadOnly = true;
            this.rtbAccuracy.Size = new System.Drawing.Size(250, 45);
            this.rtbAccuracy.TabIndex = 32;
            this.rtbAccuracy.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(474, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 38);
            this.label4.TabIndex = 31;
            this.label4.Text = "Accuracy";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.DodgerBlue;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ContextMenuStrip = this.cmsBackColor;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.Color.DeepPink;
            this.richTextBox2.Location = new System.Drawing.Point(6, 203);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(453, 65);
            this.richTextBox2.TabIndex = 30;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "            (WPM)";
            // 
            // rtbKeyStrokes
            // 
            this.rtbKeyStrokes.BackColor = System.Drawing.Color.White;
            this.rtbKeyStrokes.ContextMenuStrip = this.cmsBackColor;
            this.rtbKeyStrokes.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbKeyStrokes.ForeColor = System.Drawing.Color.Black;
            this.rtbKeyStrokes.Location = new System.Drawing.Point(718, 121);
            this.rtbKeyStrokes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbKeyStrokes.Name = "rtbKeyStrokes";
            this.rtbKeyStrokes.ReadOnly = true;
            this.rtbKeyStrokes.Size = new System.Drawing.Size(250, 45);
            this.rtbKeyStrokes.TabIndex = 29;
            this.rtbKeyStrokes.Text = "";
            // 
            // rtbCorrectWords
            // 
            this.rtbCorrectWords.BackColor = System.Drawing.Color.White;
            this.rtbCorrectWords.ContextMenuStrip = this.cmsBackColor;
            this.rtbCorrectWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCorrectWords.ForeColor = System.Drawing.Color.Green;
            this.rtbCorrectWords.Location = new System.Drawing.Point(718, 219);
            this.rtbCorrectWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbCorrectWords.Name = "rtbCorrectWords";
            this.rtbCorrectWords.ReadOnly = true;
            this.rtbCorrectWords.Size = new System.Drawing.Size(250, 45);
            this.rtbCorrectWords.TabIndex = 28;
            this.rtbCorrectWords.Text = "";
            // 
            // rtbWrongWords
            // 
            this.rtbWrongWords.BackColor = System.Drawing.Color.White;
            this.rtbWrongWords.ContextMenuStrip = this.cmsBackColor;
            this.rtbWrongWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbWrongWords.ForeColor = System.Drawing.Color.Red;
            this.rtbWrongWords.Location = new System.Drawing.Point(718, 317);
            this.rtbWrongWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbWrongWords.Name = "rtbWrongWords";
            this.rtbWrongWords.ReadOnly = true;
            this.rtbWrongWords.Size = new System.Drawing.Size(250, 45);
            this.rtbWrongWords.TabIndex = 27;
            this.rtbWrongWords.Text = "";
            // 
            // rtbFinalWPM
            // 
            this.rtbFinalWPM.BackColor = System.Drawing.Color.DodgerBlue;
            this.rtbFinalWPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFinalWPM.ContextMenuStrip = this.cmsBackColor;
            this.rtbFinalWPM.Font = new System.Drawing.Font("Microsoft Tai Le", 100F, System.Drawing.FontStyle.Bold);
            this.rtbFinalWPM.ForeColor = System.Drawing.Color.DeepPink;
            this.rtbFinalWPM.Location = new System.Drawing.Point(6, 17);
            this.rtbFinalWPM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbFinalWPM.Name = "rtbFinalWPM";
            this.rtbFinalWPM.ReadOnly = true;
            this.rtbFinalWPM.Size = new System.Drawing.Size(453, 251);
            this.rtbFinalWPM.TabIndex = 26;
            this.rtbFinalWPM.TabStop = false;
            this.rtbFinalWPM.Text = "";
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.cbWhichWords);
            this.gbSetting.Controls.Add(this.label11);
            this.gbSetting.Controls.Add(this.label10);
            this.gbSetting.Controls.Add(this.label9);
            this.gbSetting.Controls.Add(this.label8);
            this.gbSetting.Controls.Add(this.label7);
            this.gbSetting.Controls.Add(this.label6);
            this.gbSetting.Controls.Add(this.label5);
            this.gbSetting.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gbSetting.Location = new System.Drawing.Point(19, 73);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(974, 425);
            this.gbSetting.TabIndex = 33;
            this.gbSetting.TabStop = false;
            // 
            // cbWhichWords
            // 
            this.cbWhichWords.DisplayMember = "0";
            this.cbWhichWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWhichWords.FormattingEnabled = true;
            this.cbWhichWords.Items.AddRange(new object[] {
            "10 fast fingers",
            "monkey type"});
            this.cbWhichWords.Location = new System.Drawing.Point(303, 21);
            this.cbWhichWords.Name = "cbWhichWords";
            this.cbWhichWords.Size = new System.Drawing.Size(243, 39);
            this.cbWhichWords.TabIndex = 7;
            this.cbWhichWords.TabStop = false;
            this.cbWhichWords.Text = "Which Words";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(17, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(261, 32);
            this.label11.TabIndex = 6;
            this.label11.Text = "TypeBar Fore Color";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Location = new System.Drawing.Point(24, 370);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 32);
            this.label10.TabIndex = 5;
            this.label10.Text = "---------------";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 32);
            this.label9.TabIndex = 4;
            this.label9.Text = "Wrong Word Color";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(17, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(255, 32);
            this.label8.TabIndex = 3;
            this.label8.Text = "Correct Word Color";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(17, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 32);
            this.label7.TabIndex = 2;
            this.label7.Text = "Current Word Color";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(17, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Font Color";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Form BackColor";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // TimerForWords
            // 
            this.TimerForWords.Interval = 1000;
            this.TimerForWords.Tick += new System.EventHandler(this.TimerForWords_Tick);
            // 
            // btnTime
            // 
            this.btnTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTime.BackColor = System.Drawing.Color.White;
            this.btnTime.ContextMenuStrip = this.cmsBackColor;
            this.btnTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTime.Location = new System.Drawing.Point(409, 7);
            this.btnTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(156, 47);
            this.btnTime.TabIndex = 24;
            this.btnTime.TabStop = false;
            this.btnTime.Text = "time";
            this.btnTime.UseVisualStyleBackColor = false;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnWords
            // 
            this.btnWords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWords.BackColor = System.Drawing.Color.White;
            this.btnWords.ContextMenuStrip = this.cmsBackColor;
            this.btnWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWords.Location = new System.Drawing.Point(571, 7);
            this.btnWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWords.Name = "btnWords";
            this.btnWords.Size = new System.Drawing.Size(156, 47);
            this.btnWords.TabIndex = 25;
            this.btnWords.TabStop = false;
            this.btnWords.Text = "words";
            this.btnWords.UseVisualStyleBackColor = false;
            this.btnWords.Click += new System.EventHandler(this.btnWords_Click);
            // 
            // tbLiveWPM
            // 
            this.tbLiveWPM.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbLiveWPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLiveWPM.ContextMenuStrip = this.cmsBackColor;
            this.tbLiveWPM.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbLiveWPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLiveWPM.ForeColor = System.Drawing.Color.DeepPink;
            this.tbLiveWPM.Location = new System.Drawing.Point(175, 1);
            this.tbLiveWPM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLiveWPM.Name = "tbLiveWPM";
            this.tbLiveWPM.ReadOnly = true;
            this.tbLiveWPM.Size = new System.Drawing.Size(111, 57);
            this.tbLiveWPM.TabIndex = 26;
            this.tbLiveWPM.TabStop = false;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.BackgroundImage = global::Typing_Test.Properties.Resources.Restart;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.Location = new System.Drawing.Point(919, 502);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 62);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Typing_Test.Properties.Resources.setting;
            this.pictureBox1.Location = new System.Drawing.Point(322, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(24)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(999, 570);
            this.ContextMenuStrip = this.cmsBackColor;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbLiveWPM);
            this.Controls.Add(this.btnWords);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btn120);
            this.Controls.Add(this.btn60);
            this.Controls.Add(this.btn30);
            this.Controls.Add(this.btn15);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn25);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbWords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Typing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BackColorChanged += new System.EventHandler(this.Form1_BackColorChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cmsBackColor.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        public System.Windows.Forms.RichTextBox rtbFinalWPM;
        public System.Windows.Forms.Timer TimerForWords;
        public System.Windows.Forms.Button btnTime;
        public System.Windows.Forms.Button btnWords;
        public System.Windows.Forms.RichTextBox rtbKeyStrokes;
        public System.Windows.Forms.RichTextBox rtbCorrectWords;
        public System.Windows.Forms.RichTextBox rtbWrongWords;
        public System.Windows.Forms.TextBox tbLiveWPM;
        private System.Windows.Forms.ContextMenuStrip cmsBackColor;
        private System.Windows.Forms.ToolStripMenuItem changeBackColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.RichTextBox richTextBox2;
        public System.Windows.Forms.RichTextBox rtbAccuracy;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbWhichWords;
    }
}

