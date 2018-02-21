using Load_bank_files.Class.config;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Load_bank_files.Class.Load_Data
{
	public static class Load_Data_DataDev
	{
		private static string YearMonth = variable_config.year + variable_config.month;

		public static Tuple<string> Load_data_dev(int bank)
		{
			int countStart = 0;
			string bank_id = "";
			string commsql = "";

			string CgConvert = "collate Cyrillic_General_CI_AS as";
			switch (bank)
			{
				case 3:
					bank_id = "dbo._bank_3";
					commsql = string.Format("select {0} as year_month, one {1} Terminal, two {1} Cardnum, " +
								   "three {1} DateT, four {1} TimeT, five {1} AutCode, " +
								   "six {1} DateP, seven {1} Sum, eight {1} Comis, nine {1} RRN from tempDbase"
								   , YearMonth, CgConvert);
					break;
				case 4:
					bank_id = "dbo._bank_4";
					commsql = string.Format("select {0} as year_month, [Terminal] {1} Terminal, [Cardnum] {1} Cardnum, " +
											"[Sum] {1} Sum, [Comis] {1} Comis, CONVERT(VARCHAR(20), TimeT, 120) {1} DateT, " +
											"[RRN] {1} Status, [Typ] {1} Type, [PS] {1} PS, " +
											"[AutCode] {1} AutCode, [Emitent] {1} NameCard from tempDbase"
											, YearMonth, CgConvert);
					break;
				case 5:
					bank_id = "dbo._bank_5";
					commsql = string.Format("select {0} as year_month, [Terminal] {1} Terminal, [Cardnum] {1} Cardnum, " +
											"[Sum] {1} Sum, [Comis] {1} Comis, CONVERT(VARCHAR(20), TimeT, 120) {1} DateT, " +
											"[RRN] {1} Status, [Typ] {1} Type, [PS] {1} PS, " +
											"[AutCode] {1} AutCode, [Emitent] {1} NameCard from tempDbase"
											, YearMonth, CgConvert);
					break;
				case 1:
					bank_id = "dbo._bank_1";
					commsql = string.Format("select {0} as year_month, CONVERT(VARCHAR(20), TimeT, 120) {1} TimeT, CONVERT(VARCHAR(20), DateT, 120) {1} DateT, " +
											"Terminal {1} Terminal, Cardnum {1} Cardnum, AutCode {1} AutCode, " +
											"Sum {1} Sum, Comis {1} Comis, RRN {1} RRN " +
											"from tempDbase"
											, YearMonth, CgConvert);
					break;
			}

			String queryCount = $"select count(*) from { bank_id } where year_month = { YearMonth }";

			using (var sqlconn = new SqlConnection(variable_config.ConnectionLocal))
			{
				sqlconn.Open();
				SqlCommand commSurceread = new SqlCommand(commsql, sqlconn);
				SqlDataReader reader = commSurceread.ExecuteReader();

				using (var sqlconnDest = new SqlConnection(variable_config.ConnStrgingBase))
				{
					using (var BulkCopy = new SqlBulkCopy(sqlconnDest))
					{
						try
						{
							BulkCopy.DestinationTableName = bank_id;
							switch (bank)
							{
								case 1:
									MappingSchema.mapTemplong(BulkCopy);
									break;
								case 3:
									MappingSchema.mapTemplong(BulkCopy);
									break;
								case 4:
									MappingSchema.mapTemplong(BulkCopy);
									break;
								case 5:
									MappingSchema.mapTemplong(BulkCopy);
									break;
							}

							sqlconnDest.Open();
							BulkCopy.BulkCopyTimeout = variable_config.timerProgressbar;
							BulkCopy.WriteToServer(reader);
							reader.Close();
							countStart = Convert.ToInt32(new SqlCommand(queryCount, sqlconnDest).ExecuteScalar());
							sqlconnDest.Close();
							sqlconn.Close();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
			}
			return new Tuple<string>(countStart.ToString());
		}

		public static void delTemp(int bank)
        {
            string bank_id = "";
			switch (bank)
			{
				case 3:
					bank_id = "vtb_bank";
					break;
				case 4:
				case 5:
					bank_id = "gpb";
					break;
			}
			using (SqlConnection sqlconn = new SqlConnection(variable_config.ConnectionLocal))
            {
				try
				{
					sqlconn.Open();
					SqlCommand commDeltemp = new SqlCommand(string.Format("delete from {0}", bank_id), sqlconn);
					commDeltemp.ExecuteNonQuery();
					sqlconn.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
        }
    }
}
