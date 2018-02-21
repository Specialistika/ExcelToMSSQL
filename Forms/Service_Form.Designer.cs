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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pathSAPtextBox = new System.Windows.Forms.TextBox();
			this.tab_closed = new System.Windows.Forms.Button();
			this.uploadDirTextBox = new System.Windows.Forms.TextBox();
			this.connStringTextBox = new System.Windows.Forms.TextBox();
			this.yearTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.monthTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.timeTextBox = new System.Windows.Forms.TextBox();
			this.expantionTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.connectionBaseTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(187, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Путь к директории для данных SAP";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 155);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Cоединрение с главной базой";
			// 
			// pathSAPtextBox
			// 
			this.pathSAPtextBox.Location = new System.Drawing.Point(23, 128);
			this.pathSAPtextBox.Name = "pathSAPtextBox";
			this.pathSAPtextBox.Size = new System.Drawing.Size(449, 20);
			this.pathSAPtextBox.TabIndex = 4;
			this.pathSAPtextBox.DoubleClick += new System.EventHandler(this.pathSAPtextBox_DoubleClick_1);
			this.pathSAPtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pathSAPtextBox_KeyDown);
			// 
			// tab_closed
			// 
			this.tab_closed.Location = new System.Drawing.Point(397, 258);
			this.tab_closed.Name = "tab_closed";
			this.tab_closed.Size = new System.Drawing.Size(75, 23);
			this.tab_closed.TabIndex = 6;
			this.tab_closed.Text = "Ok";
			this.tab_closed.UseVisualStyleBackColor = true;
			this.tab_closed.Click += new System.EventHandler(this.tab_closed_Click);
			// 
			// uploadDirTextBox
			// 
			this.uploadDirTextBox.Location = new System.Drawing.Point(23, 28);
			this.uploadDirTextBox.Name = "uploadDirTextBox";
			this.uploadDirTextBox.Size = new System.Drawing.Size(449, 20);
			this.uploadDirTextBox.TabIndex = 9;
			this.uploadDirTextBox.DoubleClick += new System.EventHandler(this.uploadDirTextBox_DoubleClick);
			this.uploadDirTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uploadDirTextBox_KeyDown);
			// 
			// connStringTextBox
			// 
			this.connStringTextBox.Location = new System.Drawing.Point(23, 214);
			this.connStringTextBox.Name = "connStringTextBox";
			this.connStringTextBox.Size = new System.Drawing.Size(449, 20);
			this.connStringTextBox.TabIndex = 10;
			this.connStringTextBox.DoubleClick += new System.EventHandler(this.connStringTextBox_DoubleClick);
			this.connStringTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connStringTextBox_KeyDown);
			// 
			// yearTextBox
			// 
			this.yearTextBox.Location = new System.Drawing.Point(23, 77);
			this.yearTextBox.Name = "yearTextBox";
			this.yearTextBox.Size = new System.Drawing.Size(59, 20);
			this.yearTextBox.TabIndex = 11;
			this.yearTextBox.DoubleClick += new System.EventHandler(this.yearTextBox_DoubleClick);
			this.yearTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yearTextBox_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(143, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Директория по умолчанию";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 197);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(169, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Соединение с временной базой";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(25, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Год";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(100, 60);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Месяц";
			// 
			// monthTextBox
			// 
			this.monthTextBox.Location = new System.Drawing.Point(97, 77);
			this.monthTextBox.Name = "monthTextBox";
			this.monthTextBox.Size = new System.Drawing.Size(59, 20);
			this.monthTextBox.TabIndex = 15;
			this.monthTextBox.DoubleClick += new System.EventHandler(this.monthTextBox_DoubleClick);
			this.monthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthTextBox_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(163, 60);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(160, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Время таймаута для загрузки";
			// 
			// timeTextBox
			// 
			this.timeTextBox.Location = new System.Drawing.Point(203, 78);
			this.timeTextBox.Name = "timeTextBox";
			this.timeTextBox.Size = new System.Drawing.Size(59, 20);
			this.timeTextBox.TabIndex = 17;
			this.timeTextBox.DoubleClick += new System.EventHandler(this.timeTextBox_DoubleClick);
			this.timeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timeTextBox_KeyDown);
			// 
			// expantionTextBox
			// 
			this.expantionTextBox.Location = new System.Drawing.Point(325, 78);
			this.expantionTextBox.Name = "expantionTextBox";
			this.expantionTextBox.Size = new System.Drawing.Size(150, 20);
			this.expantionTextBox.TabIndex = 19;
			this.expantionTextBox.DoubleClick += new System.EventHandler(this.expantionTextBox_DoubleClick);
			this.expantionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expantionTextBox_KeyDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(329, 60);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(105, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Расширение фалов";
			// 
			// connectionBaseTextBox
			// 
			this.connectionBaseTextBox.Location = new System.Drawing.Point(24, 172);
			this.connectionBaseTextBox.Name = "connectionBaseTextBox";
			this.connectionBaseTextBox.Size = new System.Drawing.Size(449, 20);
			this.connectionBaseTextBox.TabIndex = 21;
			this.connectionBaseTextBox.DoubleClick += new System.EventHandler(this.connectionBaseTextBox_DoubleClick_1);
			this.connectionBaseTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connectionBaseTextBox_KeyDown_1);
			// 
			// Service_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 302);
			this.Controls.Add(this.connectionBaseTextBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.expantionTextBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.timeTextBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.monthTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.yearTextBox);
			this.Controls.Add(this.connStringTextBox);
			this.Controls.Add(this.uploadDirTextBox);
			this.Controls.Add(this.tab_closed);
			this.Controls.Add(this.pathSAPtextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Name = "Service_Form";
			this.Text = "`";
			this.Load += new System.EventHandler(this.Service_Form_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pathSAPtextBox;
        private System.Windows.Forms.Button tab_closed;
        private System.Windows.Forms.TextBox uploadDirTextBox;
        private System.Windows.Forms.TextBox connStringTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox timeTextBox;
		private System.Windows.Forms.TextBox expantionTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox connectionBaseTextBox;
	}
}