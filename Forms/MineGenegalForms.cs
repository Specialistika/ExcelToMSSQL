using Load_bank_files.Class;
using Load_bank_files.Class.GUI;
using Load_bank_files.Data;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Load_bank_files.Forms
{
	public partial class MineGenegalForms : Form
    {
		private WorksBankForm wbf = WorksBankForm.GetInstance();

		private oneDayFiles odf = oneDayFiles.GetInstance();

		private static int TypeFile;

		public static int TypeFile_ => TypeFile;

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
            if (TypeFile_ != 0)
            {
                var odf = oneDayFiles.GetInstance();

				if (SearchForm(odf) == false)
				{
					if (oneDayFiles.GetInstance().IsDisposed)
					{
						new oneDayFiles
						{
							MdiParent = this
						}.Show();
						return;
					}
					else
					{
						odf.MdiParent = this;
						odf.Show();
					}
				}
			}
            else
            {
                MessageBox.Show("Не выбран формат фалов");
            }
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
                            cleanDB.Database.ExecuteSqlCommand("TRUNCATE TABLE [tempDbase]");
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
				if (odf != null && !odf.IsDisposed && odf.Visible)
				{
					GUIController.countFilesTextBox("");
					GUIController.countFileslistbox();
					odf.DtGridOneDay_load();
				}
			}
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void сбарбанкToolStripMenuItem_Click(object sender, EventArgs e)
        {
			deleteRow(1);
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
            
        }

		public bool SearchForm(Form form)
		{
			foreach (Form frm in Application.OpenForms)
			{
				if (frm.Name == form.Name)
				{
					frm.Activate();
					return true;
				}
			}
			return false;
		}


		private void конфигурацияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Service_Form.GetInstance();
			if (SearchForm(form) == false)
			{
				if (Service_Form.GetInstance().IsDisposed)
				{
					new Service_Form
					{
						MdiParent = this
					}.Show();
					return;
				}
				else
				{
					form.MdiParent = this;
					form.Show();
				}
			}
		}

		private void внутреннийФорматБанкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFile = 2;
            this.Text = "Внутренний формат Сбербанка"; 
        }

        private void MineGenegalForms_Load(object sender, EventArgs e)
        {
            switch (TypeFile_)
            {
                default:
                    this.Text = "Выберете формат файла";
                    break;
            }
        }

        private void форматОднодневокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFile = 1;
            this.Text = "Формат однодневок Сбербанка";
        }

        private void обычныйФорматФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeFile = 3;
            this.Text = "Стандартный формат Сбербанка";
        }

        private void работаСФайламиБанковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tEx = TrimExcelForm.GetInstance();

			if (SearchForm(tEx) == false)
			{
				if (TrimExcelForm.GetInstance().IsDisposed)
				{
					new TrimExcelForm
					{
						MdiParent = this
					}.Show();
					return;
				}
				else
				{
					tEx.MdiParent = this;
					tEx.Show();
				}
			}
		}

		private void основнойФорматToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TypeFile = 4;
			this.Text = "Стандартный формат ГПБ банка МСК";
		}

		private void основнойФорматФайлаКЛДToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TypeFile = 5;
			this.Text = "Стандартный формат ГПБ банка КЛД";
		}

		private void гПБКЛДToolStripMenuItem_Click(object sender, EventArgs e)
		{
			deleteRow(5);
		}
		private void deleteRow(int bank)
		{
			try
			{
				Thread TRbase = new Thread(delegate ()
				{
					using (var cleanDB = new xlsx_baseEntities())
					{
						try
						{
							deleteDBbase.delBakns(bank);
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

		private void гПБМСКToolStripMenuItem_Click(object sender, EventArgs e)
		{
			deleteRow(4);
		}
	}
}
