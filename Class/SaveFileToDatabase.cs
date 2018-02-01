using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using conn_str = Load_bank_files.Class.config.variable_config;
using System.IO;

namespace Load_bank_files.Class.ToDatabase
{
    public class SaveFileToDatabase
    {
        public void SaveToDatabase(string filePath, int bank, int countSheet)
        {
            String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);

            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            {
                for (int i = 1; i <= countSheet; i++)
                {
                    string cmdExc = string.Format("Select * from [List{0}$]", i);
                    using (OleDbCommand cmd = new OleDbCommand(cmdExc, excelConnection))
                    {
                        excelConnection.Open();
                        using (OleDbDataReader dReader = cmd.ExecuteReader())
                        {
                            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(conn_str.ConnectionLocal))
                            {
                                if(bank == 3)
                                sqlBulk.DestinationTableName = "vtb_bank";
                                else
                                sqlBulk.DestinationTableName = "gpb";
                                try
                                {
                                    sqlBulk.WriteToServer(dReader);
                                    while (dReader.Read())
                                    {
                                        sqlBulk.WriteToServer(dReader);
                                    }
                                }
                                catch (Exception s)
                                {
                                    MessageBox.Show(s.Message);
                                }
                                finally
                                {
                                    dReader.Close();
                                    excelConnection.Close();
                                }
                            }
                        }
                    }
                }
                File.Delete(filePath);
            }
        }
        public string DeleteBadRow(int bank_id)
        {
            string bank = "";
            bank = (bank_id == 3) ? "vtb_bank" : "gpb";

            Int32 resultcount = 0;
            string sqlcount = string.Format("select count(*) from {0}", bank);
            string sqlstring = string.Format("delete from {0} where one is null or three is null or three = '' or one like '?%'", bank);
            using (SqlConnection sqlconn = new SqlConnection(conn_str.ConnectionLocal))
            {
                sqlconn.Open();
                SqlCommand cmdstring = new SqlCommand(sqlstring, sqlconn);
                try
                {
                    cmdstring.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка", ex.Message);
                }
                    SqlCommand cmdint = new SqlCommand(sqlcount, sqlconn);
                    try
                    {
                        Int32 getvalues = (Int32)cmdint.ExecuteScalar();
                        if (getvalues != 0)
                        {
                            resultcount = getvalues;
                        }
                    }
                    catch (SqlException ex)
                        {
                            MessageBox.Show("Ошибка", ex.Message);
                        }
                    sqlconn.Close();
            }
            return resultcount.ToString();
            #region test
            ////lcg.GetDataView gtv = new lcg.GetDataView();
            ////gtv.GetData("select * from vtb_bank");
            //string selectCommand = "select * from vtb_bank";
            //SqlDataAdapter Date_adapter = new SqlDataAdapter(selectCommand, conn_str.ConnectionLocal);
            //DataSet ds = new DataSet();
            //ds.Locale = CultureInfo.InvariantCulture;
            //Date_adapter.Fill(ds);
            //var dt = ds.Tables["vtb_bank"].AsEnumerable();
            //    //lcg.GetDataView.table_bank["vtb_bank"];

            //var query = from vb in dt
            //            where vb.Field<string>("three").Contains(null) || vb.Field<string>("three").Contains("") || vb.Field<string>("one").Contains("?")
            //            select vb;

            ////var query = dt.AsEnumerable()
            ////            .Where(r => r.Field<string>("three").Contains(null) || r.Field<string>("three").Contains("") || r.Field<string>("one").Contains("?"));
            
            //foreach (var row in query.ToList())
            //{
            //    row.Delete();
            //}
            #endregion
        }
    }
}
