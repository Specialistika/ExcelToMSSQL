using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Load_bank_files.Data;
using Load_bank_files.Class.GUI;
using Load_bank_files.Class.DayDoc;
using Load_bank_files.Class.Load_Data;
using Load_bank_files.Class.loadMineTable;
using Load_bank_files.Class.config;

namespace Load_bank_files.Forms
{
	public partial class UploadDayFiles : Form, IProgress<Tuple<int, int>>
	{
		private OpenFileDialog openFileDialog = new OpenFileDialog();
		private delegate int threadCountDelegate();
		private delegate void InvokeDelegate();
		private BindingSource Bind = new BindingSource();
		private SqlDataAdapter dataAdapter = new SqlDataAdapter();
		private static UploadDayFiles oneDayFile = null;
		private static string rowCountDel;
		private static string rowCountAdd;
		private ListBox countlistBox;
		private TextBox selectFilesTextBox;
		private Button buttonSelectFiles;
		private Button oneDayFiles;
		private Button buttonRunProces;
		private DataGridView DtGridOneDay;
		private System.Windows.Forms.Timer timerOneDaysFiles;
		private System.ComponentModel.IContainer components;
		private ProgressBar progressBarOneDaysFiles;
		private static string rowCountDub;

		public static UploadDayFiles GetInstance()
		{
			if (oneDayFile == null)
				oneDayFile = new UploadDayFiles();

			return oneDayFile;
		}

		public UploadDayFiles()
		{
			InitializeComponent();
			GUIController.setForm(this);

			openFileDialog.InitialDirectory = variable_config.dirUploadFiles;
			openFileDialog.Filter = variable_config.GetexpansionFile;
			openFileDialog.FilterIndex = 2;
			openFileDialog.Multiselect = true;
			openFileDialog.RestoreDirectory = true;

			countlistBox.HorizontalScrollbar = true;
			countlistBox.FormattingEnabled = true;
			countlistBox.ScrollAlwaysVisible = true;
			selectFilesTextBox.ReadOnly = true;
			m_SynchronizationContext = SynchronizationContext.Current;
		}

		private SynchronizationContext m_SynchronizationContext;
		private DateTime m_PreviousTime = DateTime.Now;

		private async void buttonSelectFiles_ClickAsync(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				int i = 1;
				int selectCount = openFileDialog.FileNames.Length;
				selectFilesTextBox.BeginInvoke(new InvokeDelegate(() =>
					selectFilesTextBox.AppendText("Количество выбранных файлов: " + selectCount + Environment.NewLine)));
				foreach (var file in openFileDialog.FileNames)
				{
					try
					{
						await ExcelToTempbaseAsync(file);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ошибка: " + ex.Message);
					}
					Report(new Tuple<int, int>(selectCount, i++));
				}
			}
			await Task.Factory.StartNew(() => DtGridOneDay_load());
		}

		public async Task ExcelToTempbaseAsync(string file)
		{
			await Task.Factory.StartNew(() => oneDaydoc.OneDayfiles(file), TaskCreationOptions.LongRunning);
		}

		public void Report(Tuple<int, int> value)
		{
			var now = DateTime.Now;

			if ((now - m_PreviousTime).Milliseconds > 20)
			{
				m_SynchronizationContext.Post((@object) =>
				{
					Tuple<int, int> minMax = (Tuple<int, int>)@object;
					progressBarOneDaysFiles.Maximum = minMax.Item1;
					progressBarOneDaysFiles.Value = minMax.Item2;
				}, value);

				m_PreviousTime = now;
			}
		}

