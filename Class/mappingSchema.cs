using Load_bank_files.Forms;
using System.Data.SqlClient;

namespace Load_bank_files.Class
{
	public static partial class MappingSchema
	{
		public static void mapTemplong(SqlBulkCopy BulkCopy)
		{
			if (MineGenegalForms.TypeFile_ == 6)
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
			else if (MineGenegalForms.TypeFile_ == 4 || MineGenegalForms.TypeFile_ == 5)
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
			else if (MineGenegalForms.TypeFile_ == 1 || MineGenegalForms.TypeFile_ == 2 || MineGenegalForms.TypeFile_ == 3)
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
		}
		public static void mapTemplocal(SqlBulkCopy copyBulk)
		{
			if (MineGenegalForms.TypeFile_ != 4 && MineGenegalForms.TypeFile_ != 5)
			{
				SqlBulkCopyColumnMapping mapID =
new SqlBulkCopyColumnMapping("TimeS", "TimeT");
				copyBulk.ColumnMappings.Add(mapID);

				SqlBulkCopyColumnMapping mapName =
new SqlBulkCopyColumnMapping("Datet", "DateT");
				copyBulk.ColumnMappings.Add(mapName);

				SqlBulkCopyColumnMapping mapMumber =
new SqlBulkCopyColumnMapping("Terminal", "Terminal");
				copyBulk.ColumnMappings.Add(mapMumber);

				SqlBulkCopyColumnMapping mapA =
new SqlBulkCopyColumnMapping("Cardnum", "Cardnum");
				copyBulk.ColumnMappings.Add(mapA);

				SqlBulkCopyColumnMapping mapB =
new SqlBulkCopyColumnMapping("AutCode", "AutCode");
				copyBulk.ColumnMappings.Add(mapB);

				SqlBulkCopyColumnMapping mapC =
new SqlBulkCopyColumnMapping("Sum", "Sum");
				copyBulk.ColumnMappings.Add(mapC);

				SqlBulkCopyColumnMapping mapD =
new SqlBulkCopyColumnMapping("Comis", "Comis");
				copyBulk.ColumnMappings.Add(mapD);

				SqlBulkCopyColumnMapping mapE =
new SqlBulkCopyColumnMapping("RRN", "RRN");
				copyBulk.ColumnMappings.Add(mapE);
			}
			if (MineGenegalForms.TypeFile_ == 4 || MineGenegalForms.TypeFile_ == 5)
			{
				SqlBulkCopyColumnMapping mapID =
new SqlBulkCopyColumnMapping("TimeS", "TimeT");
				copyBulk.ColumnMappings.Add(mapID);

				SqlBulkCopyColumnMapping mapName =
new SqlBulkCopyColumnMapping("Datet", "DateT");
				copyBulk.ColumnMappings.Add(mapName);

				SqlBulkCopyColumnMapping mapMumber =
new SqlBulkCopyColumnMapping("Terminal", "Terminal");
				copyBulk.ColumnMappings.Add(mapMumber);

				SqlBulkCopyColumnMapping mapA =
new SqlBulkCopyColumnMapping("Cardnum", "Cardnum");
				copyBulk.ColumnMappings.Add(mapA);

				SqlBulkCopyColumnMapping mapB =
new SqlBulkCopyColumnMapping("AutCode", "AutCode");
				copyBulk.ColumnMappings.Add(mapB);

				SqlBulkCopyColumnMapping mapC =
new SqlBulkCopyColumnMapping("Sum", "Sum");
				copyBulk.ColumnMappings.Add(mapC);

				SqlBulkCopyColumnMapping mapD =
new SqlBulkCopyColumnMapping("Comis", "Comis");
				copyBulk.ColumnMappings.Add(mapD);

				SqlBulkCopyColumnMapping mapE =
new SqlBulkCopyColumnMapping("RRN", "RRN");
				copyBulk.ColumnMappings.Add(mapE);

				SqlBulkCopyColumnMapping mapF =
new SqlBulkCopyColumnMapping("Typ", "Typ");
				copyBulk.ColumnMappings.Add(mapF);

				SqlBulkCopyColumnMapping mapG =
new SqlBulkCopyColumnMapping("PS", "PS");
				copyBulk.ColumnMappings.Add(mapG);

				SqlBulkCopyColumnMapping mapH =
new SqlBulkCopyColumnMapping("Emitent", "Emitent");
				copyBulk.ColumnMappings.Add(mapH);
			}
		}
	}
}
