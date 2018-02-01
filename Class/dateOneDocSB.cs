using System;
using System.Windows.Forms;
using conn_str = Load_bank_files.Class.config.variable_config;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Load_bank_files.Class.DataOneDoc
{
    public static class dateOneDocSB
    {
        public static void SaveToTempbase(string filePath)
        {
            String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
            using (OleDbConnection excelConn = new OleDbConnection(excelConnString))
            {
                string cmdQuery = string.Format("Select TimeT+DateT as DataTimeT, TimeT, Terminal, Cardnum, AutCode, Sum, Comis, RRN from [List{0}$]", 1);
                using (OleDbCommand cmd = new OleDbCommand(cmdQuery, excelConn))
                {
                    excelConn.Open();
                    using (OleDbDataReader OleReader = cmd.ExecuteReader())
                    {
                        using (SqlBulkCopy copyBulk = new SqlBulkCopy(conn_str.ConnectionLocal))
                        {
                            copyBulk.DestinationTableName = "newSB";
                            try
                            {
                                SqlBulkCopyColumnMapping mapID =
        new SqlBulkCopyColumnMapping("DataTimeT", "TimeT");
                            copyBulk.ColumnMappings.Add(mapID);

                            SqlBulkCopyColumnMapping mapName =
        new SqlBulkCopyColumnMapping("TimeT", "DateT");
                            copyBulk.ColumnMappings.Add(mapName);

                            SqlBulkCopyColumnMapping mapMumber =
        new SqlBulkCopyColumnMapping("Terminal", "Terminal");
                            copyBulk.ColumnMappings.Add(mapMumber);

                            SqlBulkCopyColumnMapping mapA =
        new SqlBulkCopyColumnMapping("Cardnum", "Cardnum");
                            copyBulk.ColumnMappings.Add(mapA);

                            SqlBulkCopyColumnMapping mapB =
        new SqlBulkCopyColumnMapping("AutCode", "AutCode");
                            copyBulk.ColumnMappings.Add(mapB);

                            SqlBulkCopyColumnMapping mapC =
        new SqlBulkCopyColumnMapping("Sum", "Sum");
                            copyBulk.ColumnMappings.Add(mapC);

                            SqlBulkCopyColumnMapping mapD =
       new SqlBulkCopyColumnMapping("Comis", "Comis");
                            copyBulk.ColumnMappings.Add(mapD);

                            SqlBulkCopyColumnMapping mapE =
        new SqlBulkCopyColumnMapping("RRN", "RRN");
                            copyBulk.ColumnMappings.Add(mapE);


                                copyBulk.WriteToServer(OleReader);
                                while (OleReader.Read())
                                {
                                    copyBulk.WriteToServer(OleReader);
                                }
                            }
                            catch (Exception s)
                            {
                                MessageBox.Show(s.Message);
                            }
                            finally
                            {
                                OleReader.Close();
                                excelConn.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
