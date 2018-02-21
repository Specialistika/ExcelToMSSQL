namespace Load_bank_files.Forms
{
    partial class oneDayFiles
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
            this.DtGridOneDay = new System.Windows.Forms.DataGridView();
            this.buttonRunProces = new System.Windows.Forms.Button();
            this.buttonClosed = new System.Windows.Forms.Button();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.selectFileslabel = new System.Windows.Forms.Label();
            this.selectFilesTextBox = new System.Windows.Forms.TextBox();
            this.countlistBox = new System.Windows.Forms.ListBox();
            this.uploadMineButton = new System.Windows.Forms.Button();
            this.progressBarOneDaysFiles = new System.Windows.Forms.ProgressBar();
            this.timerOneDaysFiles = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DtGridOneDay)).BeginInit();
            this.SuspendLayout();
            // 
            // DtGridOneDay
            // 
            this.DtGridOneDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtGridOneDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DtGridOneDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGridOneDay.Location = new System.Drawing.Point(12, 12);
            this.DtGridOneDay.Name = "DtGridOneDay";
            this.DtGridOneDay.Size = new System.Drawing.Size(515, 359);
            this.DtGridOneDay.TabIndex = 0;
            // 
            // buttonRunProces
            // 
            this.buttonRunProces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRunProces.Location = new System.Drawing.Point(105, 380);
            this.buttonRunProces.Name = "buttonRunProces";
            this.buttonRunProces.Size = new System.Drawing.Size(75, 23);
            this.buttonRunProces.TabIndex = 2;
            this.buttonRunProces.Text = "Обработать";
            this.buttonRunProces.UseVisualStyleBackColor = true;
            this.buttonRunProces.Click += new System.EventHandler(this.buttonRunProces_Click);
            // 
            // buttonClosed
            // 
            this.buttonClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClosed.Location = new System.Drawing.Point(706, 380);
            this.buttonClosed.Name = "buttonClosed";
            this.buttonClosed.Size = new System.Drawing.Size(75, 23);
            this.buttonClosed.TabIndex = 3;
            this.buttonClosed.Text = "Закрыть";
            this.buttonClosed.UseVisualStyleBackColor = true;
            this.buttonClosed.Click += new System.EventHandler(this.buttonClosed_Click);
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectFiles.Location = new System.Drawing.Point(13, 380);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFiles.TabIndex = 4;
            this.buttonSelectFiles.Text = "Выбрать";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.buttonSelectFiles_ClickAsync);
            // 
            // selectFileslabel
            // 
            this.selectFileslabel.AutoSize = true;
            this.selectFileslabel.Location = new System.Drawing.Point(557, 330);
            this.selectFileslabel.Name = "selectFileslabel";
            this.selectFileslabel.Size = new System.Drawing.Size(0, 13);
            this.selectFileslabel.TabIndex = 6;
            // 
            // selectFilesTextBox
            // 
            this.selectFilesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFilesTextBox.Location = new System.Drawing.Point(533, 12);
            this.selectFilesTextBox.Multiline = true;
            this.selectFilesTextBox.Name = "selectFilesTextBox";
            this.selectFilesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.selectFilesTextBox.Size = new System.Drawing.Size(248, 76);
            this.selectFilesTextBox.TabIndex = 7;
            // 
            // countlistBox
            // 
            this.countlistBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countlistBox.FormattingEnabled = true;
            this.countlistBox.Location = new System.Drawing.Point(533, 94);
            this.countlistBox.Name = "countlistBox";
            this.countlistBox.Size = new System.Drawing.Size(248, 277);
            this.countlistBox.TabIndex = 8;
            // 
            // uploadMineButton
            // 
            this.uploadMineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uploadMineButton.Location = new System.Drawing.Point(205, 380);
            this.uploadMineButton.Name = "uploadMineButton";
            this.uploadMineButton.Size = new System.Drawing.Size(75, 23);
            this.uploadMineButton.TabIndex = 9;
            this.uploadMineButton.Text = "Выгрузка";
            this.uploadMineButton.UseVisualStyleBackColor = true;
            this.uploadMineButton.Click += new System.EventHandler(this.uploadMineButton_Click);
            // 
            // progressBarOneDaysFiles
            // 
            this.progressBarOneDaysFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarOneDaysFiles.Location = new System.Drawing.Point(299, 380);
            this.progressBarOneDaysFiles.Name = "progressBarOneDaysFiles";
            this.progressBarOneDaysFiles.Size = new System.Drawing.Size(228, 23);
            this.progressBarOneDaysFiles.TabIndex = 10;
            // 
            // timerOneDaysFiles
            // 
            this.timerOneDaysFiles.Tick += new System.EventHandler(this.timerOneDaysFiles_Tick);
            // 
            // oneDayFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 415);
            this.Controls.Add(this.progressBarOneDaysFiles);
            this.Controls.Add(this.uploadMineButton);
            this.Controls.Add(this.countlistBox);
            this.Controls.Add(this.selectFilesTextBox);
            this.Controls.Add(this.selectFileslabel);
            this.Controls.Add(this.buttonSelectFiles);
            this.Controls.Add(this.buttonClosed);
            this.Controls.Add(this.buttonRunProces);
            this.Controls.Add(this.DtGridOneDay);
            this.Name = "oneDayFiles";
            this.Text = "oneDayFiles";
            this.Load += new System.EventHandler(this.oneDayFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtGridOneDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtGridOneDay;
        private System.Windows.Forms.Button buttonRunProces;
        private System.Windows.Forms.Button buttonClosed;
        private System.Windows.Forms.Button buttonSelectFiles;
        private System.Windows.Forms.Label selectFileslabel;
        private System.Windows.Forms.TextBox selectFilesTextBox;
        private System.Windows.Forms.ListBox countlistBox;
        private System.Windows.Forms.Button uploadMineButton;
        private System.Windows.Forms.ProgressBar progressBarOneDaysFiles;
        private System.Windows.Forms.Timer timerOneDaysFiles;
    }
}