namespace Load_bank_files.Forms
{
    partial class TrimExcelForm
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
			this.TrimListButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.TrimFilesButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.countTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.countFilesTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// TrimListButton
			// 
			this.TrimListButton.Location = new System.Drawing.Point(21, 28);
			this.TrimListButton.Name = "TrimListButton";
			this.TrimListButton.Size = new System.Drawing.Size(90, 23);
			this.TrimListButton.TabIndex = 0;
			this.TrimListButton.Text = "Выбрать";
			this.TrimListButton.UseVisualStyleBackColor = true;
			this.TrimListButton.Click += new System.EventHandler(this.TrimListButton_ClickAsync);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(180, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Деленеие листов книги на файлы";
			// 
			// TrimFilesButton
			// 
			this.TrimFilesButton.Location = new System.Drawing.Point(20, 148);
			this.TrimFilesButton.Name = "TrimFilesButton";
			this.TrimFilesButton.Size = new System.Drawing.Size(91, 23);
			this.TrimFilesButton.TabIndex = 2;
			this.TrimFilesButton.Text = "Выбрать";
			this.TrimFilesButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Деление файлов по количеству строк";
			// 
			// countTextBox
			// 
			this.countTextBox.Location = new System.Drawing.Point(117, 150);
			this.countTextBox.Name = "countTextBox";
			this.countTextBox.Size = new System.Drawing.Size(100, 20);
			this.countTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(114, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Задать количество";
			// 
			// countFilesTextBox
			// 
			this.countFilesTextBox.Location = new System.Drawing.Point(239, 13);
			this.countFilesTextBox.Multiline = true;
			this.countFilesTextBox.Name = "countFilesTextBox";
			this.countFilesTextBox.Size = new System.Drawing.Size(222, 71);
			this.countFilesTextBox.TabIndex = 7;
			// 
			// TrimExcelForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 190);
			this.Controls.Add(this.countFilesTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.countTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TrimFilesButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TrimListButton);
			this.Name = "TrimExcelForm";
			this.Text = "Конструктор файлов";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TrimListButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TrimFilesButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countFilesTextBox;
    }
}