using Spire.Xls;
using Spire.Xls.Collections;
using System;
using System.IO;
using Load_bank_files.Class.config;
using System.Collections.Generic;
using Load_bank_files.Forms;
using Load_bank_files.Class.DataOneDoc;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Load_bank_files.Class.DayDoc
{
	public partial class oneDaydoc
    {
		private static oneDayFiles dayFiles = oneDayFiles.GetInstance();

		public static void OneDayfiles(string filesnames)
		{
			String pageCount = null;
			string loadFiles = null;
			Workbook workbook = new Spire.Xls.Workbook();
			string fileName = variable_config.sbNewFormat + "tempSBfile.xlsx";
			string files = Convert.ToString(Path.GetFullPath(filesnames));
			string PathDir = Convert.ToString(Path.GetDirectoryName(filesnames));
			string nameFiles = Convert.ToString(Path.GetFileName(filesnames));
			string nameFilesOnly = Convert.ToString(Path.GetFileNameWithoutExtension(filesnames));
			if (nameFiles.EndsWith(".xls"))
			{
				Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
				excelApp.Visible = false;
				Microsoft.Office.Interop.Excel.Workbook eWorkbook = excelApp.Workbooks.Open(files, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
				eWorkbook.SaveAs(PathDir + "\\" + nameFilesOnly + ".xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
				eWorkbook.Close(false, Type.Missing, Type.Missing);
				loadFiles = PathDir + "\\" + nameFilesOnly + ".xlsx";
			}
			else
			{
				loadFiles = files;
			}
			try
			{
				workbook.LoadFromFile(loadFiles);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
			Worksheet sheet = workbook.Worksheets[0];

			#region формат однодневок сб
			if (MineGenegalForms.TypeFile_ == 1)
			{
				for (int i = 1; i < 9; i++)
				{
					sheet.DeleteRow(i);
				}
				for (int i = 1; i < 3; i++)
				{
					sheet.DeleteRow(i);
				}

				CellRange[] rangesHole = sheet.FindAllString("О", false, false);

				foreach (CellRange range in rangesHole)
				{
					sheet.DeleteRow(range.Row);
				}

				CellRange[] rangesString = sheet.FindAllString("----------------", false, false);

				foreach (CellRange range in rangesString)
				{
					sheet.DeleteRow(range.Row);
				}

				CellRange[] rangesSymbol = sheet.FindAllString("Итог", false, false);

				foreach (CellRange range in rangesSymbol)
				{
					sheet.DeleteRow(range.Row);
				}

				sheet.DeleteRow(1);


				sheet.InsertRow(1);
				sheet.Range["A1"].Value = "TimeT";
				sheet.Range["B1"].Value = "DateT";
				sheet.Range["C1"].Value = "Terminal";
				sheet.Range["D1"].Value = "Cardnum";
				sheet.Range["E1"].Value = "AutCode";
				sheet.Range["F1"].Value = "Sum";
				sheet.Range["G1"].Value = "Comis";
				sheet.Range["H1"].Value = "RRN";
			}
			#endregion
			#region формат банка сб
			if (MineGenegalForms.TypeFile_ == 2)
			{
				CellRange[] finalSymbol = sheet.FindAllString("Итог", false, false);

				foreach (CellRange range in finalSymbol)
				{
					sheet.DeleteRow(range.Row);
				}
				#region удаление группировки (кушает только несколько строк)
				/*
				CellRange[] groupSymbol = sheet.FindAllString("Группировка", false, false);
				int i = 0;
				int lenght = groupSymbol.Length;

				do
				{
					groupSymbol = sheet.FindAllString("Группировка", false, false);
					//lenght = groupSymbol.Length;
					i = --lenght;


					CellRange range = groupSymbol[i];
					sheet.DeleteRow(range.Row);
				} while (i > 1);
				*/
				#endregion
				sheet.InsertRow(1);
				sheet.Range["I1"].Value = "TimeT";
				sheet.Range["J1"].Value = "DateT";
				sheet.Range["H1"].Value = "Terminal";
				sheet.Range["U1"].Value = "Cardnum";
				sheet.Range["V1"].Value = "AutCode";
				sheet.Range["K1"].Value = "Sum";
				sheet.Range["L1"].Value = "Comis";
				sheet.Range["M1"].Value = "RRN";
			}
			#endregion
			#region формат стандартных файлов сб
			if (MineGenegalForms.TypeFile_ == 3)
			{
				sheet.DeleteRow(1);
				sheet.InsertRow(1);
				sheet.Range["G1"].Value = "TimeT";
				sheet.Range["N1"].Value = "DateT";
				sheet.Range["F1"].Value = "Terminal";
				sheet.Range["K1"].Value = "Cardnum";
				sheet.Range["L1"].Value = "AutCode";
				sheet.Range["I1"].Value = "Sum";
				sheet.Range["J1"].Value = "Comis";
				sheet.Range["D1"].Value = "RRN";
			}
			#endregion
			#region формат стандартных файлов ГПБ
			if (MineGenegalForms.TypeFile_ == 4 || MineGenegalForms.TypeFile_ == 5)
			{
				sheet.InsertRow(1);
				sheet.Range["A1"].Value = "Terminal";
				sheet.Range["B1"].Value = "Cardnum";
				sheet.Range["C1"].Value = "Sum";
				sheet.Range["D1"].Value = "Comis";
				sheet.Range["E1"].Value = "TimeT";
				sheet.Range["F1"].Value = "Status";
				sheet.Range["G1"].Value = "Typ";
				sheet.Range["H1"].Value = "PS";
				sheet.Range["I1"].Value = "AutCode";
				sheet.Range["J1"].Value = "Emitent";
			}
			#endregion

			sheet.Name = "List1";

			workbook.SaveToFile(fileName, ExcelVersion.Version2010);

			deleteEmpty(fileName);

			pageCount = countSheet(sheet);

			dayFiles.SampleFunction(pageCount, nameFiles);

			dateOneDocSB.SaveToTempbase(fileName);
		}
		/* удаление пустых строк */
		private static void deleteEmpty(string fileName) 
		{
			Workbook workbook = new Workbook();

			workbook.LoadFromFile(fileName);
			List<string> Worksheetname = new List<string>();

			var results = GetAllWorksheets(fileName);

			foreach (Worksheet item in results)
			{
				Worksheetname.Add(item.Name);
			}

			workbook.Worksheets.Remove(Worksheetname[1].ToString());

			workbook.SaveToFile(fileName, ExcelVersion.Version2010);
		}

		private static WorksheetsCollection GetAllWorksheets(string fileName)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(fileName);
            WorksheetsCollection worksheets = workbook.Worksheets;
            return worksheets;
        }
        private static string countSheet(Worksheet sheet)
        {
			int rowCount = sheet.LastRow-1;
            int columnCount = sheet.LastColumn;
            CellRange lastCell = null;
            for (int i = rowCount; i >= 1; i--)
            {
                for (int j = columnCount; j >= 1; j--)
                {
                    CellRange range = sheet.Range[i, j];
                    if (range.Text == null)
                    {
                        continue;
                    }
                    if (!String.IsNullOrEmpty(range.Text.Trim()))
                    {
                        lastCell = range;
                        i = 1;
                        break;
                    }
                }
            }
			return lastCell.Row.ToString();
		}
    }
}
