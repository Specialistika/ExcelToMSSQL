using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Load_bank_files.Data;
using Load_bank_files.Class.GUI;
using Load_bank_files.Class.config;
using Load_bank_files.Class.DayDoc;
using Load_bank_files.Class.Load_Data;
using Load_bank_files.Class.loadMineTable;


namespace Load_bank_files.Forms
{
	public partial class oneDayFiles : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private delegate int threadCountDelegate();
		private delegate void InvokeDelegate();
        private BindingSource Bind = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private static oneDayFiles oneDayFile = null;
		private static string rowCountDel;
		private static string rowCountAdd;
		private static string rowCountDub;

		public static oneDayFiles GetInstance()
        {
            if (oneDayFile == null)
                oneDayFile = new oneDayFiles();

            return oneDayFile;
        }

        public oneDayFiles()
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
        }
		private async void buttonSelectFiles_ClickAsync(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				int selectCount = openFileDialog.FileNames.Length;
				selectFilesTextBox.BeginInvoke(new InvokeDelegate(() =>
				selectFilesTextBox.AppendText("Количество выбранных файлов: " + selectCount + Environment.NewLine)));
				foreach (var file in openFileDialog.FileNames)
				{
					try
					{
						await Task.Factory.StartNew(() => oneDaydoc.OneDayfiles(file), TaskCreationOptions.LongRunning);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: Could not read file from disk. Original error or dont't read row: " + ex.Message);
					}
				}
			}
			await Task.Factory.StartNew(() => DtGridOneDay_load());
		}
		private void countFileStatistic(string countRaw, string nameFiles)
        {
            object[] DataSetListbox =  { nameFiles+" - "+countRaw }; 
            try
            {
                if (countRaw != null)
                {
                    if(InvokeRequired)
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
                Thread TR =  new Thread(delegate()
                {
                    countFileStatistic(countRaw, nameFiles);
                });
                TR.Start();

                while (TR.IsAlive)
                    Application.DoEvents();
            }
            catch(Exception e)
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
                string text = item.Remove(0, indexOfchar+1);
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
						 uploadMine = await Task.Run(() => loadMineTable.UploadGPBmine(1));
						break;
					}
				case 4:
					{
						 uploadMine = await Task.Run(() => loadMineTable.UploadGPBmine(4));
						break;
					}
				case 5:
					{
						 uploadMine = await Task.Run(() => loadMineTable.UploadGPBmine(5));
						break;
					}
			}
			rowCountDel = uploadMine.Item1;
			rowCountAdd = uploadMine.Item2;
			rowCountDub = uploadMine.Item3;

			//, TaskCreationOptions.LongRunning);

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
    }
}
