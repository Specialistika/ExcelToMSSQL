using Load_bank_files.Class.config;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Load_bank_files.Class
{
	public static class deleteDBbase
	{
		public static void delBakns(int bank)
		{
			string bank_id = "";
			switch (bank)
			{
				case 3:
					bank_id = "dbo._bank_3";
					break;
				case 4:
					bank_id = "dbo._bank_4";
					break;
				case 5:
					bank_id = "dbo._bank_5";
					break;
				case 1:
					bank_id = "dbo._bank_1";
					break;
			}
			string comDel = $"delete from {bank_id} where year_month = {((Convert.ToInt32(variable_config.year)) + variable_config.month)}";

			using (var sqlconnDest = new SqlConnection(variable_config.ConnStrgingBase))
			{
				SqlCommand commDel = new SqlCommand(comDel, sqlconnDest);

				try
				{
					sqlconnDest.Open();
					commDel.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					sqlconnDest.Close();
				}
			}
		}
	}
}
