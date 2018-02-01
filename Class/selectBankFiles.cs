using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Permissions;
using System.Security;
using Load_bank_files.Class.ToDatabase;

namespace Load_bank_files.Class.sb_load
{
    public class sb_load_files 
    {


        public void sb_load_form(out string[] fl_names, out int n_count, int sb_mark, string fildirectoryout)
        {
            fl_names = new string[]{};
            n_count = 0;
            Stream myStream = null;
                int l = 0;
                l = (sb_mark == 1 || sb_mark == 4 || sb_mark == 5) ? 4 : 5;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xls files (*.xls)|*.xls|(*.xlsx)|*.xlsx";
            ofd.FilterIndex = 2;
            ofd.Multiselect = true;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dir_open_file = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf('\\')) + "\\";
                int count = ofd.SafeFileNames.Length;
                string[] filenamess = new string[count];
                    foreach (String File in ofd.SafeFileNames)
                    {
                        try
                        {
                            if ((myStream = ofd.OpenFile()) != null)
                            {
                                using (myStream)
                                {
                                    filenamess = ofd.SafeFileNames;
                                    int filesave = File.Length - l; //5-vtb 4-sb
                                    string Filess = File.Remove(filesave);
                                    string open_file = dir_open_file + File;
                                 switch(sb_mark)
                                    {
                                    case 1:
                                            sb_load(fildirectoryout, Filess, open_file);
                                    break;
                                    case 3:
                                            vtb_kld_load(dir_open_file, Filess, open_file);
                                    break;
                                    case 4:
                                            gpb_msk_load(dir_open_file, Filess, open_file);
                                    break;
                                    case 5:
                                            gpb_msk_load(dir_open_file, Filess, open_file);
                                    break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Не возможно прочитать файл: " + ex.Message);
                        }
                    }
                    if (filenamess.Length != 0)
                    {
                        fl_names = filenamess;
                        n_count = count;
                    }
                
            }
            
        }
        public void sb_load(string fildirectoryout, string Filess, string open_file)
        {
            Excel.Application xl = new Excel.Application();
            Excel.Workbook xlx = xl.Workbooks.Open(open_file);
            xlx.SaveCopyAs(fildirectoryout + Filess + ".xlsx");
            xlx.Close();
        }
        public void vtb_kld_load(string dir_open_file, string Filess, string open_file)
        {
            Excel.Application xl = new Excel.Application();
            Object missing = Type.Missing;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            oWB = xl.Workbooks.Open(open_file, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            int countSheeet = oWB.Worksheets.Count;
            for (int s = 1; s <= countSheeet; s++)
            {
                oSheet = (Excel._Worksheet)oWB.Worksheets.get_Item(s);
                string oSN = oSheet.Name.ToString();
                int lastrow = xl.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                int strtRow = oSheet.UsedRange.Rows[1].Row;
                FileIOPermission fp = new FileIOPermission(FileIOPermissionAccess.Read, dir_open_file);
                fp.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, open_file);
                try
                {   
                    fp.Demand();
                }
                catch (SecurityException es)
                {
                    MessageBox.Show(es.Message);
                }

                try
                {
                    oSheet.Name = "List"+s;
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                if (oSheet.AutoFilterMode)
                {
                    oSheet.AutoFilterMode = false;
                }

                for (int i = 1; i <= lastrow; i++)
                {
                    if (oSheet.Cells[i, strtRow].MergeCells)
                    {
                        oSheet.Cells[i, strtRow].UnMerge();
                    }
                }
            }
            xl.DisplayAlerts = true;
            oWB.SaveAs(dir_open_file + Filess + "_2.xlsx");
            xl.Workbooks.Close();
            xl.Quit();
            SaveFileToDatabase sft = new SaveFileToDatabase();
            sft.SaveToDatabase(dir_open_file + Filess + "_2.xlsx", 3, countSheeet);
            

            #region test

            //string filepath = dir_open_file + Filess + "xlsx";
            //DataTable workTable = new DataTable("Banks");
            //DataSet Banks = new DataSet();
            //DataTable Custom_bank = Banks.Tables.Add("Custom_bank");

            //using (SqlConnection sqlconn = new SqlConnection(variable_config.variable_config.ConnectionLocal))
            //{
            //    sqlconn.Open();
            //    using (var stream = File.Open(dir_open_file + Filess + "xlsx", FileMode.Open, FileAccess.Read))
            //    {



            //        if (Path.GetExtension(filepath).ToUpper() == ".XLS")
            //        {
            //            //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
            //            IExcelDataReader excelRead = ExcelReaderFactory.CreateBinaryReader(stream);
            //        }
            //        else
            //        {
            //            //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
            //            IExcelDataReader excelRead = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //        }

            //        DataSet result = excelRead.AsDataSet();

            //        //var col = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
            //        using (var reader = ExcelReaderFactory.CreateReader(stream))
            //        {
            //            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlconn))
            //            {
            //                foreach (DataColumn coll in Custom_bank.Columns)
            //                    bulkCopy.ColumnMappings.Add(coll.ColumnName, coll.ColumnName);
            //                bulkCopy.DestinationTableName = "SQLTempTable";
            //                bulkCopy.WriteToServer(Custom_bank);

                            ////string connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=YES';Data Source={0}{1}", dir_open_file, Filess + "xlsx");
                            //string connStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}{1};Extended Properties=\"Excel 12.0\"", dir_open_file, Filess + "xlsx");
                            ////Microsoft.ACE.OLEDB.12.0;Excel 12.0;Database={0}{1}", dir_open_file, Filess + "xlsx");
                            //string cmdStr = "select 'A1' from [Лист1$]";
                            //using (OleDbConnection oConn = new OleDbConnection(connStr))
                            //{
                            //    using (OleDbCommand cmd = new OleDbCommand(cmdStr, oConn))
                            //    {
                            //        oConn.Open();
                            //        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                            //        da.Fill(Custom_bank);
                            //        oConn.Close();
                            //   }
                            //}

            //            }
            //        }
            //    }
            //}
            

            
            /*
            string fl_dir = fildirectoryout + "3" + ".xlsx";
            Excel.Application xl = new Excel.Application();
            Object missing = Type.Missing;
            xl.Workbooks.Open(open_file, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Excel.Worksheet sheet = xl.ActiveSheet as Excel.Worksheet;
            

            if (sheet.AutoFilterMode)
            {
                sheet.AutoFilterMode = false;
            }
            int lastrow = xl.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            for (int i = 1; i <= lastrow; i++)
            {

                Excel.Range rng = sheet.Rows[i, Type.Missing];
                rng = sheet.get_Range(i, Type.Missing);
                

                //////////////////
                bool blanksExist = xl.WorksheetFunction.CountBlank(rng) > 0;

                if (blanksExist)
                {
                    if (sheet.Cells[i, 1].MergeCells)
                    {
                        rng.Merge(false);
                    }

                    string tr = sheet.Cells[i, 1].Text.ToString();
                    if (sheet.Cells[i, 1].Text.ToString()!="")
                    {
                        string trs = tr.Substring(0, 1);
                        foreach (char t in trs)
                            if (char.IsLetter(t))
                            {
                                rng.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                                break;
                            }
                    }
                    //for (int p = 0; p < tr.Length; p++)
                    //{
                    //    if (tr[p] >= 'а' && tr[p] <= 'я')
                    //    {
                    //        rng.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);                          
                    //    }

                    //}


                    if (String.IsNullOrEmpty(sheet.Cells[i, 1].Text.ToString()))
                        {
                            rng.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                        }


                    //Excel.Range rngBlanks = rng.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                        //XlCellType.xlCellTypeBlanks);
                    //rngBlanks.Interior.Color = Color.Yellow;
                    //Excel.Range rg = (Excel.Range)sheet.Rows[i, Type.Missing];
                    //rg.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }
                else
                {
                    MessageBox.Show("No blank cells exist in the specified range.");
                }
             
            }

            //Excel.Range rg = (Excel.Range)sheet.Rows[5, Type.Missing];
            //rg.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);

            //Excel.Workbook xlx = xl.Workbooks.Open(open_file);
            //char[] splitChars = new char[] { '\n', '\r' };
            //foreach (var item in inputText.Split(splitChars, StringSplitOptions.RemoveEmptyEntries))
            //    if (!string.IsNullOrEmpty(item.Trim()))
            //        definitionList.Add(item);

            //xlx.SaveCopyAs(fildirectoryout + "3" + ".xlsx");
            //xlx.Close();
            //xl.Workbooks.Application.GetSaveAsFilename(fildirectoryout + "3" + ".xlsx");




            
            xl.ActiveWorkbook.SaveAs(fl_dir);
            xl.Workbooks.Close();
            xl.Quit();
        
            */
            #endregion
        }
        public void gpb_msk_load(string dir_open_file, string Filess, string open_file)
        {
            Excel.Application xl = new Excel.Application();
            Object missing = Type.Missing;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            oWB = xl.Workbooks.Open(open_file, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            int countSheeet = oWB.Worksheets.Count;
            for (int s = 1; s <= countSheeet; s++)
            {
                oSheet = (Excel._Worksheet)oWB.Worksheets.get_Item(s);
                string oSN = oSheet.Name.ToString();
                int lastrow = xl.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                int strtRow = oSheet.UsedRange.Rows[1].Row;
                FileIOPermission fp = new FileIOPermission(FileIOPermissionAccess.Read, dir_open_file);
                fp.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, open_file);
                try
                {
                    fp.Demand();
                }
                catch (SecurityException es)
                {
                    MessageBox.Show(es.Message);
                }

                try
                {
                    oSheet.Name = "List"+s;
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                if (oSheet.AutoFilterMode)
                {
                    oSheet.AutoFilterMode = false;
                }

                //for (int i = 1; i <= lastrow; i++)
                //{
                //    if (oSheet.Cells[i, strtRow].MergeCells)
                //    {
                //        oSheet.Cells[i, strtRow].UnMerge();
                //    }
                //}
            }   
            xl.DisplayAlerts = true;
            oWB.SaveAs(dir_open_file + Filess + "_2.xls");
            oWB.Close();
            xl.Quit();
            SaveFileToDatabase sft = new SaveFileToDatabase();
            sft.SaveToDatabase(dir_open_file + Filess + "_2.xls", 4, countSheeet);
        }

    }
 
}
