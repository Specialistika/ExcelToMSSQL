namespace Load_bank_files.Forms
{
    partial class WorksBankForm
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
            this.TxtCountRow = new System.Windows.Forms.TextBox();
            this.threadProgressBar = new System.Windows.Forms.ProgressBar();
            this.FileLoad = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.loadMineTablebutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveTable = new System.Windows.Forms.Button();
            this.sb_txt = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_gpb_kld = new System.Windows.Forms.Button();
            this.btn_gpb_msk = new System.Windows.Forms.Button();
            this.Text_vtb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_vtb_kld = new System.Windows.Forms.Button();
            this.BankTableDtGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.procesTimer = new System.Windows.Forms.Timer(this.components);
            this.dataBinding = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankTableDtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCountRow
            // 
            this.TxtCountRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCountRow.Location = new System.Drawing.Point(240, 1);
            this.TxtCountRow.Name = "TxtCountRow";
            this.TxtCountRow.Size = new System.Drawing.Size(100, 20);
            this.TxtCountRow.TabIndex = 14;
            // 
            // threadProgressBar
            // 
            this.threadProgressBar.Location = new System.Drawing.Point(524, 597);
            this.threadProgressBar.Name = "threadProgressBar";
            this.threadProgressBar.Size = new System.Drawing.Size(304, 23);
            this.threadProgressBar.TabIndex = 18;
            // 
            // FileLoad
            // 
            this.FileLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileLoad.FormattingEnabled = true;
            this.FileLoad.Location = new System.Drawing.Point(643, 27);
            this.FileLoad.Name = "FileLoad";
            this.FileLoad.Size = new System.Drawing.Size(185, 394);
            this.FileLoad.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 427);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(499, 196);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.loadMineTablebutton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SaveTable);
            this.tabPage1.Controls.Add(this.sb_txt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сбербанк";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Загрузка в основную таблицу";
            // 
            // loadMineTablebutton
            // 
            this.loadMineTablebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadMineTablebutton.Location = new System.Drawing.Point(50, 125);
            this.loadMineTablebutton.Name = "loadMineTablebutton";
            this.loadMineTablebutton.Size = new System.Drawing.Size(93, 23);
            this.loadMineTablebutton.TabIndex = 9;
            this.loadMineTablebutton.Text = "Загрузить";
            this.loadMineTablebutton.UseVisualStyleBackColor = true;
            this.loadMineTablebutton.Click += new System.EventHandler(this.loadMineTablebutton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Формирование временной таблицы";
            // 
            // SaveTable
            // 
            this.SaveTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveTable.Location = new System.Drawing.Point(50, 54);
            this.SaveTable.Name = "SaveTable";
            this.SaveTable.Size = new System.Drawing.Size(93, 23);
            this.SaveTable.TabIndex = 4;
            this.SaveTable.Text = "Сформировать";
            this.SaveTable.UseVisualStyleBackColor = true;
            this.SaveTable.Click += new System.EventHandler(this.SaveTable_Click);
            // 
            // sb_txt
            // 
            this.sb_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sb_txt.Location = new System.Drawing.Point(220, 24);
            this.sb_txt.Multiline = true;
            this.sb_txt.Name = "sb_txt";
            this.sb_txt.Size = new System.Drawing.Size(265, 140);
            this.sb_txt.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_gpb_kld);
            this.tabPage2.Controls.Add(this.btn_gpb_msk);
            this.tabPage2.Controls.Add(this.Text_vtb);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btn_vtb_kld);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(491, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ВТБ_ГПБ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_gpb_kld
            // 
            this.btn_gpb_kld.Location = new System.Drawing.Point(33, 104);
            this.btn_gpb_kld.Name = "btn_gpb_kld";
            this.btn_gpb_kld.Size = new System.Drawing.Size(118, 23);
            this.btn_gpb_kld.TabIndex = 4;
            this.btn_gpb_kld.Text = "Загрузка ГПБ_КЛД";
            this.btn_gpb_kld.UseVisualStyleBackColor = true;
            // 
            // btn_gpb_msk
            // 
            this.btn_gpb_msk.Location = new System.Drawing.Point(33, 74);
            this.btn_gpb_msk.Name = "btn_gpb_msk";
            this.btn_gpb_msk.Size = new System.Drawing.Size(118, 23);
            this.btn_gpb_msk.TabIndex = 3;
            this.btn_gpb_msk.Text = "Загрузка ГПБ_МСК";
            this.btn_gpb_msk.UseVisualStyleBackColor = true;
            this.btn_gpb_msk.Click += new System.EventHandler(this.btn_gpb_msk_Click_1);
            // 
            // Text_vtb
            // 
            this.Text_vtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text_vtb.Location = new System.Drawing.Point(210, 15);
            this.Text_vtb.Multiline = true;
            this.Text_vtb.Name = "Text_vtb";
            this.Text_vtb.Size = new System.Drawing.Size(265, 140);
            this.Text_vtb.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Загрузка данных в основную базу";
            // 
            // btn_vtb_kld
            // 
            this.btn_vtb_kld.Location = new System.Drawing.Point(33, 45);
            this.btn_vtb_kld.Name = "btn_vtb_kld";
            this.btn_vtb_kld.Size = new System.Drawing.Size(118, 23);
            this.btn_vtb_kld.TabIndex = 0;
            this.btn_vtb_kld.Text = "Загрузка ВТБ_КЛД";
            this.btn_vtb_kld.UseVisualStyleBackColor = true;
            this.btn_vtb_kld.Click += new System.EventHandler(this.btn_vtb_kld_Click);
            // 
            // BankTableDtGrid
            // 
            this.BankTableDtGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BankTableDtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BankTableDtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BankTableDtGrid.Location = new System.Drawing.Point(12, 26);
            this.BankTableDtGrid.Name = "BankTableDtGrid";
            this.BankTableDtGrid.Size = new System.Drawing.Size(613, 395);
            this.BankTableDtGrid.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Задайте количество отображаемых строк";
            // 
            // WorksBankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 635);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BankTableDtGrid);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.threadProgressBar);
            this.Controls.Add(this.FileLoad);
            this.Controls.Add(this.TxtCountRow);
            this.Name = "WorksBankForm";
            this.Text = "Формирование и отправка данных ГПБ и СБ банков для обработки";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankTableDtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtCountRow;
        private System.Windows.Forms.ProgressBar threadProgressBar;
        private System.Windows.Forms.ListBox FileLoad;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox sb_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadMineTablebutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveTable;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_gpb_kld;
        private System.Windows.Forms.Button btn_gpb_msk;
        private System.Windows.Forms.TextBox Text_vtb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_vtb_kld;
        private System.Windows.Forms.DataGridView BankTableDtGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer procesTimer;
        private System.Windows.Forms.BindingSource dataBinding;
    }
}