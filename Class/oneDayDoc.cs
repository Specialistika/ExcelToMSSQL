using Spire.Xls;
using Spire.Xls.Collections;
using System;
using System.IO;
using Load_bank_files.Class.config;
using System.Collections.Generic;
using Load_bank_files.Forms;
using Load_bank_files.Class.DataOneDoc;
using System.Threading;

namespace Load_bank_files.Class.DayDoc
{
    public class oneDaydoc
    {
        public static void oneDayfiles(string filesnames)
        {
            string fileName = null;
            string pageCount = null;
            Workbook workbook = new Spire.Xls.Workbook();
            string files = Convert.ToString(Path.GetFullPath(filesnames));
            string nameFiles = Convert.ToString(Path.GetFileName(filesnames));
            workbook.LoadFromFile(files);

            Worksheet sheet = workbook.Worksheets[0];

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

            sheet.Name = "List1";

            workbook.SaveToFile(variable_config.sb_new_format + "tempSBfile.xlsx", ExcelVersion.Version2010);

            fileName = variable_config.sb_new_format + "tempSBfile.xlsx";

            deleteEmpty(fileName);

            pageCount = countSheet(sheet);

            oneDayFiles dayFiles = oneDayFiles.GetInstance();
            dayFiles.SampleFunction(pageCount, nameFiles);

            dateOneDocSB.SaveToTempbase(fileName);
        }

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

            workbook.SaveToFile(variable_config.sb_new_format + "sampless.xlsx", ExcelVersion.Version2010);
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
