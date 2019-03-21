namespace Load_bank_files
{
    partial class UploadBanksFiles
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
            this.FileLoad = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtGrid = new System.Windows.Forms.DataGridView();
            this.TxtCountRow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_gpb_kld = new System.Windows.Forms.Button();
            this.btn_gpb_msk = new System.Windows.Forms.Button();
            this.Text_vtb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_vtb_kld = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sb_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveTable = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.threadProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.BindingLocal = new System.Windows.Forms.BindingSource(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGPBKLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGPBMSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadVTBKLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формированиеОднодневокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конфигурацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.DtGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingLocal)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileLoad
            // 
            this.FileLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileLoad.FormattingEnabled = true;
            this.FileLoad.Location = new System.Drawing.Point(650, 24);
            this.FileLoad.Name = "FileLoad";
            this.FileLoad.Size = new System.Drawing.Size(185, 381);
            this.FileLoad.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество возвращаемых данных";
            this.label1.Visible = false;
            // 
            // DtGrid
            // 
            this.DtGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGrid.Location = new System.Drawing.Point(15, 27);
            this.DtGrid.Name = "DtGrid";
            this.DtGrid.Size = new System.Drawing.Size(615, 387);
            this.DtGrid.TabIndex = 11;
            this.DtGrid.SelectionChanged += new System.EventHandler(this.DtGrid_SelectionChanged);
            // 
            // TxtCountRow
            // 
            this.TxtCountRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCountRow.Location = new System.Drawing.Point(530, 4);
            this.TxtCountRow.Name = "TxtCountRow";
            this.TxtCountRow.Size = new System.Drawing.Size(100, 20);
            this.TxtCountRow.TabIndex = 13;
            this.TxtCountRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCountRow_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Задайте количество строк";
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
            this.btn_gpb_kld.Click += new System.EventHandler(this.btn_gpb_kld_Click);
            // 
            // btn_gpb_msk
            // 
            this.btn_gpb_msk.Location = new System.Drawing.Point(33, 74);
            this.btn_gpb_msk.Name = "btn_gpb_msk";
            this.btn_gpb_msk.Size = new System.Drawing.Size(118, 23);
            this.btn_gpb_msk.TabIndex = 3;
            this.btn_gpb_msk.Text = "Загрузка ГПБ_МСК";
            this.btn_gpb_msk.UseVisualStyleBackColor = true;
            this.btn_gpb_msk.Click += new System.EventHandler(this.btn_gpb_msk_Click);
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
            this.btn_vtb_kld.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.sb_txt);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SaveTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сбербанк";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // sb_txt
            // 
            this.sb_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sb_txt.Location = new System.Drawing.Point(210, 15);
            this.sb_txt.Multiline = true;
            this.sb_txt.Name = "sb_txt";
            this.sb_txt.Size = new System.Drawing.Size(265, 140);
            this.sb_txt.TabIndex = 11;
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
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(50, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.SaveTable.Click += new System.EventHandler(this.UploadtempDevButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 420);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(499, 196);
            this.tabControl1.TabIndex = 12;
            // 
            // threadProgressBar
            // 
            this.threadProgressBar.Location = new System.Drawing.Point(531, 593);
            this.threadProgressBar.Name = "threadProgressBar";
            this.threadProgressBar.Size = new System.Drawing.Size(304, 23);
            this.threadProgressBar.TabIndex = 15;
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGPBKLDToolStripMenuItem,
            this.loadGPBMSKToolStripMenuItem,
            this.loadSBToolStripMenuItem,
            this.loadVTBKLDToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // loadGPBKLDToolStripMenuItem
            // 
            this.loadGPBKLDToolStripMenuItem.Name = "loadGPBKLDToolStripMenuItem";
            this.loadGPBKLDToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadGPBKLDToolStripMenuItem.Text = "Load_GPB_KLD";
            this.loadGPBKLDToolStripMenuItem.Click += new System.EventHandler(this.loadGPBKLDToolStripMenuItem_Click_1);
            // 
            // loadGPBMSKToolStripMenuItem
            // 
            this.loadGPBMSKToolStripMenuItem.Name = "loadGPBMSKToolStripMenuItem";
            this.loadGPBMSKToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadGPBMSKToolStripMenuItem.Text = "Load_GPB_MSK";
            this.loadGPBMSKToolStripMenuItem.Click += new System.EventHandler(this.loadGPBMSKToolStripMenuItem_Click_1);
            // 
            // loadSBToolStripMenuItem
            // 
            this.loadSBToolStripMenuItem.Name = "loadSBToolStripMenuItem";
            this.loadSBToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadSBToolStripMenuItem.Text = "Load_SB";
            this.loadSBToolStripMenuItem.Click += new System.EventHandler(this.loadSBToolStripMenuItem_Click);
            // 
            // loadVTBKLDToolStripMenuItem
            // 
            this.loadVTBKLDToolStripMenuItem.Name = "loadVTBKLDToolStripMenuItem";
            this.loadVTBKLDToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadVTBKLDToolStripMenuItem.Text = "Load_VTB_KLD";
            this.loadVTBKLDToolStripMenuItem.Click += new System.EventHandler(this.loadVTBKLDToolStripMenuItem_Click_1);
            // 
            // setviceToolStripMenuItem
            // 
            this.setviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.формированиеОднодневокToolStripMenuItem,
            this.конфигурацияToolStripMenuItem});
            this.setviceToolStripMenuItem.Name = "setviceToolStripMenuItem";
            this.setviceToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.setviceToolStripMenuItem.Text = "Service";
            this.setviceToolStripMenuItem.Click += new System.EventHandler(this.setviceToolStripMenuItem_Click);
            // 
            // формированиеОднодневокToolStripMenuItem
            // 
            this.формированиеОднодневокToolStripMenuItem.Name = "формированиеОднодневокToolStripMenuItem";
            this.формированиеОднодневокToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.формированиеОднодневокToolStripMenuItem.Text = "Формирование однодневок";
            this.формированиеОднодневокToolStripMenuItem.Click += new System.EventHandler(this.формированиеОднодневокToolStripMenuItem_Click);
            // 
            // конфигурацияToolStripMenuItem
            // 
            this.конфигурацияToolStripMenuItem.Name = "конфигурацияToolStripMenuItem";
            this.конфигурацияToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.конфигурацияToolStripMenuItem.Text = "Конфигурация";
            this.конфигурацияToolStripMenuItem.Click += new System.EventHandler(this.конфигурацияToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.setviceToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(860, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // UploadBanksFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(860, 631);
            this.Controls.Add(this.threadProgressBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtCountRow);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DtGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileLoad);
            this.Controls.Add(this.menuStrip2);
            this.Name = "UploadBanksFiles";
            this.Text = "Загрузка данных банков";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Mine_forms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BindingLocal)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox FileLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtGrid;
        private System.Windows.Forms.BindingSource BindingLocal;
        private System.Windows.Forms.TextBox TxtCountRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_gpb_kld;
        private System.Windows.Forms.Button btn_gpb_msk;
        private System.Windows.Forms.TextBox Text_vtb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_vtb_kld;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox sb_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ProgressBar threadProgressBar;
        public System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGPBKLDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGPBMSKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadVTBKLDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem формированиеОднодневокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конфигурацияToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
    }
}

