using System;
using System.Data;
using System.Text;

namespace CA.Common.Data
{
    public class DataHelper
    {
        private static bool ColumnEqual(object a, object b)
        {
            if (a == DBNull.Value && b == DBNull.Value) //  both are DBNull.Value
                return true;
            if (a == DBNull.Value || b == DBNull.Value) //  only one is DBNull.Value
                return false;
            return (a.Equals(b));  // value type standard comparison
        }

        public static DataTable SelectDistinct(DataTable sourceTable, string columnName)
        {
            // Create a new DataTable
            DataTable resultdt = new DataTable();
            // Get the Colunm to use
            DataColumn dc = sourceTable.Columns[columnName];
            if (dc != null)
            {
                // Add a col to the result table
                resultdt.Columns.Add(columnName, dc.DataType);

                // set an object to hold the previous value, and set it value to null fo the first element
                object lastValueAdded = null;
                // get the a sorted list of the results
                DataRow[] sourceDataRows = sourceTable.Select(string.Empty, columnName);
                foreach (DataRow dr in sourceDataRows)
                {
                    // if it is the first element or a diffrent value add to the result table
                    if (lastValueAdded == null || !(ColumnEqual(lastValueAdded, dr[dc])))
                    {
                        // set the value for the LastValueAdded
                        lastValueAdded = dr[dc];
                        resultdt.Rows.Add(new [] { lastValueAdded });
                    }
                }
            }
            else
            {
                throw new DataException(string.Format("Column Name {0} Does not exist in SourceTable", columnName));
            }

            return resultdt;
        }



        private static string GetDataColunmAsString(DataRow dr, int colNumber, DataColumn col, bool useQuotes)
        {
            string result = string.Empty;
            if (!dr.IsNull(colNumber))
            {
                switch (col.DataType.ToString())
                {
                    case "System.DateTime":
                        {
                            DateTime dt = (DateTime)dr[colNumber];
                            result = string.Format("{0} {1}", dt.ToShortDateString(), dt.ToLongTimeString());
                            break;
                        }
                    default:
                        {
                            result = dr[colNumber].ToString();
                            break;
                        }
                }

                if (useQuotes)
                {
                    result = string.Format("\"{0}\"", result.Replace("\"", "\"\"").Trim());
                }
            }
            return result;
        }

        public static string SerialiseDataTableToDelimitedFormat(DataTable dt, string colDelimiter, 
            string rowDelimiter, bool quoteText, bool outputHeader)
        {
            StringBuilder sb = new StringBuilder();
            if (outputHeader)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(dt.Columns[i].ColumnName);
                    if (i != dt.Columns.Count - 1)
                        sb.Append(colDelimiter);
                }
                sb.Append(rowDelimiter);
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    sb.Append(GetDataColunmAsString(dt.Rows[j], k, dt.Columns[k], quoteText));
                    if (k != dt.Columns.Count - 1)
                        sb.Append(colDelimiter);

                }
                sb.Append(rowDelimiter);
            }
            return sb.ToString();
        }
    }
}
