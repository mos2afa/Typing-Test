using System;
using System.Drawing;
using System.Windows.Forms;

namespace Typing_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            PerformKeyDown(e);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            PerformBtnRestartClick();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbTypeTextChanged();
        }

        private void btnChangeNumberOfWords_Click(object sender, EventArgs e)
        {
            ChangeNumberOfWords((Button)sender);
        }

        private void btnChangeNumberOfSeconds_Click(object sender, EventArgs e)
        {
            ChangeNumberOfSeconds((Button)sender);
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            PerformBtnTimeClick();
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            PerformBtnWordsClick();
        }

        private void tbType_KeyDown(object sender, KeyEventArgs e)
        {
            PerformCtrlBackSpace(e);
        }

        private void Form1_BackColorChanged(object sender, EventArgs e)
        {
            ChangeSomeColorsAccordingToFormBackColor();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ToggleSettingsVisibility();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void lbResetDefaultSettings_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to reset settings to default?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetDefaultSettings();
                MessageBox.Show("Settings have been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateTestTimer();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedLanguage = cbLanguage.SelectedItem.ToString();
            ChangeCurrentLanguage(SelectedLanguage);
        }

        private void lbClearResults_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to clear results?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Test.ClearTypingTestsResultsTable();
                dgvResults.DataSource = null;
                MessageBox.Show("Results Are Clear Now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbShowResults_Click(object sender, EventArgs e)
        {
            dgvResults.RowTemplate.Height = 40;

            dgvResults.GridColor = Color.LightGray;

            dgvResults.DataSource = Test.GetTypingTestsForShowing();

            dgvResults.Columns[0].Width = 140;
            dgvResults.Columns[1].Width = 140;
            dgvResults.Columns[2].Width = 140;
            dgvResults.Columns[3].Width = 140;
            dgvResults.Columns[4].Width = 140;
            dgvResults.Columns[5].Width = 140;
            dgvResults.Columns[6].Width = 140;
            dgvResults.Columns[7].Width = 250;

            dgvResults.GridColor = Color.Black;
            dgvResults.ForeColor = SelectColor;
            dgvResults.BackgroundColor = Color.Black;
            dgvResults.DefaultCellStyle.BackColor = Color.Black;

            dgvResults.EnableHeadersVisualStyles = false;

            Color headerColor = this.BackColor;

            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = SelectColor;

            dgvResults.RowHeadersDefaultCellStyle.BackColor = headerColor;
            dgvResults.RowHeadersDefaultCellStyle.ForeColor = SelectColor;
                
            dgvResults.Size = pnlSettings.Size;
            dgvResults.Location = new Point(0, 0);

            dgvResults.Font = new Font(this.Font.FontFamily, 18);

            lbHideResults.Location = new Point(this.Size.Width-250 , 0);
            lbExportResultsToExcel.Location = new Point(this.Size.Width-250 , 50);
            lbClearResults.Location = new Point(this.Size.Width-250 , 100);

            lbHideResults.Show();
            lbExportResultsToExcel.Show();
            lbClearResults.Show();

            dgvResults.Show();

        }

        private void lbHideResults_Click(object sender, EventArgs e)
        {
            lbHideResults.Hide();
            lbExportResultsToExcel.Hide();
            lbClearResults.Hide();

            dgvResults.Hide();
            dgvResults.DataSource = null;
        }
    }
}
