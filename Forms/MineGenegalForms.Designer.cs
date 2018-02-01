namespace Load_bank_files.Forms
{
    partial class MineGenegalForms
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.однодневкиСБToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гПББанкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очисткаТаблицСДаннымиБанковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сбарбанкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slectedUploadBanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneDayFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGPBBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGPBMSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSberbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.конфигурацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.seToolStripMenuItem,
            this.slectedUploadBanksToolStripMenuItem,
            this.workedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.конфигурацияToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // seToolStripMenuItem
            // 
            this.seToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTableToolStripMenuItem,
            this.очисткаТаблицСДаннымиБанковToolStripMenuItem});
            this.seToolStripMenuItem.Name = "seToolStripMenuItem";
            this.seToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.seToolStripMenuItem.Text = "Service";
            // 
            // clearTableToolStripMenuItem
            // 
            this.clearTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.однодневкиСБToolStripMenuItem,
            this.гПББанкToolStripMenuItem});
            this.clearTableToolStripMenuItem.Name = "clearTableToolStripMenuItem";
            this.clearTableToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.clearTableToolStripMenuItem.Text = "Очистка временных таблиц";
            // 
            // однодневкиСБToolStripMenuItem
            // 
            this.однодневкиСБToolStripMenuItem.Name = "однодневкиСБToolStripMenuItem";
            this.однодневкиСБToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.однодневкиСБToolStripMenuItem.Text = "Однодневки СБ";
            this.однодневкиСБToolStripMenuItem.Click += new System.EventHandler(this.однодневкиСБToolStripMenuItem_Click);
            // 
            // гПББанкToolStripMenuItem
            // 
            this.гПББанкToolStripMenuItem.Name = "гПББанкToolStripMenuItem";
            this.гПББанкToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.гПББанкToolStripMenuItem.Text = "ГПБ банк";
            // 
            // очисткаТаблицСДаннымиБанковToolStripMenuItem
            // 
            this.очисткаТаблицСДаннымиБанковToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сбарбанкToolStripMenuItem});
            this.очисткаТаблицСДаннымиБанковToolStripMenuItem.Name = "очисткаТаблицСДаннымиБанковToolStripMenuItem";
            this.очисткаТаблицСДаннымиБанковToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.очисткаТаблицСДаннымиБанковToolStripMenuItem.Text = "Очистка таблиц с данными банков";
            // 
            // сбарбанкToolStripMenuItem
            // 
            this.сбарбанкToolStripMenuItem.Name = "сбарбанкToolStripMenuItem";
            this.сбарбанкToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.сбарбанкToolStripMenuItem.Text = "Сбарбанк";
            this.сбарбанкToolStripMenuItem.Click += new System.EventHandler(this.сбарбанкToolStripMenuItem_Click);
            // 
            // slectedUploadBanksToolStripMenuItem
            // 
            this.slectedUploadBanksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadBankToolStripMenuItem,
            this.oneDayFilesToolStripMenuItem});
            this.slectedUploadBanksToolStripMenuItem.Name = "slectedUploadBanksToolStripMenuItem";
            this.slectedUploadBanksToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.slectedUploadBanksToolStripMenuItem.Text = "Windows";
            this.slectedUploadBanksToolStripMenuItem.Click += new System.EventHandler(this.slectedUploadBanksToolStripMenuItem_Click);
            // 
            // uploadBankToolStripMenuItem
            // 
            this.uploadBankToolStripMenuItem.Name = "uploadBankToolStripMenuItem";
            this.uploadBankToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.uploadBankToolStripMenuItem.Text = "UploadBank";
            this.uploadBankToolStripMenuItem.Click += new System.EventHandler(this.uploadBankToolStripMenuItem_Click);
            // 
            // oneDayFilesToolStripMenuItem
            // 
            this.oneDayFilesToolStripMenuItem.Name = "oneDayFilesToolStripMenuItem";
            this.oneDayFilesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.oneDayFilesToolStripMenuItem.Text = "OneDayFiles";
            this.oneDayFilesToolStripMenuItem.Click += new System.EventHandler(this.oneDayFilesToolStripMenuItem_Click);
            // 
            // workedToolStripMenuItem
            // 
            this.workedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGPBBankToolStripMenuItem,
            this.loadGPBMSKToolStripMenuItem,
            this.loadSberbankToolStripMenuItem});
            this.workedToolStripMenuItem.Name = "workedToolStripMenuItem";
            this.workedToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.workedToolStripMenuItem.Text = "Worked";
            // 
            // loadGPBBankToolStripMenuItem
            // 
            this.loadGPBBankToolStripMenuItem.Name = "loadGPBBankToolStripMenuItem";
            this.loadGPBBankToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadGPBBankToolStripMenuItem.Text = "Load GPB KLD";
            this.loadGPBBankToolStripMenuItem.Click += new System.EventHandler(this.loadGPBBankToolStripMenuItem_Click);
            // 
            // loadGPBMSKToolStripMenuItem
            // 
            this.loadGPBMSKToolStripMenuItem.Name = "loadGPBMSKToolStripMenuItem";
            this.loadGPBMSKToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadGPBMSKToolStripMenuItem.Text = "Load GPB MSK";
            this.loadGPBMSKToolStripMenuItem.Click += new System.EventHandler(this.loadGPBMSKToolStripMenuItem_Click);
            // 
            // loadSberbankToolStripMenuItem
            // 
            this.loadSberbankToolStripMenuItem.Name = "loadSberbankToolStripMenuItem";
            this.loadSberbankToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadSberbankToolStripMenuItem.Text = "Load Sberbank";
            this.loadSberbankToolStripMenuItem.Click += new System.EventHandler(this.loadSberbankToolStripMenuItem_Click);
            // 
            // конфигурацияToolStripMenuItem
            // 
            this.конфигурацияToolStripMenuItem.Name = "конфигурацияToolStripMenuItem";
            this.конфигурацияToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.конфигурацияToolStripMenuItem.Text = "Конфигурация";
            this.конфигурацияToolStripMenuItem.Click += new System.EventHandler(this.конфигурацияToolStripMenuItem_Click);
            // 
            // MineGenegalForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 706);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MineGenegalForms";
            this.Text = "Формирователь данных банков для обработки";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slectedUploadBanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneDayFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem однодневкиСБToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гПББанкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очисткаТаблицСДаннымиБанковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сбарбанкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGPBBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGPBMSKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSberbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem конфигурацияToolStripMenuItem;
    }
}