using System;

namespace HW_SP_4._3
{
    partial class Form1
    {
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtResult;

        private void InitializeComponent()
        {
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // txtWord
            this.txtWord.Location = new System.Drawing.Point(12, 12);
            this.txtWord.Size = new System.Drawing.Size(200, 20);
            this.txtWord.Text = "Введите слово для поиска";
            this.txtWord.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtWord.Enter += new System.EventHandler(this.TxtWord_Enter);
            this.txtWord.Leave += new System.EventHandler(this.TxtWord_Leave);

            // txtDirectory
            this.txtDirectory.Location = new System.Drawing.Point(12, 38);
            this.txtDirectory.Size = new System.Drawing.Size(200, 20);
            this.txtDirectory.Text = "Выберите директорию";
            this.txtDirectory.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtDirectory.Enter += new System.EventHandler(this.TxtDirectory_Enter);
            this.txtDirectory.Leave += new System.EventHandler(this.TxtDirectory_Leave);

            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(220, 36);
            this.btnBrowse.Text = "Обзор";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(12, 64);
            this.btnSearch.Text = "Поиск";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // txtResult
            this.txtResult.Location = new System.Drawing.Point(12, 90);
            this.txtResult.Multiline = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(400, 200);

            // Form1
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtResult);
            this.Text = "Поиск слова в файлах";
            this.ResumeLayout(false);
        }

        private void TxtWord_Enter(object sender, EventArgs e)
        {
            if (txtWord.Text == "Введите слово для поиска")
            {
                txtWord.Text = "";
                txtWord.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void TxtWord_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWord.Text))
            {
                txtWord.Text = "Введите слово для поиска";
                txtWord.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void TxtDirectory_Enter(object sender, EventArgs e)
        {
            if (txtDirectory.Text == "Выберите директорию")
            {
                txtDirectory.Text = "";
                txtDirectory.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void TxtDirectory_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDirectory.Text))
            {
                txtDirectory.Text = "Выберите директорию";
                txtDirectory.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }
    }
}
