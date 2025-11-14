
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
            this.btn15 = new System.Windows.Forms.Button();
            this.btn30 = new System.Windows.Forms.Button();
            this.btn60 = new System.Windows.Forms.Button();
            this.btn120 = new System.Windows.Forms.Button();
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbAccuracy = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbKeyStrokes = new System.Windows.Forms.RichTextBox();
            this.rtbCorrectWords = new System.Windows.Forms.RichTextBox();
            this.rtbWrongWords = new System.Windows.Forms.RichTextBox();
            this.rtbFinalWPM = new System.Windows.Forms.RichTextBox();
            this.lbImportSettings = new System.Windows.Forms.Label();
            this.lbExportSettings = new System.Windows.Forms.Label();
            this.cbWhichWords = new System.Windows.Forms.ComboBox();
            this.lbTypeBarForeColor = new System.Windows.Forms.Label();
            this.lbResetDefaultSettings = new System.Windows.Forms.Label();
            this.lbWrongWordColor = new System.Windows.Forms.Label();
            this.lbCorrectWordColor = new System.Windows.Forms.Label();
            this.lbCurrentWordColor = new System.Windows.Forms.Label();
            this.lbFontColor = new System.Windows.Forms.Label();
            this.lbFormBackColor = new System.Windows.Forms.Label();
            this.btnTime = new System.Windows.Forms.Button();
            this.btnWords = new System.Windows.Forms.Button();
            this.tbLiveWPM = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.rtbCapsLock = new System.Windows.Forms.RichTextBox();
            this.tbWordsCounter = new System.Windows.Forms.TextBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lbExportResultsToExcel = new System.Windows.Forms.Label();
            this.lbChangeSelectColor = new System.Windows.Forms.Label();
            this.lbChangeCountersColor = new System.Windows.Forms.Label();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.rtbDuration = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbWPMWord = new System.Windows.Forms.RichTextBox();
            this.tUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.sfdExportResultsToExcel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbWords
            // 
            resources.ApplyResources(this.rtbWords, "rtbWords");
            this.rtbWords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(24)))));
            this.rtbWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWords.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbWords.ForeColor = System.Drawing.Color.White;
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.ReadOnly = true;
            this.rtbWords.TabStop = false;
            this.rtbWords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWords_MouseDown);
            // 
            // tbType
            // 
            resources.ApplyResources(this.tbType, "tbType");
            this.tbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(24)))));
            this.tbType.ForeColor = System.Drawing.Color.White;
            this.tbType.Name = "tbType";
            this.tbType.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbType_KeyDown);
            // 
            // btn10
            // 
            resources.ApplyResources(this.btn10, "btn10");
            this.btn10.BackColor = System.Drawing.Color.Gainsboro;
            this.btn10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn10.Name = "btn10";
            this.btn10.TabStop = false;
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn25
            // 
            resources.ApplyResources(this.btn25, "btn25");
            this.btn25.BackColor = System.Drawing.Color.Gainsboro;
            this.btn25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn25.Name = "btn25";
            this.btn25.TabStop = false;
            this.btn25.UseVisualStyleBackColor = false;
            this.btn25.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn50
            // 
            resources.ApplyResources(this.btn50, "btn50");
            this.btn50.BackColor = System.Drawing.Color.Gainsboro;
            this.btn50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn50.Name = "btn50";
            this.btn50.TabStop = false;
            this.btn50.UseVisualStyleBackColor = false;
            this.btn50.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn100
            // 
            resources.ApplyResources(this.btn100, "btn100");
            this.btn100.BackColor = System.Drawing.Color.Gainsboro;
            this.btn100.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn100.Name = "btn100";
            this.btn100.TabStop = false;
            this.btn100.UseVisualStyleBackColor = false;
            this.btn100.Click += new System.EventHandler(this.btnChangeNumberOfWords_Click);
            // 
            // btn15
            // 
            resources.ApplyResources(this.btn15, "btn15");
            this.btn15.BackColor = System.Drawing.Color.Gainsboro;
            this.btn15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn15.Name = "btn15";
            this.btn15.TabStop = false;
            this.btn15.UseVisualStyleBackColor = false;
            this.btn15.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn30
            // 
            resources.ApplyResources(this.btn30, "btn30");
            this.btn30.BackColor = System.Drawing.Color.Gainsboro;
            this.btn30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn30.Name = "btn30";
            this.btn30.TabStop = false;
            this.btn30.UseVisualStyleBackColor = false;
            this.btn30.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn60
            // 
            resources.ApplyResources(this.btn60, "btn60");
            this.btn60.BackColor = System.Drawing.Color.Gainsboro;
            this.btn60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn60.Name = "btn60";
            this.btn60.TabStop = false;
            this.btn60.UseVisualStyleBackColor = false;
            this.btn60.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // btn120
            // 
            resources.ApplyResources(this.btn120, "btn120");
            this.btn120.BackColor = System.Drawing.Color.Gainsboro;
            this.btn120.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn120.Name = "btn120";
            this.btn120.TabStop = false;
            this.btn120.UseVisualStyleBackColor = false;
            this.btn120.Click += new System.EventHandler(this.btnChangeNumberOfSeconds_Click);
            // 
            // tbTimer
            // 
            this.tbTimer.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimer.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tbTimer, "tbTimer");
            this.tbTimer.ForeColor = System.Drawing.Color.DeepPink;
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.ReadOnly = true;
            this.tbTimer.TabStop = false;
            this.tbTimer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWPMWord_MouseDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // rtbAccuracy
            // 
            this.rtbAccuracy.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.rtbAccuracy, "rtbAccuracy");
            this.rtbAccuracy.ForeColor = System.Drawing.Color.Black;
            this.rtbAccuracy.Name = "rtbAccuracy";
            this.rtbAccuracy.ReadOnly = true;
            this.rtbAccuracy.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // rtbKeyStrokes
            // 
            this.rtbKeyStrokes.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.rtbKeyStrokes, "rtbKeyStrokes");
            this.rtbKeyStrokes.ForeColor = System.Drawing.Color.Black;
            this.rtbKeyStrokes.Name = "rtbKeyStrokes";
            this.rtbKeyStrokes.ReadOnly = true;
            this.rtbKeyStrokes.TabStop = false;
            // 
            // rtbCorrectWords
            // 
            this.rtbCorrectWords.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.rtbCorrectWords, "rtbCorrectWords");
            this.rtbCorrectWords.ForeColor = System.Drawing.Color.Green;
            this.rtbCorrectWords.Name = "rtbCorrectWords";
            this.rtbCorrectWords.ReadOnly = true;
            this.rtbCorrectWords.TabStop = false;
            // 
            // rtbWrongWords
            // 
            this.rtbWrongWords.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.rtbWrongWords, "rtbWrongWords");
            this.rtbWrongWords.ForeColor = System.Drawing.Color.Red;
            this.rtbWrongWords.Name = "rtbWrongWords";
            this.rtbWrongWords.ReadOnly = true;
            this.rtbWrongWords.TabStop = false;
            // 
            // rtbFinalWPM
            // 
            this.rtbFinalWPM.BackColor = System.Drawing.Color.DodgerBlue;
            this.rtbFinalWPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFinalWPM.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.rtbFinalWPM, "rtbFinalWPM");
            this.rtbFinalWPM.ForeColor = System.Drawing.Color.DeepPink;
            this.rtbFinalWPM.Name = "rtbFinalWPM";
            this.rtbFinalWPM.ReadOnly = true;
            this.rtbFinalWPM.TabStop = false;
            this.rtbFinalWPM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWPMWord_MouseDown);
            this.rtbFinalWPM.MouseEnter += new System.EventHandler(this.rtbFinalWPM_MouseEnter);
            this.rtbFinalWPM.MouseLeave += new System.EventHandler(this.rtbFinalWPM_MouseLeave);
            // 
            // lbImportSettings
            // 
            resources.ApplyResources(this.lbImportSettings, "lbImportSettings");
            this.lbImportSettings.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbImportSettings.Name = "lbImportSettings";
            this.lbImportSettings.Click += new System.EventHandler(this.lbImportSettings_Click);
            // 
            // lbExportSettings
            // 
            resources.ApplyResources(this.lbExportSettings, "lbExportSettings");
            this.lbExportSettings.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbExportSettings.Name = "lbExportSettings";
            this.lbExportSettings.Click += new System.EventHandler(this.lbExportSettings_Click);
            // 
            // cbWhichWords
            // 
            this.cbWhichWords.DisplayMember = "0";
            resources.ApplyResources(this.cbWhichWords, "cbWhichWords");
            this.cbWhichWords.FormattingEnabled = true;
            this.cbWhichWords.Items.AddRange(new object[] {
            resources.GetString("cbWhichWords.Items"),
            resources.GetString("cbWhichWords.Items1")});
            this.cbWhichWords.Name = "cbWhichWords";
            this.cbWhichWords.TabStop = false;
            this.cbWhichWords.SelectedIndexChanged += new System.EventHandler(this.cbWhichWords_SelectedIndexChanged);
            // 
            // lbTypeBarForeColor
            // 
            resources.ApplyResources(this.lbTypeBarForeColor, "lbTypeBarForeColor");
            this.lbTypeBarForeColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbTypeBarForeColor.Name = "lbTypeBarForeColor";
            this.lbTypeBarForeColor.Click += new System.EventHandler(this.lbChangetbTypeForeColor_Click);
            // 
            // lbResetDefaultSettings
            // 
            resources.ApplyResources(this.lbResetDefaultSettings, "lbResetDefaultSettings");
            this.lbResetDefaultSettings.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbResetDefaultSettings.Name = "lbResetDefaultSettings";
            this.lbResetDefaultSettings.Click += new System.EventHandler(this.lbResetDefaultSettings_Click);
            // 
            // lbWrongWordColor
            // 
            resources.ApplyResources(this.lbWrongWordColor, "lbWrongWordColor");
            this.lbWrongWordColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbWrongWordColor.Name = "lbWrongWordColor";
            this.lbWrongWordColor.Click += new System.EventHandler(this.lbChangeWrongWordColor_Click);
            // 
            // lbCorrectWordColor
            // 
            resources.ApplyResources(this.lbCorrectWordColor, "lbCorrectWordColor");
            this.lbCorrectWordColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbCorrectWordColor.Name = "lbCorrectWordColor";
            this.lbCorrectWordColor.Click += new System.EventHandler(this.lbChangeCorrectWordColor_Click);
            // 
            // lbCurrentWordColor
            // 
            resources.ApplyResources(this.lbCurrentWordColor, "lbCurrentWordColor");
            this.lbCurrentWordColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbCurrentWordColor.Name = "lbCurrentWordColor";
            this.lbCurrentWordColor.Click += new System.EventHandler(this.lbChangeCurrentWordColor_Click);
            // 
            // lbFontColor
            // 
            resources.ApplyResources(this.lbFontColor, "lbFontColor");
            this.lbFontColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbFontColor.Name = "lbFontColor";
            this.lbFontColor.Click += new System.EventHandler(this.lbChangertbWordsForeColor_Click);
            // 
            // lbFormBackColor
            // 
            resources.ApplyResources(this.lbFormBackColor, "lbFormBackColor");
            this.lbFormBackColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbFormBackColor.Name = "lbFormBackColor";
            this.lbFormBackColor.Click += new System.EventHandler(this.lbChangeFormBackColor_Click);
            // 
            // btnTime
            // 
            resources.ApplyResources(this.btnTime, "btnTime");
            this.btnTime.BackColor = System.Drawing.Color.White;
            this.btnTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTime.Name = "btnTime";
            this.btnTime.TabStop = false;
            this.btnTime.UseVisualStyleBackColor = false;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnWords
            // 
            resources.ApplyResources(this.btnWords, "btnWords");
            this.btnWords.BackColor = System.Drawing.Color.White;
            this.btnWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWords.Name = "btnWords";
            this.btnWords.TabStop = false;
            this.btnWords.UseVisualStyleBackColor = false;
            this.btnWords.Click += new System.EventHandler(this.btnWords_Click);
            // 
            // tbLiveWPM
            // 
            this.tbLiveWPM.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbLiveWPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLiveWPM.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tbLiveWPM, "tbLiveWPM");
            this.tbLiveWPM.ForeColor = System.Drawing.Color.DeepPink;
            this.tbLiveWPM.Name = "tbLiveWPM";
            this.tbLiveWPM.ReadOnly = true;
            this.tbLiveWPM.TabStop = false;
            this.tbLiveWPM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWPMWord_MouseDown);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Typing_Test.Properties.Resources.fullscreen;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = global::Typing_Test.Properties.Resources.setting;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.TabStop = false;
            this.btnSettings.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnRestart
            // 
            resources.ApplyResources(this.btnRestart, "btnRestart");
            this.btnRestart.BackgroundImage = global::Typing_Test.Properties.Resources.Restart;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // rtbCapsLock
            // 
            resources.ApplyResources(this.rtbCapsLock, "rtbCapsLock");
            this.rtbCapsLock.BackColor = System.Drawing.Color.DeepPink;
            this.rtbCapsLock.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbCapsLock.ForeColor = System.Drawing.Color.Black;
            this.rtbCapsLock.Name = "rtbCapsLock";
            this.rtbCapsLock.ReadOnly = true;
            this.rtbCapsLock.TabStop = false;
            this.rtbCapsLock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWPMWord_MouseDown);
            // 
            // tbWordsCounter
            // 
            this.tbWordsCounter.BackColor = System.Drawing.Color.DodgerBlue;
            this.tbWordsCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWordsCounter.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tbWordsCounter, "tbWordsCounter");
            this.tbWordsCounter.ForeColor = System.Drawing.Color.DeepPink;
            this.tbWordsCounter.Name = "tbWordsCounter";
            this.tbWordsCounter.ReadOnly = true;
            this.tbWordsCounter.TabStop = false;
            this.tbWordsCounter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWPMWord_MouseDown);
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.Add(this.lbExportResultsToExcel);
            this.pnlSettings.Controls.Add(this.lbChangeSelectColor);
            this.pnlSettings.Controls.Add(this.lbChangeCountersColor);
            this.pnlSettings.Controls.Add(this.lbTypeBarForeColor);
            this.pnlSettings.Controls.Add(this.cbWhichWords);
            this.pnlSettings.Controls.Add(this.lbResetDefaultSettings);
            this.pnlSettings.Controls.Add(this.lbImportSettings);
            this.pnlSettings.Controls.Add(this.lbWrongWordColor);
            this.pnlSettings.Controls.Add(this.lbExportSettings);
            this.pnlSettings.Controls.Add(this.lbCorrectWordColor);
            this.pnlSettings.Controls.Add(this.lbCurrentWordColor);
            this.pnlSettings.Controls.Add(this.lbFormBackColor);
            this.pnlSettings.Controls.Add(this.lbFontColor);
            this.pnlSettings.Name = "pnlSettings";
            // 
            // lbExportResultsToExcel
            // 
            resources.ApplyResources(this.lbExportResultsToExcel, "lbExportResultsToExcel");
            this.lbExportResultsToExcel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbExportResultsToExcel.Name = "lbExportResultsToExcel";
            this.lbExportResultsToExcel.Click += new System.EventHandler(this.lbExportResultsToExcel_Click);
            // 
            // lbChangeSelectColor
            // 
            resources.ApplyResources(this.lbChangeSelectColor, "lbChangeSelectColor");
            this.lbChangeSelectColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbChangeSelectColor.Name = "lbChangeSelectColor";
            this.lbChangeSelectColor.Click += new System.EventHandler(this.lbChangeSelectColor_Click);
            // 
            // lbChangeCountersColor
            // 
            resources.ApplyResources(this.lbChangeCountersColor, "lbChangeCountersColor");
            this.lbChangeCountersColor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbChangeCountersColor.Name = "lbChangeCountersColor";
            this.lbChangeCountersColor.Click += new System.EventHandler(this.lbChangeCountersColor_Click);
            // 
            // pnlResults
            // 
            resources.ApplyResources(this.pnlResults, "pnlResults");
            this.pnlResults.Controls.Add(this.rtbDuration);
            this.pnlResults.Controls.Add(this.label5);
            this.pnlResults.Controls.Add(this.rtbWPMWord);
            this.pnlResults.Controls.Add(this.rtbAccuracy);
            this.pnlResults.Controls.Add(this.rtbFinalWPM);
            this.pnlResults.Controls.Add(this.label4);
            this.pnlResults.Controls.Add(this.label1);
            this.pnlResults.Controls.Add(this.label2);
            this.pnlResults.Controls.Add(this.rtbKeyStrokes);
            this.pnlResults.Controls.Add(this.label3);
            this.pnlResults.Controls.Add(this.rtbCorrectWords);
            this.pnlResults.Controls.Add(this.rtbWrongWords);
            this.pnlResults.Name = "pnlResults";
            // 
            // rtbDuration
            // 
            this.rtbDuration.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.rtbDuration, "rtbDuration");
            this.rtbDuration.ForeColor = System.Drawing.Color.Black;
            this.rtbDuration.Name = "rtbDuration";
            this.rtbDuration.ReadOnly = true;
            this.rtbDuration.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // rtbWPMWord
            // 
            this.rtbWPMWord.BackColor = System.Drawing.Color.DodgerBlue;
            this.rtbWPMWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWPMWord.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.rtbWPMWord, "rtbWPMWord");
            this.rtbWPMWord.ForeColor = System.Drawing.Color.DeepPink;
            this.rtbWPMWord.Name = "rtbWPMWord";
            this.rtbWPMWord.ReadOnly = true;
            this.rtbWPMWord.TabStop = false;
            this.rtbWPMWord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbWPMWord_MouseDown);
            // 
            // tUpdateUI
            // 
            this.tUpdateUI.Interval = 1000;
            this.tUpdateUI.Tick += new System.EventHandler(this.tUpdateUI_Tick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.rtbCapsLock);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnWords);
            this.Controls.Add(this.btnTime);
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
            this.Controls.Add(this.tbLiveWPM);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.tbWordsCounter);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlResults);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BackColorChanged += new System.EventHandler(this.Form1_BackColorChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
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
        public System.Windows.Forms.Button btn15;
        public System.Windows.Forms.Button btn30;
        public System.Windows.Forms.Button btn60;
        public System.Windows.Forms.Button btn120;
        public System.Windows.Forms.TextBox tbTimer;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.RichTextBox rtbFinalWPM;
        public System.Windows.Forms.Button btnTime;
        public System.Windows.Forms.Button btnWords;
        public System.Windows.Forms.RichTextBox rtbKeyStrokes;
        public System.Windows.Forms.RichTextBox rtbCorrectWords;
        public System.Windows.Forms.RichTextBox rtbWrongWords;
        public System.Windows.Forms.TextBox tbLiveWPM;
        private System.Windows.Forms.ColorDialog colorDialog1;
        //public System.Windows.Forms.RichTextBox richTextBox2;
        public System.Windows.Forms.RichTextBox rtbAccuracy;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.Label lbTypeBarForeColor;
        private System.Windows.Forms.Label lbResetDefaultSettings;
        private System.Windows.Forms.Label lbWrongWordColor;
        private System.Windows.Forms.Label lbCorrectWordColor;
        private System.Windows.Forms.Label lbCurrentWordColor;
        private System.Windows.Forms.Label lbFontColor;
        private System.Windows.Forms.Label lbFormBackColor;
        private System.Windows.Forms.ComboBox cbWhichWords;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox rtbCapsLock;
        public System.Windows.Forms.TextBox tbWordsCounter;
        private System.Windows.Forms.Label lbExportSettings;
        private System.Windows.Forms.Label lbImportSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Panel pnlResults;
        public System.Windows.Forms.RichTextBox rtbWPMWord;
        private System.Windows.Forms.Label lbChangeCountersColor;
        private System.Windows.Forms.Label lbChangeSelectColor;
        private System.Windows.Forms.Timer tUpdateUI;
        private System.Windows.Forms.Label lbExportResultsToExcel;
        private System.Windows.Forms.SaveFileDialog sfdExportResultsToExcel;
        public System.Windows.Forms.RichTextBox rtbDuration;
        public System.Windows.Forms.Label label5;
    }
}

