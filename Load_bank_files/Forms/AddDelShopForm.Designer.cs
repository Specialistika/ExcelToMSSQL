namespace Load_bank_files.Forms
{
	partial class AddDelShopForm
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
			this.showShopListBox = new System.Windows.Forms.ListBox();
			this.shopTextBox = new System.Windows.Forms.TextBox();
			this.IpTextBox = new System.Windows.Forms.TextBox();
			this.delButton = new System.Windows.Forms.Button();
			this.createButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// showShopListBox
			// 
			this.showShopListBox.FormattingEnabled = true;
			this.showShopListBox.Location = new System.Drawing.Point(189, 19);
			this.showShopListBox.Name = "showShopListBox";
			this.showShopListBox.Size = new System.Drawing.Size(206, 290);
			this.showShopListBox.TabIndex = 0;
			// 
			// shopTextBox
			// 
			this.shopTextBox.Location = new System.Drawing.Point(15, 44);
			this.shopTextBox.Name = "shopTextBox";
			this.shopTextBox.Size = new System.Drawing.Size(144, 20);
			this.shopTextBox.TabIndex = 1;
			// 
			// IpTextBox
			// 
			this.IpTextBox.Location = new System.Drawing.Point(15, 96);
			this.IpTextBox.Name = "IpTextBox";
			this.IpTextBox.Size = new System.Drawing.Size(144, 20);
			this.IpTextBox.TabIndex = 2;
			// 
			// delButton
			// 
			this.delButton.Location = new System.Drawing.Point(12, 286);
			this.delButton.Name = "delButton";
			this.delButton.Size = new System.Drawing.Size(77, 23);
			this.delButton.TabIndex = 3;
			this.delButton.Text = "Удалить";
			this.delButton.UseVisualStyleBackColor = true;
			// 
			// createButton
			// 
			this.createButton.Location = new System.Drawing.Point(93, 286);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(77, 23);
			this.createButton.TabIndex = 4;
			this.createButton.Text = "Добавить";
			this.createButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Ведите название магазина";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Введите IP магазина";
			// 
			// AddDelShopForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(411, 327);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.delButton);
			this.Controls.Add(this.IpTextBox);
			this.Controls.Add(this.shopTextBox);
			this.Controls.Add(this.showShopListBox);
			this.Name = "AddDelShopForm";
			this.Text = "Добавление/удаление магазинов";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox showShopListBox;
		private System.Windows.Forms.TextBox shopTextBox;
		private System.Windows.Forms.TextBox IpTextBox;
		private System.Windows.Forms.Button delButton;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}