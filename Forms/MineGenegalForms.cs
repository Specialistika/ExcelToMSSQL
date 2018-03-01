using Load_bank_files.Class;
using Load_bank_files.Class.GUI;
using Load_bank_files.Data;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Load_bank_files.Class.deleteDBbase;

namespace Load_bank_files.Forms
{
	public partial class MineGenegalForms : Form
	{
		private WorksBankForm wbf = WorksBankForm.GetInstance();
		private UploadDayFiles odf = UploadDayFiles.GetInstance();
		private delegate void circularObject_();
		private static int TypeFile;
		//static CancellationTokenSource cts;
		public static int TypeFile_ => TypeFile;

		public MineGenegalForms()
		{
			InitializeComponent();
			GUI_circular();
		}

		public void GUI_circular()
		{
			circularProgressMain.BackgroundColor = System.Drawing.SystemColors.Control;
			circularProgressMain.ControlWidthHeight = 20;
			circularProgressMain.CirclesCount = 5;
			circularProgressMain.IndicatorDiameter = 5;
			circularProgressMain.IndicatorColor = System.Drawing.Color.BlueViolet;
			circularProgressMain.Animate = false;
			circularProgressMain.Visible = false;
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
                var odf = UploadDayFiles.GetInstance();

				if (SearchForm(odf) == false)
				{
					if (UploadDayFiles.GetInstance().IsDisposed)
					{
						new UploadDayFiles
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

        private void однодневкиСБToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
			try
			{
				Task<int> y = Task.Factory.StartNew(() => DeleteTempTable()).GetAwaiter().GetResult();

				MessageBox.Show("Удаление данных закончено");

				if (odf != null && !odf.IsDisposed && odf.Visible)
				{
					GUIController.countFilesTextBox("Clear");
					GUIController.countFileslistbox();
					odf.DtGridOneDay_load();
				}
			}
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
		private async static Task<int> DeleteTempTable()
		{
			int result = 0;

			using (var cleanDB = new xlsx_baseEntities())
			{
				return await Task.Run(() => { return result = cleanDB.Database.ExecuteSqlCommand("TRUNCATE TABLE [tempDbase]"); });
			}
		}

		private async void сбарбанкToolStripMenuItem_ClickAsync(object sender, EventArgs e)
		{
			await DeleteRow(1);
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

		private async void гПБКЛДToolStripMenuItem_ClickAsync(object sender, EventArgs e)
		{
			await DeleteRow(5);
		}

		private async Task<bool> DeleteRow(int bank)
		{
			circularProgressMain.Visible = true;
			circularProgressMain.Animate = true;
			try
			{
				await Task.Factory.StartNew(() => DeleteDBbase.DelBakns(bank)).GetAwaiter().GetResult();

				circularProgressMain.Visible = false;
				circularProgressMain.Animate = false;
				MessageBox.Show("Удаление данных закончено");
				return true;
			}
			catch (Exception x)
			{
				MessageBox.Show("Ошибка: ", x.Message);
				return false;
			}
		}

		private async void гПБМСКToolStripMenuItem_ClickAsync(object sender, EventArgs e)
		{
			await DeleteRow(4);
		}

		private async void загрузкаФайловSAPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await UploadSap.UploadSapAsync();
		}
	}
}
