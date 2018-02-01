using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Load_bank_files.Class.Load_Data
{
    public static class Load_Data_DataDev
    {
        public static void delBaks(int bank)
        {
            string bank_id = "";
            if (bank == 3)
            {
                bank_id = "dbo._bank_3";
            }
            else if (bank == 4)
            {
                bank_id = "dbo._bank_4";
            }    
            else if (bank == 5)
            {
                bank_id = "dbo._bank_5";
            }
            else if (bank == 1)
            {
                bank_id = "dbo._bank_1";
            }
            string comDel = string.Format("delete from {0} where year_month = {1}", bank_id, ((Convert.ToInt32(config.variable_config.year) * 10) + config.variable_config.month));

                using (SqlConnection sqlconnDest = new SqlConnection(config.variable_config.ConnStrg))
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

        public static string  Load_data_dev(int bank)
        {
            int countStart = 0;
            string bank_id = "";
            string commsql = "";
            string bank_tmp = "";
            string CgConvert = "collate Cyrillic_General_CI_AS as";
            if (bank == 3)
            {
                bank_id = "dbo._bank_3";
                bank_tmp = "vtb_bank";
                commsql = string.Format("select {0} as year_month, one {1} Terminal, two {1} Cardnum, " +
                               "three {1} DateT, four {1} TimeT, five {1} AutCode, " +
                               "six {1} DateP, seven {1} Sum, eight {1} Comis, nine {1} RRN from {1} vb"
                               , ((Convert.ToInt32(config.variable_config.year) * 10)
                               + config.variable_config.month), CgConvert, bank_tmp);
            }
            else if (bank == 4)
            {
                bank_id = "dbo._bank_4";
                bank_tmp = "gpb";
                commsql = string.Format("select {0} as year_month, one {1} Terminal, two {1} Cardnum, " +
                                        "three {1} Sum, four {1} Comis, five {1} DateT, " +
                                        "six {1} Status, seven {1} Type, eight {1} PS, " +
                                        "nine {1} AutCode, ten {1} NameCard from {2} vb"
                                        , ((Convert.ToInt32(config.variable_config.year) * 10)
                                        + config.variable_config.month), CgConvert, bank_tmp);
            }
            else if (bank == 5)
            {
                bank_id = "dbo._bank_5";
                bank_tmp = "gpb";
                commsql = string.Format("select {0} as year_month, one {1} Terminal, two {1} Cardnum, " +
                                        "three {1} Sum, four {1} Comis, five {1} DateT, " +
                                        "six {1} Status, seven {1} Type, eight {1} PS, " +
                                        "nine {1} AutCode, ten {1} NameCard from {2} vb"
                                        , ((Convert.ToInt32(config.variable_config.year) * 10)
                                        + config.variable_config.month), CgConvert, bank_tmp);
            }
            else if (bank == 1)
            {
                bank_id = "dbo._bank_1";
                bank_tmp = "newSb";
                commsql = string.Format("select {0} as year_month, CONVERT(VARCHAR(20), TimeT, 120) {1} TimeT, CONVERT(VARCHAR(20), DateT, 120) {1} DateT, " +
                                        "Terminal {1} Terminal, Cardnum {1} Cardnum, AutCode {1} AutCode, " +
                                        "Sum {1} Sum, Comis {1} Comis, RRN {1} RRN " +
                                        "from {2}"
                                        , (Convert.ToInt32(config.variable_config.year)
                                        + config.variable_config.month), CgConvert, bank_tmp);
            }
            string queryCount = string.Format("select count(*) from {0}", bank_tmp);
            using (SqlConnection sqlconn = new SqlConnection(config.variable_config.ConnectionLocal))
            {
                sqlconn.Open();
                SqlCommand commCount = new SqlCommand(queryCount, sqlconn);
                countStart = Convert.ToInt32(commCount.ExecuteScalar());
                SqlCommand commSurceread = new SqlCommand(commsql, sqlconn);
                SqlDataReader reader = commSurceread.ExecuteReader();
            
                using (SqlConnection sqlconnDest = new SqlConnection(config.variable_config.ConnStrg))
                {
                    using (SqlBulkCopy BulkCopy = new SqlBulkCopy(sqlconnDest))
                    {
                        BulkCopy.DestinationTableName = bank_id;
                        if (bank == 3)
                        {
                            SqlBulkCopyColumnMapping mapID =
        new SqlBulkCopyColumnMapping("year_month", "year_month");
                            BulkCopy.ColumnMappings.Add(mapID);

                            SqlBulkCopyColumnMapping mapName =
        new SqlBulkCopyColumnMapping("Terminal", "Terminal");
                            BulkCopy.ColumnMappings.Add(mapName);

                            SqlBulkCopyColumnMapping mapMumber =
        new SqlBulkCopyColumnMapping("Cardnum", "Cardnum");
                            BulkCopy.ColumnMappings.Add(mapMumber);

                            SqlBulkCopyColumnMapping mapA =
        new SqlBulkCopyColumnMapping("DateT", "DateT");
                            BulkCopy.ColumnMappings.Add(mapA);

                            SqlBulkCopyColumnMapping mapB =
        new SqlBulkCopyColumnMapping("TimeT", "TimeT");
                            BulkCopy.ColumnMappings.Add(mapB);

                            SqlBulkCopyColumnMapping mapC =
        new SqlBulkCopyColumnMapping("AutCode", "AutCode");
                            BulkCopy.ColumnMappings.Add(mapC);

                            SqlBulkCopyColumnMapping mapD =
       new SqlBulkCopyColumnMapping("DateP", "DateP");
                            BulkCopy.ColumnMappings.Add(mapD);

                            SqlBulkCopyColumnMapping mapE =
        new SqlBulkCopyColumnMapping("Sum", "Sum");
                            BulkCopy.ColumnMappings.Add(mapE);

                            SqlBulkCopyColumnMapping mapF =
        new SqlBulkCopyColumnMapping("Comis", "Comis");
                            BulkCopy.ColumnMappings.Add(mapF);

                            SqlBulkCopyColumnMapping mapG =
        new SqlBulkCopyColumnMapping("RRN", "RRN");
                            BulkCopy.ColumnMappings.Add(mapG);
                        }
                        else if (bank == 4 || bank == 5)
                        {
                            SqlBulkCopyColumnMapping mapID =
        new SqlBulkCopyColumnMapping("year_month", "year_month");
                            BulkCopy.ColumnMappings.Add(mapID);

                            SqlBulkCopyColumnMapping mapName =
        new SqlBulkCopyColumnMapping("Terminal", "Терминал");
                            BulkCopy.ColumnMappings.Add(mapName);

                            SqlBulkCopyColumnMapping mapMumber =
        new SqlBulkCopyColumnMapping("Cardnum", "Номер карты");
                            BulkCopy.ColumnMappings.Add(mapMumber);

                            SqlBulkCopyColumnMapping mapA =
        new SqlBulkCopyColumnMapping("Sum", "Сумма");
                            BulkCopy.ColumnMappings.Add(mapA);

                            SqlBulkCopyColumnMapping mapB =
        new SqlBulkCopyColumnMapping("Comis", "Комиссия");
                            BulkCopy.ColumnMappings.Add(mapB);

                            SqlBulkCopyColumnMapping mapC =
        new SqlBulkCopyColumnMapping("DateT", "Дата");
                            BulkCopy.ColumnMappings.Add(mapC);

                            SqlBulkCopyColumnMapping mapD =
        new SqlBulkCopyColumnMapping("Status", "Статус");
                            BulkCopy.ColumnMappings.Add(mapD);

                            SqlBulkCopyColumnMapping mapE =
        new SqlBulkCopyColumnMapping("Type", "Тип");
                            BulkCopy.ColumnMappings.Add(mapE);

                            SqlBulkCopyColumnMapping mapF =
        new SqlBulkCopyColumnMapping("PS", "ПС");
                            BulkCopy.ColumnMappings.Add(mapF);

                            SqlBulkCopyColumnMapping mapG =
        new SqlBulkCopyColumnMapping("AutCode", "Код авторизации");
                            BulkCopy.ColumnMappings.Add(mapG);

                            SqlBulkCopyColumnMapping mapH =
        new SqlBulkCopyColumnMapping("NameCard", "Принадлежность карты");
                            BulkCopy.ColumnMappings.Add(mapH);
                        }
                        else if (bank == 1)
                        {
                            SqlBulkCopyColumnMapping mapID =
        new SqlBulkCopyColumnMapping("year_month", "year_month");
                            BulkCopy.ColumnMappings.Add(mapID);

                            SqlBulkCopyColumnMapping mapName =
        new SqlBulkCopyColumnMapping("RRN", "TRAN_ID");
                            BulkCopy.ColumnMappings.Add(mapName);

                            SqlBulkCopyColumnMapping mapMumber =
        new SqlBulkCopyColumnMapping("Terminal", "ТЕРМИНАЛ");
                            BulkCopy.ColumnMappings.Add(mapMumber);

                            SqlBulkCopyColumnMapping mapA =
        new SqlBulkCopyColumnMapping("TimeT", "ДАТА_ТРАН");
                            BulkCopy.ColumnMappings.Add(mapA);

                            SqlBulkCopyColumnMapping mapB =
        new SqlBulkCopyColumnMapping("DateT", "ДАТА_РАСЧ");
                            BulkCopy.ColumnMappings.Add(mapB);

                            SqlBulkCopyColumnMapping mapC =
        new SqlBulkCopyColumnMapping("Sum", "СУММА_ТРАН");
                            BulkCopy.ColumnMappings.Add(mapC);

                            SqlBulkCopyColumnMapping mapD =
        new SqlBulkCopyColumnMapping("Cardnum", "КАРТА");
                            BulkCopy.ColumnMappings.Add(mapD);

                            SqlBulkCopyColumnMapping mapE =
        new SqlBulkCopyColumnMapping("AutCode", "КОД_АВТ");
                            BulkCopy.ColumnMappings.Add(mapE);
                        }
                        try
                        {
                            sqlconnDest.Open();
                            BulkCopy.WriteToServer(reader);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            reader.Close();
                            sqlconnDest.Close();
                            sqlconn.Close();
                        }
                    }
                }
            }
            return countStart.ToString();  
        }
        public static void delTemp(int bank)
        {
            string bank_id = "";
            if (bank == 3)
            {
                bank_id = "vtb_bank";
            }
            else if (bank == 4 || bank == 5)
            {
                bank_id = "gpb";
            }
            string queryCount = string.Format("delete from {0}", bank_id);
            using (SqlConnection sqlconn = new SqlConnection(config.variable_config.ConnectionLocal))
            {
                SqlCommand commDeltemp = new SqlCommand(queryCount, sqlconn);
                try
                {
                    sqlconn.Open();
                    commDeltemp.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
        }
    }
}
