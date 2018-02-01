using Load_bank_files.Class.GUI;
using Load_bank_files.Class.Load_Data;
using Load_bank_files.Class.sb_load;
using Load_bank_files.Data;
using System;
using System.Threading;
using System.Windows.Forms;
using static Load_bank_files.Forms.oneDayFiles;

namespace Load_bank_files.Forms
{
    public partial class MineGenegalForms : Form
    {
        WorksBankForm wbf = WorksBankForm.GetInstance();
        public MineGenegalForms()
        {
            InitializeComponent();
        }

        private void slectedUploadBanksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uploadBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbf.MdiParent = this;
            wbf.Show();
        }

        private void oneDayFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oneDayFiles odf = oneDayFiles.GetInstance();
            odf.MdiParent = this;
            odf.Show();
        }

        private void однодневкиСБToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread TRtempSB = new Thread(delegate ()
                {
                    using (var cleanDB = new xlsx_baseEntities())
                    {
                        try
                        {
                            cleanDB.Database.ExecuteSqlCommand("TRUNCATE TABLE [newSb]");
                            //var itemsToDelete = cleanDB.Set<newSb>();
                            //cleanDB.newSb.RemoveRange(itemsToDelete);
                            //cleanDB.SaveChanges();
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                });
                TRtempSB.Start();

                while (TRtempSB.IsAlive)
                    Application.DoEvents();
                string confirmTRbase = TRtempSB.ThreadState.ToString();

                if (confirmTRbase == "Stopped")
                {
                    MessageBox.Show("Удаление данных закончено");
                }
                TRtempSB.Join();
                oneDayFiles odf = oneDayFiles.GetInstance();
                GUIController.countFilesTextBox("");
                GUIController.countFileslistbox();
                odf.DtGridOneDay_load();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void сбарбанкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bank = 1;
            try
            {
                Thread TRbase = new Thread(delegate ()
                {
                    using (var cleanDB = new xlsx_baseEntities())
                    {
                        try
                        {
                            Load_Data_DataDev.delBaks(bank);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                });
                TRbase.Start();

                while (TRbase.IsAlive)
                    Application.DoEvents();
                string confirmTRbase = TRbase.ThreadState.ToString();

                if (confirmTRbase == "Stopped")
                {
                    MessageBox.Show("Удаление данных закончено");
                }
                TRbase.Join();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        private void loadGPBBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbf.excelLoadTempGpbKld();
        }

        private void loadGPBMSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbf.excelLoadTempGpbMsk();
        }

        private void loadSberbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wbf.excelLoadTempSb();
        }

        private void конфигурацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sf = Service_Form.GetInstance();
            sf.MdiParent = this;
            sf.Show();
        }
    }
}
