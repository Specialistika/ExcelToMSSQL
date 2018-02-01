using System;
using System.Windows.Forms;
using Load_bank_files.Forms;
using Load_bank_files.Class.sb_load;
using Load_bank_files.Class.loadMineTable;
using Load_bank_files.Class.config;
using Load_bank_files.Class.ToDatabase;
using lcg = Load_bank_files.Class.GetData;
using Load_bank_files.Class.Load_Data;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace Load_bank_files.Forms
{
    public partial class WorksBankForm : Form
    {
        private static WorksBankForm oneDayFile = null;
        public delegate int threadCountDelegate();
        public delegate void threadTimeDelegate();
        static int n_count = 0;
        static string[] fl_names;
        static string rowCountDel;
        static string rowCountAdd;
        static string rowCountDub;
        public static WorksBankForm GetInstance()
        {
            if (oneDayFile == null)
                oneDayFile = new WorksBankForm();

            return oneDayFile;
        }
        public WorksBankForm()
        {
            InitializeComponent();
            BankTableDtGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            BankTableDtGrid.BorderStyle = BorderStyle.Fixed3D;
            BankTableDtGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }


        /* ----------Инициализация и свойства грида----------------------------*/
        private void dataGrid_reload(int bank_id)
        {
            string bank = "";
            bank = (bank_id == 3) ? "vtb_bank" : "gpb";
            string sqlcount = string.Format("select * from {0} order by five", bank);
            lcg.GetDataView gtv = new lcg.GetDataView();
            gtv.GetData(sqlcount);
            dataBinding.DataSource = lcg.GetDataView.table_bank;
            BankTableDtGrid.DataSource = dataBinding;

        }

        /* Загрузка из таблиц Excel их очистка и отправка данных во временную таблицу ГПБ банка*/
        public void excelLoadTempGpbKld()
        {
            sb_load_files slf = new sb_load_files();
            slf.sb_load_form(out fl_names, out n_count, 5, variable_config.vtb_kld_file_dir);
            try
            {
                if (fl_names != null && n_count != 0)
                {
                    FileLoad.Items.AddRange(fl_names);
                    Text_vtb.AppendText("Количество файлов" + n_count + Environment.NewLine);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
            SaveFileToDatabase sfd = new SaveFileToDatabase();
            sfd.DeleteBadRow(5);
            Text_vtb.AppendText("Количество переданных строк: " + sfd.DeleteBadRow(4) + Environment.NewLine);
            dataGrid_reload(5);
        }

        public void excelLoadTempGpbMsk()
        {
            sb_load_files slf = new sb_load_files();
            slf.sb_load_form(out fl_names, out n_count, 4, variable_config.vtb_kld_file_dir);
            try
            {
                if (fl_names != null && n_count != 0)
                {
                    FileLoad.Items.AddRange(fl_names);
                    Text_vtb.AppendText("Количество файлов" + n_count + Environment.NewLine);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
            SaveFileToDatabase sfd = new SaveFileToDatabase();
            sfd.DeleteBadRow(4);
            Text_vtb.AppendText("Количество переданных строк: " + sfd.DeleteBadRow(4) + Environment.NewLine);
            dataGrid_reload(4);
        }

        /* Загрузка таблиц Excel их отправка на сервер*/
        public void excelLoadTempSb()
        {
            sb_load_files sb_files = new sb_load_files();
            sb_files.sb_load_form(out fl_names, out n_count, 1, variable_config.sb_file_dir);
            try
            {
                if (fl_names != null && n_count != 0)
                {
                    FileLoad.Items.AddRange(fl_names);
                    sb_txt.AppendText("Количество файлов: " + n_count);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }


        /*-----------------------Свойства грида------------------------*/

        public class RowComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;

            public RowComparer(System.Windows.Forms.SortOrder sortOrder)
            {
                if (sortOrder == System.Windows.Forms.SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;


                int CompareResult = System.String.Compare(
                    DataGridViewRow1.Cells[1].Value.ToString(),
                    DataGridViewRow2.Cells[1].Value.ToString());


                if (CompareResult == 0)
                {
                    CompareResult = System.String.Compare(
                        DataGridViewRow1.Cells[0].Value.ToString(),
                        DataGridViewRow2.Cells[0].Value.ToString());
                }
                return CompareResult * sortOrderModifier;
            }
        }
        /*-----------------------Сохранение Сб банка в промежуточную таблицу------------------------*/
        private async void SaveTable_Click(object sender, EventArgs e)
        {
            var progress = new Progress<string>(s => sb_txt.AppendText(s));
            this.procesTimer.Interval = (variable_config.timerProgressbar*1000)/10;
            threadProgressBar.Maximum = 10;
            threadProgressBar.Value = 0;
            procesTimer.Tick += new EventHandler(this.processTimer_Tick);
            procesTimer.Start();

            string uploadTemp = await Task.Factory.StartNew<string>(() =>
                loadMineTable.sb_load_temp_table(progress), TaskCreationOptions.LongRunning);

            procesTimer.Stop();
            threadProgressBar.BeginInvoke(new threadCountDelegate(() => threadProgressBar.Value = 10));
            sb_txt.AppendText("Добавлено во временную таблицу строк " + uploadTemp + Environment.NewLine);
            //label1.Text = uploadTemp;
            
            //threadProgressBar.BeginInvoke(new threadCountDelegate(() => threadProgressBar.Maximum = 10));
            //var sw = Stopwatch.StartNew();
            //loadMineTable slt = new loadMineTable();
            ////DateTime startTime = DateTime.Now;
            ////DateTime startTime2 = startTime.AddMilliseconds(20000);
            ////int endTime = (startTime2 - startTime).Minutes;
            //var delay = Task.Run(() =>
            //{
            //    for (int i = 1; i < 10; i++)
            //    {
            //        Task.Delay(6000).Wait();
            //        threadProgressBar.BeginInvoke(new threadCountDelegate(() => threadProgressBar.Value = i));
            //    }
            //    sw.Stop();
            //    return sw.ElapsedMilliseconds;
            //});
            ////var uploadTemp = Task.Delay(60000).ContinueWith(_ =>
            ////{
            ////    //ask.Delay(6000).Wait();
            ////    loadMineTable.sb_load_temp_table();
            ////    sw.Stop();
            ////    return sw.ElapsedMilliseconds;

            ////});
            ////var tasks = new Task[] { delay, uploadTemp };
            ////Task.WaitAll(tasks.);


            //await Task.WhenAll(delay, uploadTemp);
            ////var progress = new Progress<int>(s => threadProgressBar.Value = s);
            ////threadProgressBar.Value = Convert.ToInt32(progress)
            ////string rowCountemp;
            ////string rowCounterr;
            ////loadMineTable slt = new loadMineTable();
            ////slt.sb_load_temp_table();
            //string rowCounterr = await Task.Factory.StartNew(() => progressbarProcess(), TaskCreationOptions.LongRunning);
            //sb_txt.AppendText("Добавлено во временную таблицу строк " + rowCounterr + Environment.NewLine);
            //if (rowCounterr != null)
            //sb_txt.AppendText(rowCounterr + Environment.NewLine);
            //this.label1.Text = rowCounterr;
        }

        private async void loadMineTablebutton_Click(object sender, EventArgs e)
        {
            var progress = new Progress<string>(s => sb_txt.AppendText(s));
            this.procesTimer.Interval = (variable_config.timerProgressbar * 1000) / 10;
            threadProgressBar.Maximum = 10;
            threadProgressBar.Value = 0;
            procesTimer.Tick += new EventHandler(this.processTimer_Tick);
            procesTimer.Start();

            string uploadMine = await Task.Factory.StartNew<string>(() =>
                                    loadMineTable.sb_load_mine_table(progress), TaskCreationOptions.LongRunning);

            procesTimer.Stop();
            threadProgressBar.BeginInvoke(new threadCountDelegate(() => threadProgressBar.Value = 10));
            sb_txt.AppendText("Добавлено во временную таблицу строк " + uploadMine + Environment.NewLine);
        }
        /* -------------------Загрузка данных ВТБ и ГПБ банков в основную таблицу------------*/
        private void btn_vtb_kld_Click(object sender, EventArgs e)
        {
            loadBlock_bank(3);
        }

        private void btn_gpb_msk_Click_1(object sender, EventArgs e)
        {
            loadBlock_bank(4);
        }

        private void btn_gpb_kld_Click_1(object sender, EventArgs e)
        {
            loadBlock_bank(5);
        }
        private async void loadBlock_bank(int bank)
        {
            Load_Data_DataDev.delBaks(bank);
            Text_vtb.AppendText("Количество переданных строк: " + Load_Data_DataDev.Load_data_dev(bank) + Environment.NewLine);
            Load_Data_DataDev.delTemp(bank);
            var result = await loadMineTable.proc_import_vtb_gpb(bank);
            rowCountDel = result.Item1;
            rowCountAdd = result.Item2;
            rowCountDub = result.Item3; 
            Text_vtb.AppendText("Удаленных строк в основной базе" + rowCountDel + Environment.NewLine);
            Text_vtb.AppendText("Добавленых в базу" + rowCountAdd + Environment.NewLine);
            Text_vtb.AppendText("Удалено дублей" + rowCountDub + Environment.NewLine);
            dataGrid_reload(bank);
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {
            if (threadProgressBar.Value != 10)
            {
                threadProgressBar.Value++;
            }
            else
            {
                procesTimer.Stop();
            }
        }

    }
}
