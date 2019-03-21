using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conn_str = Load_bank_files.Class.config.variable_config;

namespace Load_bank_files.Class.GetData
{
    public class GetDataView
    {
        #region singelton
        ///*
        //private static GetDataView _CS;

        //public static GetDataView Instance
        //{
        //    get
        //    {
        //        if (_CS == null)
        //            _CS = new GetDataView();

        //        return _CS;
        //    }
        //}*/


        //private static DataTable _DS;
        //public static DataTable Instance
        //{
        //    get
        //    {
        //        if (_DS == null)
        //            _DS = new DataTable("table_bank");

        //        return _DS;
        //    }
        //}

        //    DataTable dt = new DataTable();
        #endregion

        public static DataTable table_bank { get; set; }
        public void GetData(string selectCommand)
        {
            try
            {
                SqlDataAdapter Date_adapter = new SqlDataAdapter(selectCommand, conn_str.ConnectionLocal);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(Date_adapter);
                table_bank = new DataTable();
                table_bank.Locale = System.Globalization.CultureInfo.InvariantCulture;
                Date_adapter.Fill(table_bank);

            }
            catch (SqlException s)
            {
                MessageBox.Show("Нет соединения с базой", s.Message);
            }
        }
    }
}