		private void countFileStatistic(string countRaw, string nameFiles)
		{
			object[] DataSetListbox = { nameFiles + " - " + countRaw };
			try
			{
				if (countRaw != null)
				{
					if (InvokeRequired)
					{
						Invoke(new Action<string, string>(countFileStatistic), new object[] { countRaw, nameFiles });
						return;
					}

					countlistBox.BeginInvoke(new InvokeDelegate(() => countlistBox.Items.AddRange(DataSetListbox)));
				}
				this.countlistBox.Refresh();
			}
			catch (Exception b)
			{
				MessageBox.Show(b.Message);
			}
		}
		public void SampleFunction(string countRaw, string nameFiles)
		{
			try
			{
				Thread TR = new Thread(delegate ()
			   {
				   countFileStatistic(countRaw, nameFiles);
			   });
				TR.Start();

				while (TR.IsAlive)
					Application.DoEvents();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public void DtGridOneDay_load()
		{
			int number = 0;

			foreach (string item in countlistBox.Items)
			{
				int num;
				int indexOfchar = item.IndexOf('-');
				string text = item.Remove(0, indexOfchar + 1);
				bool result = Int32.TryParse(text, out num);
				if (result)
				{
					number = number + num;
				}
			}
			if (number != 0)
			{
				selectFilesTextBox.BeginInvoke(new InvokeDelegate(() => selectFilesTextBox.AppendText("Количество строк в файлах " + number.ToString() + Environment.NewLine)));
			}

			try
			{
				using (var db = new xlsx_baseEntities())
				{
					var cont = db.tempDbase
								.Select(c => new
								{
									TimeT = c.TimeT,
									DateT = c.DateT,
									Terminal = c.Terminal,
									Cardnum = c.Cardnum,
									AutCode = c.AutCode,
									Sum = c.Sum
								}).ToList();
					DtGridOneDay.BeginInvoke(new InvokeDelegate(() => DtGridOneDay.DataSource = cont));
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("" + e.Message.ToString());
			}
		}

		private void buttonClosed_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void oneDayFiles_Load(object sender, EventArgs e)
		{
			DtGridOneDay.AutoGenerateColumns = true;
			DtGridOneDay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
			DtGridOneDay.BorderStyle = BorderStyle.Fixed3D;
			DtGridOneDay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
			DtGridOneDay_load();
		}

		public void propertiesProgressbar()
		{
			timerOneDaysFiles.Interval = (1000);
			progressBarOneDaysFiles.Maximum = 600;
			progressBarOneDaysFiles.Value = 0;
			timerOneDaysFiles.Tick += new EventHandler(timerOneDaysFiles_Tick);
			timerOneDaysFiles.Start();
		}

		private async void buttonRunProces_Click(object sender, EventArgs e)
		{
			propertiesProgressbar();
			switch (MineGenegalForms.TypeFile_)
			{
				case 1:
				case 2:
				case 3:
					{
						rowCountDel = (await Task.Run(() => Load_Data_DataDev.Load_data_dev(1))).Item1;
						break;
					}

				case 4:
					{
						rowCountDel = (await Task.Run(() => Load_Data_DataDev.Load_data_dev(4))).Item1;
						break;
					}

				case 5:
					{
						rowCountDel = (await Task.Run(() => Load_Data_DataDev.Load_data_dev(5))).Item1;
						break;
					}
			}

			timerOneDaysFiles.Stop();
			progressBarOneDaysFiles.BeginInvoke(new threadCountDelegate(() => progressBarOneDaysFiles.Value = 600));
			selectFilesTextBox.BeginInvoke(new InvokeDelegate(() =>
								selectFilesTextBox.AppendText(
								"Количество импортированных строк "
								+ rowCountDel + Environment.NewLine)));
		}

		private async void uploadMineButton_Click(object sender, EventArgs e)
		{
			propertiesProgressbar();
			Tuple<string, string, string> uploadMine = null;

			switch (MineGenegalForms.TypeFile_)
			{
				case 1:
				case 2:
				case 3:
					{
						uploadMine = await Task.Run(() => AddToMineTable.UploadGPBmine(1));
						break;
					}
				case 4:
					{
						uploadMine = await Task.Run(() => AddToMineTable.UploadGPBmine(4));
						break;
					}
				case 5:
					{
						uploadMine = await Task.Run(() => AddToMineTable.UploadGPBmine(5));
						break;
					}
			}
			rowCountDel = uploadMine.Item1;
			rowCountAdd = uploadMine.Item2;
			rowCountDub = uploadMine.Item3;

			timerOneDaysFiles.Stop();
			progressBarOneDaysFiles.BeginInvoke(new threadCountDelegate(() => progressBarOneDaysFiles.Value = 600));

			selectFilesTextBox.BeginInvoke(new InvokeDelegate(() =>
						selectFilesTextBox.AppendText(
						"Удаленных строк " + rowCountDel
						+ Environment.NewLine + "Добавленных строк в таблицу " + rowCountAdd
						+ Environment.NewLine + "Дублей удалено " + rowCountDub)));
		}

		private void timerOneDaysFiles_Tick(object sender, EventArgs e)
		{
			if (progressBarOneDaysFiles.Value != 600)
			{
				progressBarOneDaysFiles.Value++;
			}
			else
			{
				timerOneDaysFiles.Stop();
			}
		}
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.countlistBox = new System.Windows.Forms.ListBox();
			this.selectFilesTextBox = new System.Windows.Forms.TextBox();
			this.buttonSelectFiles = new System.Windows.Forms.Button();
			this.oneDayFiles = new System.Windows.Forms.Button();
			this.buttonRunProces = new System.Windows.Forms.Button();
			this.DtGridOneDay = new System.Windows.Forms.DataGridView();
			this.timerOneDaysFiles = new System.Windows.Forms.Timer(this.components);
			this.progressBarOneDaysFiles = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.DtGridOneDay)).BeginInit();
			this.SuspendLayout();
			// 
			// countlistBox
			// 
			this.countlistBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.countlistBox.FormattingEnabled = true;
			this.countlistBox.Location = new System.Drawing.Point(506, 140);
			this.countlistBox.Name = "countlistBox";
			this.countlistBox.Size = new System.Drawing.Size(246, 290);
			this.countlistBox.TabIndex = 0;
			// 
			// selectFilesTextBox
			// 
			this.selectFilesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.selectFilesTextBox.Location = new System.Drawing.Point(506, 12);
			this.selectFilesTextBox.Multiline = true;
			this.selectFilesTextBox.Name = "selectFilesTextBox";
			this.selectFilesTextBox.Size = new System.Drawing.Size(246, 123);
			this.selectFilesTextBox.TabIndex = 1;
			// 
			// buttonSelectFiles
			// 
			this.buttonSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSelectFiles.Location = new System.Drawing.Point(13, 444);
			this.buttonSelectFiles.Name = "buttonSelectFiles";
			this.buttonSelectFiles.Size = new System.Drawing.Size(85, 23);
			this.buttonSelectFiles.TabIndex = 2;
			this.buttonSelectFiles.Text = "Загрузка";
			this.buttonSelectFiles.UseVisualStyleBackColor = true;
			this.buttonSelectFiles.Click += new System.EventHandler(this.buttonSelectFiles_ClickAsync);
			// 
			// oneDayFiles
			// 
			this.oneDayFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.oneDayFiles.Location = new System.Drawing.Point(104, 444);
			this.oneDayFiles.Name = "oneDayFiles";
			this.oneDayFiles.Size = new System.Drawing.Size(85, 23);
			this.oneDayFiles.TabIndex = 3;
			this.oneDayFiles.Text = "Обновление";
			this.oneDayFiles.UseVisualStyleBackColor = true;
			this.oneDayFiles.Click += new System.EventHandler(this.buttonRunProces_Click);
			// 
			// buttonRunProces
			// 
			this.buttonRunProces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRunProces.Location = new System.Drawing.Point(195, 444);
			this.buttonRunProces.Name = "buttonRunProces";
			this.buttonRunProces.Size = new System.Drawing.Size(82, 23);
			this.buttonRunProces.TabIndex = 4;
			this.buttonRunProces.Text = "Пополнение";
			this.buttonRunProces.UseVisualStyleBackColor = true;
			this.buttonRunProces.Click += new System.EventHandler(this.uploadMineButton_Click);
			// 
			// DtGridOneDay
			// 
			this.DtGridOneDay.AllowUserToAddRows = false;
			this.DtGridOneDay.AllowUserToDeleteRows = false;
			this.DtGridOneDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DtGridOneDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DtGridOneDay.Location = new System.Drawing.Point(13, 13);
			this.DtGridOneDay.Name = "DtGridOneDay";
			this.DtGridOneDay.ReadOnly = true;
			this.DtGridOneDay.Size = new System.Drawing.Size(487, 417);
			this.DtGridOneDay.TabIndex = 5;
			// 
			// timerOneDaysFiles
			// 
			this.timerOneDaysFiles.Tick += new System.EventHandler(this.timerOneDaysFiles_Tick);
			// 
			// progressBarOneDaysFiles
			// 
			this.progressBarOneDaysFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarOneDaysFiles.Location = new System.Drawing.Point(506, 444);
			this.progressBarOneDaysFiles.Name = "progressBarOneDaysFiles";
			this.progressBarOneDaysFiles.Size = new System.Drawing.Size(246, 23);
			this.progressBarOneDaysFiles.TabIndex = 6;
			// 
			// UploadDayFiles
			// 
			this.ClientSize = new System.Drawing.Size(764, 479);
			this.Controls.Add(this.progressBarOneDaysFiles);
			this.Controls.Add(this.DtGridOneDay);
			this.Controls.Add(this.buttonRunProces);
			this.Controls.Add(this.oneDayFiles);
			this.Controls.Add(this.buttonSelectFiles);
			this.Controls.Add(this.selectFilesTextBox);
			this.Controls.Add(this.countlistBox);
			this.Name = "UploadDayFiles";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.DtGridOneDay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

	}
}
