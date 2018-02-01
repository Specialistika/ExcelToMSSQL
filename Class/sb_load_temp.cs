using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using Load_bank_files.Class.config;
using Load_bank_files.Forms;
using System.Threading.Tasks;

namespace Load_bank_files.Class.loadMineTable
{
    public class loadMineTable
    {
        private string year = config.variable_config.year;
        private string month = config.variable_config.month;
        //public static string progressbarProcess(IProgress<string> progress)
        //{
        //    //wbf.progressbarProcess(IProgress < string > progress);
        //    // Perform a long running work...
        //    //for (var i = 0; i < 10; i++)
        //    //{
        //    //    Task.Delay(500).Wait();
        //    //    progress.Report(i.ToString());
        //    //}
        //    return "результат";
        //}


        public static string sb_load_temp_table(IProgress<string> progress)
        {
            //out string rowCountemp, out string rowCounterr
            string rowCountemp = "";
            string rowCounterr = "";
            using (var SqlConn = new SqlConnection(config.variable_config.ConnStrg))
            {
                try
                {
                    var SqlCmd = new SqlCommand("sp_bank_import_s_sb", SqlConn);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@current_year", config.variable_config.year);
                    SqlCmd.Parameters.AddWithValue("@current_month", config.variable_config.month);
                    SqlCmd.Parameters.AddWithValue("@step", 3);

                    SqlParameter RowCountemp = new SqlParameter("@RowCount_temp", SqlDbType.VarChar, 20);
                    RowCountemp.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountemp);
                    SqlParameter RowCounterr = new SqlParameter("@RowCount_error", SqlDbType.VarChar, 50);
                    RowCounterr.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCounterr);

                    SqlParameter RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20);
                    RowCountDel.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountDel);
                    SqlParameter RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20);
                    RowCountAdd.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountAdd);

                    SqlCmd.CommandTimeout = variable_config.timerProgressbar;
                    SqlConn.Open();
                    SqlCmd.ExecuteNonQuery();
                    rowCountemp = RowCountemp.Value.ToString();
                    rowCounterr = RowCounterr.Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
                }
                finally
                {
                    SqlConn.Close();
                }
            }
            return rowCountemp +""+ rowCounterr;
        }
        public static string sb_load_mine_table(IProgress<string> progress)
        {
            string rowCountdel = "";
            string rowCountAdd = "";
            using (var SqlConn = new SqlConnection(config.variable_config.ConnStrg))
            {
                try
                {
                    var SqlCmd = new SqlCommand("sp_bank_import_s_sb", SqlConn);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@current_year", config.variable_config.year);
                    SqlCmd.Parameters.AddWithValue("@current_month", config.variable_config.month);
                    SqlCmd.Parameters.AddWithValue("@step", 4);

                    SqlParameter RowCountemp = new SqlParameter("@RowCount_temp", SqlDbType.VarChar, 20);
                    RowCountemp.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountemp);
                    SqlParameter RowCounterr = new SqlParameter("@RowCount_error", SqlDbType.VarChar, 20);
                    RowCounterr.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCounterr);

                    SqlParameter RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20);
                    RowCountDel.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountDel);
                    SqlParameter RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20);
                    RowCountAdd.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountAdd);

                    SqlCmd.CommandTimeout = 350;
                    SqlConn.Open();
                    SqlCmd.ExecuteNonQuery();
                    rowCountdel = RowCountDel.Value.ToString();
                    rowCountAdd = RowCountAdd.Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
                }
                finally
                {
                    SqlConn.Close();  
                }
            }
            return rowCountdel + " " + rowCountAdd;
        }
        public static async  Task<Tuple<string, string, string>> proc_import_vtb_gpb(int bank)
        {
            //out string rowCountDel, out string rowCountAdd, out string rowCountDub,
            string year_month = (Convert.ToInt32(config.variable_config.year)) + config.variable_config.month;
            string rowCountDel = "";
            string rowCountAdd = "";
            string rowCountDub = "";
            string bank_id = "";
            if (bank == 1)
            {
                bank_id = "sp_bank_import_sb_s_ver";
            }
            if (bank == 3)
            {
                bank_id = "sp_bank_import_vtb_kld_s_ver";
            }
            else if (bank == 4)
            {
                bank_id = "sp_bank_import_gpb_msk_s_ver";
            }
            else if (bank == 5)
            {
                bank_id = "sp_bank_import_gpb_kld_s_ver";
            }
            using (var SqlConn = new SqlConnection(config.variable_config.ConnStrg))
            {
                try
                {
                    var SqlCmd = new SqlCommand(bank_id, SqlConn);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@year_month", year_month);
                    SqlParameter RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20);
                    RowCountDel.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountDel);

                    SqlParameter RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20);
                    RowCountAdd.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountAdd);

                    SqlParameter RowCountDub = new SqlParameter("@RowCount_dub", SqlDbType.VarChar, 20);
                    RowCountDub.Direction = ParameterDirection.Output;
                    SqlCmd.Parameters.Add(RowCountDub);

                    SqlCmd.CommandTimeout = 300;
                    SqlConn.Open();
                    SqlCmd.ExecuteNonQuery();
                    rowCountDel = RowCountDel.Value.ToString();
                    rowCountAdd = RowCountAdd.Value.ToString();
                    rowCountDub = RowCountDub.Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
                }
                finally
                {
                    SqlConn.Close();
                }
            }
            return new Tuple<string, string, string>(rowCountDel, rowCountAdd, rowCountDub);
        }
    }
}
