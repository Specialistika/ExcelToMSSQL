namespace Load_bank_files.Forms
{
    partial class Service_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.path_bank = new System.Windows.Forms.TextBox();
            this.path_sap = new System.Windows.Forms.TextBox();
            this.path_con = new System.Windows.Forms.TextBox();
            this.tab_closed = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.Bank_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к директории на сервере для банков";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Путь к директории для данных SAP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cоединрение с базой";
            // 
            // path_bank
            // 
            this.path_bank.Location = new System.Drawing.Point(30, 38);
            this.path_bank.Name = "path_bank";
            this.path_bank.Size = new System.Drawing.Size(440, 20);
            this.path_bank.TabIndex = 3;
            // 
            // path_sap
            // 
            this.path_sap.Location = new System.Drawing.Point(30, 89);
            this.path_sap.Name = "path_sap";
            this.path_sap.Size = new System.Drawing.Size(440, 20);
            this.path_sap.TabIndex = 4;
            // 
            // path_con
            // 
            this.path_con.Location = new System.Drawing.Point(30, 141);
            this.path_con.Name = "path_con";
            this.path_con.Size = new System.Drawing.Size(440, 20);
            this.path_con.TabIndex = 5;
            // 
            // tab_closed
            // 
            this.tab_closed.Location = new System.Drawing.Point(395, 224);
            this.tab_closed.Name = "tab_closed";
            this.tab_closed.Size = new System.Drawing.Size(75, 23);
            this.tab_closed.TabIndex = 6;
            this.tab_closed.Text = "Cancel";
            this.tab_closed.UseVisualStyleBackColor = true;
            this.tab_closed.Click += new System.EventHandler(this.tab_closed_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(289, 226);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 7;
            this.save_btn.Text = "Ok";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // Bank_checkedListBox
            // 
            this.Bank_checkedListBox.CheckOnClick = true;
            this.Bank_checkedListBox.FormattingEnabled = true;
            this.Bank_checkedListBox.Items.AddRange(new object[] {
            "СБ",
            "ВТБ-МСК",
            "ВТБ-КЛД",
            "ГПБ-МСК",
            "ГПБ-КЛД"});
            this.Bank_checkedListBox.Location = new System.Drawing.Point(30, 168);
            this.Bank_checkedListBox.Name = "Bank_checkedListBox";
            this.Bank_checkedListBox.Size = new System.Drawing.Size(83, 79);
            this.Bank_checkedListBox.TabIndex = 8;
            // 
            // Service_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 261);
            this.Controls.Add(this.Bank_checkedListBox);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.tab_closed);
            this.Controls.Add(this.path_con);
            this.Controls.Add(this.path_sap);
            this.Controls.Add(this.path_bank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Service_Form";
            this.Text = "Сервисное окно";
            this.Load += new System.EventHandler(this.Service_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox path_bank;
        private System.Windows.Forms.TextBox path_sap;
        private System.Windows.Forms.TextBox path_con;
        private System.Windows.Forms.Button tab_closed;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.CheckedListBox Bank_checkedListBox;
    }
}