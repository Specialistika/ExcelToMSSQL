using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Load_bank_files.Class.config;
using System.Threading.Tasks;

namespace Load_bank_files.Class.loadMineTable
{
	public static class AddToMineTable
    {
        private static string year = variable_config.year;
        private static string month = variable_config.month;

		public static string UploadSBtemp(IProgress<string> progress)
        {
			SqlParameter RowCountemp = null;
			SqlParameter RowCounterr = null;

            using (var SqlConn = new SqlConnection(variable_config.ConnStrgingBase))
            {
                try
                {
					var SqlCmd = new SqlCommand("sp_bank_import_s_sb", SqlConn) { CommandType = CommandType.StoredProcedure };

					SqlCmd.Parameters.AddWithValue("@current_year", year);
                    SqlCmd.Parameters.AddWithValue("@current_month", month);
                    SqlCmd.Parameters.AddWithValue("@step", 3);

                    RowCountemp = new SqlParameter("@RowCount_temp", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
                    RowCounterr = new SqlParameter("@RowCount_error", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
					SqlParameter RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
                    SqlParameter RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

					SqlCmd.Parameters.Add(RowCountemp);
					SqlCmd.Parameters.Add(RowCounterr);
					SqlCmd.Parameters.Add(RowCountDel);
					SqlCmd.Parameters.Add(RowCountAdd);

                    SqlCmd.CommandTimeout = variable_config.timerProgressbar;
                    SqlConn.Open();
                    SqlCmd.ExecuteNonQuery();
					SqlConn.Close();
				}
                catch (Exception ex)
                {
                    MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
                }
            }
            return RowCountemp.Value.ToString() + ""+ RowCounterr.Value.ToString();
        }
        public static string UploadSBmine(IProgress<string> progress)
        {
			SqlParameter RowCountDel = null;
			SqlParameter RowCountAdd = null;

            using (var SqlConn = new SqlConnection(config.variable_config.ConnStrgingBase))
            {
                try
                {
                    var SqlCmd = new SqlCommand("sp_bank_import_s_sb", SqlConn) { CommandType = CommandType.StoredProcedure };

					SqlCmd.Parameters.AddWithValue("@current_year", year);
                    SqlCmd.Parameters.AddWithValue("@current_month", month);
                    SqlCmd.Parameters.AddWithValue("@step", 4);

                    SqlParameter RowCountemp = new SqlParameter("@RowCount_temp", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
                    SqlParameter RowCounterr = new SqlParameter("@RowCount_error", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
                    RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
                    RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

					SqlCmd.Parameters.Add(RowCountemp);
					SqlCmd.Parameters.Add(RowCounterr);
					SqlCmd.Parameters.Add(RowCountDel);
					SqlCmd.Parameters.Add(RowCountAdd);

                    SqlCmd.CommandTimeout = variable_config.timerProgressbar;
                    SqlConn.Open();
                    SqlCmd.ExecuteNonQuery();
					SqlConn.Close();
				}
                catch (Exception ex)
                {
                    MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
                }
            }
            return RowCountDel.Value.ToString() + " " + RowCountAdd.Value.ToString();
        }
		public static Tuple<string, string, string> UploadGPBmine(int bank)
		{
			string year_month = Convert.ToInt32(year) + month;
			SqlParameter RowCountDel = null;
			SqlParameter RowCountAdd = null;
			SqlParameter RowCountDub = null;

			string bank_id = "";
			switch (bank)
			{
				case 1:
					bank_id = "sp_bank_import_sb_s_ver";
					break;
				case 3:
					bank_id = "sp_bank_import_vtb_kld_s_ver";
					break;
				case 4:
					bank_id = "sp_bank_import_gpb_msk_s_ver";
					break;
				case 5:
					bank_id = "sp_bank_import_gpb_kld_s_ver";
					break;
			}
			using (var SqlConn = new SqlConnection(config.variable_config.ConnStrgingBase))
			{
				try
				{
					var SqlCmd = new SqlCommand(bank_id, SqlConn) { CommandType = CommandType.StoredProcedure };

					SqlCmd.Parameters.AddWithValue("@year_month", year_month);

					RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
					RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
					RowCountDub = new SqlParameter("@RowCount_dub", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

					SqlCmd.Parameters.Add(RowCountDel);
					SqlCmd.Parameters.Add(RowCountAdd);
					SqlCmd.Parameters.Add(RowCountDub);

					SqlCmd.CommandTimeout = variable_config.timerProgressbar;
					SqlConn.Open();
					SqlCmd.ExecuteNonQuery();
					SqlConn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
				}
			}
			return new Tuple<string, string, string>(RowCountDel.Value.ToString(), RowCountAdd.Value.ToString(), RowCountDub.Value.ToString());
		}
		public static Task<int> UpdateSapTable(int bank_id, string path)
		{
			SqlParameter RowCountDel = null;
			SqlParameter RowCountAdd = null;
			SqlParameter RowCountDub = null;

			Task<int> resultt = null;

			using (var SqlConn = new SqlConnection(variable_config.ConnStrgingBase))
			{
				try
				{
					var SqlCmd = new SqlCommand("sp_sap_import_s", SqlConn) { CommandType = CommandType.StoredProcedure };

					SqlCmd.Parameters.AddWithValue("@current_year", year);
					SqlCmd.Parameters.AddWithValue("@current_month", month);
					SqlCmd.Parameters.AddWithValue("@bank_id", bank_id);
					SqlCmd.Parameters.AddWithValue("@path", path);

					RowCountAdd = new SqlParameter("@RowCount_add", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
					RowCountDel = new SqlParameter("@RowCount_del", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };
					RowCountDub = new SqlParameter("@RowCount_dub", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

					SqlCmd.Parameters.Add(RowCountAdd);
					SqlCmd.Parameters.Add(RowCountDel);
					SqlCmd.Parameters.Add(RowCountDub);

					SqlCmd.CommandTimeout = variable_config.timerProgressbar;
					SqlConn.Open();
					resultt = Task.Run(() => { int result = 0; SqlCmd.ExecuteNonQuery(); return result; });
					resultt.GetAwaiter().GetResult();
					SqlConn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: нет соединения с базой: " + ex.Message);
				}
				MessageBox.Show($"Банк { bank_id } Всего строк {RowCountAdd.Value.ToString()} Удалено {RowCountDel.Value.ToString()} Добавлено {RowCountDub.Value.ToString()}");
			}
			return resultt;
		}
	}
}
