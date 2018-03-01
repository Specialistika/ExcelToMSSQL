using Load_bank_files.Class.config;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Load_bank_files.Class.deleteDBbase
{
	public static class DeleteDBbase
	{
		public static async Task DelBakns(int bank)
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
					commDel.CommandTimeout = variable_config.timerProgressbar;
					await Task.Factory.StartNew(() => commDel.ExecuteNonQuery());
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
		public static async Task<bool> DeleteFile(string path)
		{
			string[] deleteDir = Directory.GetFiles(path, "*.xlsx");
			try
			{
				foreach (string del in deleteDir)
				{
					await Task.Run(() => File.Delete(del));
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
