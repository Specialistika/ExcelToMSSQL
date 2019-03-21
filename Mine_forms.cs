using System;
using System.Windows.Forms;
using Load_bank_files.Forms;
using Load_bank_files.Class.sb_load;
using Load_bank_files.Class.loadMineTable;
using Load_bank_files.Class.config;
using Load_bank_files.Class.ToDatabase;
using lcg = Load_bank_files.Class.GetData;
using Load_bank_files.Class.Load_Data;
using Load_bank_files.Class.deleteDBbase;

namespace Load_bank_files
{
	public partial class UploadBanksFiles : Form 
    {
        private static UploadBanksFiles oneDayFile = null;

        public static UploadBanksFiles GetInstance()
        {
            if (oneDayFile == null)
                oneDayFile = new UploadBanksFiles();

            return oneDayFile;
        }

        static int n_count = 0;
        static string[] fl_names;
        static string rowCountDel;
        static string rowCountAdd;
        static string rowCountDub;        
        public  UploadBanksFiles()
        {
            InitializeComponent();
            threadProgressBar.Maximum = 850;
            threadProgressBar.Step = 1;
            threadProgressBar.Value = 0;

        }

        #region dontwork

        public void loadSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sb_load_files sb_files = new sb_load_files();
            sb_files.sb_load_form(out fl_names, out n_count, 1, variable_config.sb_file_dir);
            try
            {
                if (fl_names != null && n_count != 0)
                {
                    FileLoad.Items.AddRange(fl_names);
                    label1.Text = "Количество файлов: " + n_count;
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }


        #region block



        private void button2_Click(object sender, EventArgs e)
        {
            //string rowCountdel;
            //string rowCountAdd;   
            //            loadMineTable slt = new loadMineTable();
            //            //slt.sb_load_mine_table(out  rowCountdel, out rowCountAdd);
            //            sb_txt.AppendText("Удалено из сводной таблицы строк " + rowCountAdd + Environment.NewLine);
            //            sb_txt.AppendText("Добавлено в сводную таблицу строк " + rowCountAdd + Environment.NewLine);
        }

        private void setviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #endregion
        private void loadGPBKLDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sb_load_files slf = new sb_load_files();
            slf.sb_load_form(out fl_names, out n_count, 5, variable_config.gpb_kld_file_dir);
        }

        private void loadGPBMSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sb_load_files slf = new sb_load_files();
            slf.sb_load_form(out fl_names, out n_count, 4, variable_config.gpb_msk_file_dir);
        }

        private void loadVTBKLDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            sb_load_files slf = new sb_load_files();
            slf.sb_load_form(out fl_names, out n_count, 3, variable_config.vtb_kld_file_dir);
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
            sfd.DeleteBadRow(3);
            Text_vtb.AppendText("Количество переданных строк: " + sfd.DeleteBadRow(3) + Environment.NewLine);
            dataGrid_reload(3);
        }

        private void Mine_forms_Load(object sender, EventArgs e)
        {
            dataGrid_reload(4);
            //progressTimer.Enabled = true;
            //progressTimer.Start();
            progressTimer.Interval = 1000;
            threadProgressBar.Maximum = 10;
            progressTimer.Tick += new EventHandler(progressTimer_Tick);
        }

        #endregion block

        private void button3_Click(object sender, EventArgs e)
        {
            LoadBlock_bankAsync(3);
        }
        private void dataGrid_reload(int bank_id)
        {
            string bank = "";
            bank = (bank_id == 3) ? "vtb_bank" : "gpb";
            string sqlcount = string.Format("select * from {0} order by five", bank);
            lcg.GetDataView gtv = new lcg.GetDataView();
            gtv.GetData(sqlcount);
            BindingLocal.DataSource = lcg.GetDataView.table_bank;
            DtGrid.DataSource = BindingLocal;
            DtGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            DtGrid.BorderStyle = BorderStyle.Fixed3D;
            DtGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void CountDataGridText(int countRow)
        {
            int i;
            i = (DtGrid.Rows.Count);
            
            //foreach (DataGridViewRow row in DtGrid.Rows)
            //{
            //    DtGrid.Rows[row.Index].Visible = !(row.Index > countRow);
            //}
            for (int s=0; s < DtGrid.Rows.Count - 1; s++)
            {
                DtGrid.Rows[s].Visible = !(DtGrid.Rows[s].Index > countRow);
            }

        }

        private void DtGrid_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void TxtCountRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int countRow = int.Parse(TxtCountRow.Text.ToString());
                CountDataGridText(countRow);
            }
        }

        private void loadGPBMSKToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void btn_gpb_msk_Click(object sender, EventArgs e)
        {
            LoadBlock_bankAsync(4);
        }

        private void btn_gpb_kld_Click(object sender, EventArgs e)
        {
            LoadBlock_bankAsync(5);
        }

        private void loadGPBKLDToolStripMenuItem_Click_1(object sender, EventArgs e)
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

		private async void LoadBlock_bankAsync(int bank)
		{
			await DeleteDBbase.DelBakns(bank);
			Text_vtb.AppendText("Количество переданных строк: " + Load_Data_DataDev.Load_data_dev(bank) + Environment.NewLine);
			Load_Data_DataDev.delTemp(bank);
			var result = AddToMineTable.UploadGPBmine(bank);
			rowCountDel = result.Item1;
			rowCountAdd = result.Item2;
			rowCountDub = result.Item3;
			Text_vtb.AppendText("Удаленных строк в основной базе" + rowCountDel + Environment.NewLine);
			Text_vtb.AppendText("Добавленых в базу" + rowCountAdd + Environment.NewLine);
			Text_vtb.AppendText("Удалено дублей" + rowCountDub + Environment.NewLine);
			dataGrid_reload(bank);
		}

		private void конфигурацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Service_Form frm = new Service_Form();
            frm.Show();
        }

        private void формированиеОднодневокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadDayFiles odf = new UploadDayFiles();
            odf.Show();
        }

        public void progressbarProcess(int timeCount)
        {
            UploadBanksFiles ubf = UploadBanksFiles.GetInstance();
            //threadProgressBar.Value = 0;
            ubf.threadProgressBar.Maximum = 10;

            try
            {
                if (ubf.threadProgressBar.Value != 10)
                {
                    ubf.threadProgressBar.Value++;
                }
                else
                {
                    progressTimer.Stop();
                }

                //UploadBanksFiles ubf = UploadBanksFiles.GetInstance();
                //this.progressTimer.Enabled = true;
                //this.progressTimer.Interval = 1000;
                //this.progressTimer.Start();
                //this.threadProgressBar.Maximum = 10;
                //this.progressTimer.Tick += new EventHandler(this.progressTimer_Tick);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void UploadtempDevButton_Click(object sender, EventArgs e)
        {
            //string rowCountemp;
            //string rowCounterr;
            //loadMineTable slt = new loadMineTable();
            //slt.sb_load_temp_table();
            //rowCounterr = slt.SomeLongOperation();
            //sb_txt.AppendText("Добавлено во временную таблицу строк " + rowCounterr + Environment.NewLine);
            //if (rowCounterr != null)
            //sb_txt.AppendText(rowCounterr + Environment.NewLine);
        }

        public void progressTimer_Tick(object sender, EventArgs e)
        {
            if (threadProgressBar.Value != 10)
            {
                threadProgressBar.Value++;
            }
            else
            {
                progressTimer.Stop();
            }
        }
    }
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

}
