using System;
using System.Windows.Forms;
using Load_bank_files.Class.config;
using System.Data;
using Load_bank_files.Class.DayDoc;
using Load_bank_files.Class.GUI;
using System.Threading;
using System.Linq;
using Load_bank_files.Data;
using System.Data.SqlClient;
using Load_bank_files.Class.Load_Data;
using Load_bank_files.Class.loadMineTable;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Load_bank_files.Forms
{
    public partial class oneDayFiles : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private delegate int threadCountDelegate();
        public delegate void InvokeDelegate();
        private BindingSource Bind = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private static oneDayFiles oneDayFile = null;
        static string rowCountDel;
        static string rowCountAdd;
        static string rowCountDub;

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

            openFileDialog.InitialDirectory = variable_config.dir_initialisation;
            openFileDialog.Filter = "xls files (*.xls)|*.xls|(*.xlsx)|*.xlsx";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;
            countlistBox.HorizontalScrollbar = true;
            countlistBox.FormattingEnabled = true;
            countlistBox.ScrollAlwaysVisible = true;
        }
        private void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            int selectCount = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectCount = openFileDialog.FileNames.Length;
                //GUIController.countFilesTextBox("Количество выбранных файлов: " + selectCount);
                selectFilesTextBox.BeginInvoke(new InvokeDelegate(() => selectFilesTextBox.AppendText("Количество выбранных файлов: " + selectCount + Environment.NewLine)));
                foreach (var file in openFileDialog.FileNames)
                {
                    try
                    {
                        oneDaydoc.oneDayfiles(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }

                }
                DtGridOneDay_load();
            }
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
                    var cont = db.newSb
                                .Select(c => new
                                {
                                    TimeT = c.TimeT,
                                    DateT = c.DateT,
                                    Terminal = c.Terminal,
                                    Cardnum = c.Cardnum,
                                    AutCode = c.AutCode,
                                    Sum = c.Sum,
                                    Comis = c.Comis,
                                    RRN = c.RRN
                                }).ToList();
                    DtGridOneDay.DataSource = cont;
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

        private void buttonRunProces_Click(object sender, EventArgs e)
        {
           string countRow = Load_Data_DataDev.Load_data_dev(1);
            selectFilesTextBox.BeginInvoke(new InvokeDelegate(() => selectFilesTextBox.AppendText("Количество импортированных строк " + countRow + Environment.NewLine)));
        }

        private async void uploadMineButton_Click(object sender, EventArgs e)
        {
            int bank = 1;
            this.timerOneDaysFiles.Interval = (1000);
            progressBarOneDaysFiles.Maximum = 600;
            progressBarOneDaysFiles.Value = 0;
            timerOneDaysFiles.Tick += new EventHandler(this.timerOneDaysFiles_Tick);
            timerOneDaysFiles.Start();
            var uploadMine = await Task.Run(() => loadMineTable.proc_import_vtb_gpb(bank));

            rowCountDel = uploadMine.Item1;
            rowCountAdd = uploadMine.Item2;
            rowCountDub = uploadMine.Item3;
                        //, TaskCreationOptions.LongRunning);

            timerOneDaysFiles.Stop();
            progressBarOneDaysFiles.BeginInvoke(new threadCountDelegate(() => progressBarOneDaysFiles.Value = 600));
            
            selectFilesTextBox.BeginInvoke(new InvokeDelegate(() 
                    => selectFilesTextBox.AppendText(
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
