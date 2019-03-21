using Load_bank_files.Class.config;
using Ex = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System;
using System.Windows.Forms;
using Spire.Xls.Collections;
using Spire.Xls;
using System.Threading.Tasks;

namespace Load_bank_files.Forms
{
	public partial class TrimExcelForm : Form
	{
		OpenFileDialog openDialog = new OpenFileDialog();
		private static TrimExcelForm trimExcel = null;

		public delegate void countDelegate();
		public TrimExcelForm()
		{
			InitializeComponent();
			openDialog.InitialDirectory = variable_config.dirUploadFiles;
			openDialog.Filter = "xls files (*.xls)|*.xls|(*.xlsx)|*.xlsx";
			openDialog.FilterIndex = 1;
			openDialog.Multiselect = true;
			openDialog.RestoreDirectory = true;
		}

		public static TrimExcelForm GetInstance()
		{
			if (trimExcel == null)
				trimExcel = new TrimExcelForm();
			return trimExcel;
		}

		private async void TrimListButton_ClickAsync(object sender, EventArgs e)
		{
			int countFiles = 0;
			if (openDialog.ShowDialog() == DialogResult.OK)
			{
				int selectCount = openDialog.FileNames.Length;
									countFilesTextBox.AppendText(
										"Количество выбранных файлов: " + selectCount + Environment.NewLine);
				foreach (var file in openDialog.FileNames)
				{
					try
					{
						countFiles = await Task.Run(() => NameSheets(file));
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: Could not read file from disk. Original error or dont't read row: " + ex.Message);
					}
				}
					countFilesTextBox.AppendText(
						"Количество новых файлов: " + countFiles + Environment.NewLine);
			}
		}
		#region удаление шального листа 
		public static void DeleteSheet(string file)
		{
			Ex.Application excel = new Ex.Application();
			Ex.Workbook wb = excel.Workbooks.Open(file);

			Ex.Sheets worksheets = wb.Worksheets;
			foreach(Ex.Worksheet wh in worksheets)
			{
				if(wh.Name.Contains("Evaluation Warning"))
				{
					wh.Delete();
					break;
				}
			}
			wb.Save();
			wb.Close();
			excel.Quit();
		}
		#endregion

		#region деление листов книги на файлы

		public static int NameSheets(string file)
		{

			var results = GetAllWorksheets(file);
			int countResult = results.Count;

			foreach (Worksheet item in results)
			{
				Workbook newWorkbook = new Workbook();

				newWorkbook.Worksheets.AddCopy(item);

				WorksheetsCollection NewCollection = newWorkbook.Worksheets;
				for (int i = 0; i < 3; i++)
				{
					Worksheet itemNew = newWorkbook.Worksheets[0];
					if (itemNew.Name.Contains("Sheet"))
					{
						itemNew.Remove();

					}
					else
					{
						break;
					}
				}
				newWorkbook.Worksheets[0].Name = "List1";
				newWorkbook.SaveToFile(variable_config.dirUploadFiles + item.Name + "_" + ".xlsx", ExcelVersion.Version2013);
			}
			return countResult;
		}
		public static WorksheetsCollection GetAllWorksheets(string fileName)
		{
			Workbook workbook = new Workbook();
			workbook.LoadFromFile(fileName);
			WorksheetsCollection worksheets = workbook.Worksheets;
			return worksheets;
		}
		#endregion
	}
}
