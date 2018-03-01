using Load_bank_files.Class.config;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Load_bank_files.Class.loadMineTable;
using Load_bank_files.Class.deleteDBbase;

namespace Load_bank_files.Class
{
	public static class UploadSap
	{
		private static string year = variable_config.year;
		private static string month = variable_config.month;
		private static OpenFileDialog openFileDialog = new OpenFileDialog();

		static UploadSap()
		{ 
			openFileDialog.InitialDirectory = variable_config.dirUploadFiles;
			openFileDialog.Filter = variable_config.GetexpansionFile;
			openFileDialog.FilterIndex = 2;
			openFileDialog.Multiselect = true;
			openFileDialog.RestoreDirectory = true;
		}

		public static async Task UploadSapAsync()
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (var file in openFileDialog.FileNames)
				{
					try
					{
						await CopyFail(file);
						
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ошибка: " + ex.Message);
					}
				}
			}
			MessageBox.Show("Пополнение данных закончено");
		}

		private async static Task CopyFail(string file)
		{
			string nameFile, fullPath;

			fullPath = Path.GetDirectoryName(file);

			nameFile = Path.GetFileName(file);

			await Task.Run(() => File.Copy(Path.Combine(fullPath, nameFile), Path.Combine(variable_config.directorySAP, nameFile), false));

			await Task.Run(() => GetFileName(nameFile));

			await DeleteDBbase.DeleteFile(variable_config.directorySAP);
		}

		private async static Task GetFileName(string nameFile)
		{

			if (nameFile.Substring(0, 2) == "СБ" && nameFile.Substring(3, 3) == "МСК")
			{
				await AddToMineTable.UpdateSapTable(2, variable_config.directorySAP);
			}
			else if(nameFile.Substring(0, 2) == "СБ" && nameFile.Substring(3, 3) == "КЛД")
			{
				await AddToMineTable.UpdateSapTable(1, variable_config.directorySAP);
			}
			else if (nameFile.Substring(0, 3) == "ГПБ" && nameFile.Substring(4, 3) == "МСК")
			{
				await AddToMineTable.UpdateSapTable(4, variable_config.directorySAP);
			}
			else if (nameFile.Substring(0, 3) == "ГПБ" && nameFile.Substring(4, 3) == "КЛД")
			{
				await AddToMineTable.UpdateSapTable(5, variable_config.directorySAP);
			}
		}


	}
}
