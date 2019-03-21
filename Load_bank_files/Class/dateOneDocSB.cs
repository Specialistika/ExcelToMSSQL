using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Load_bank_files.Forms;
using Load_bank_files.Class.config;

namespace Load_bank_files.Class.DataOneDoc
{
	public static class dateOneDocSB
    {
        public static void SaveToTempbase(string filePath)
        {
            string cmdQuery = "";
            String excelConnString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=\"Excel 12.0\"";
            using (OleDbConnection excelConn = new OleDbConnection(excelConnString))
            {
				switch (MineGenegalForms.TypeFile_)
				{
					case 1:
						cmdQuery = $"Select TimeT+DateT as TimeS, TimeT as Datet, Terminal, Cardnum, AutCode, Sum, Comis, RRN from [List{1}$]";
						break;
					case 2:
						cmdQuery = $"Select Terminal, LEFT(TimeT, 10) +' '+REPLACE(RIGHT(TimeT, 8),'.',':') as TimeS, LEFT(TimeT, 10) as Datet, Sum,  Comis, RRN, Cardnum, AutCode from [List{1}$]";
						break;
					case 3:
						cmdQuery = $"Select LEFT(TimeT, 10) +' '+REPLACE(RIGHT(TimeT, 8),'.',':') as TimeS, LEFT(TimeT, 10) as Datet, Terminal, Cardnum, AutCode, Sum, Comis, RRN from [List{1}$]";
						break;
					case 4:
					case 5:
						cmdQuery = $"Select LEFT(TimeT, 10) +' '+REPLACE(RIGHT(TimeT, 9),'.',':') as TimeS, LEFT(TimeT, 10) as Datet, Terminal, Cardnum, AutCode, Sum, Comis, Status as RRN, Typ, PS, Emitent from [List{1}$]";
						break;
				}
				using (OleDbCommand cmd = new OleDbCommand(cmdQuery, excelConn))
                {
                    excelConn.Open();
                    using (OleDbDataReader OleReader = cmd.ExecuteReader())
                    {
                        using (SqlBulkCopy copyBulk = new SqlBulkCopy(variable_config.ConnectionLocal))
                        {
                            copyBulk.DestinationTableName = "tempDbase";
                            try
                            {
								MappingSchema.mapTemplocal(copyBulk);

								copyBulk.WriteToServer(OleReader);

								OleReader.Close();
								excelConn.Close();
							}
                            catch (Exception s)
                            {
                                MessageBox.Show(s.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
