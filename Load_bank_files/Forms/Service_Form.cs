using Load_bank_files.Class.config;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Load_bank_files.Forms
{
    public partial class Service_Form : Form
    {
        private static Service_Form _services = null;

        public static Service_Form GetInstance()
        {
            if (_services == null)
                _services = new Service_Form();

            return _services;
        }
		public Service_Form() => InitializeComponent();


		private void Service_Form_Load(object sender, EventArgs e)
        {
            uploadDir();
			this.Text = "Опции";
        }

        private void tab_closed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uploadDir()
        {
            uploadDirTextBox.ReadOnly = true;
            uploadDirTextBox.Text = variable_config.dirUploadFiles;

            connStringTextBox.ReadOnly = true;
            connStringTextBox.Text = variable_config.ConnectionLocal;

			connectionBaseTextBox.ReadOnly = true;
			connectionBaseTextBox.Text = variable_config.ConnStrgingBase;

			yearTextBox.ReadOnly = true;
            yearTextBox.Text = variable_config.year;

            monthTextBox.ReadOnly = true;
            monthTextBox.Text = variable_config.month;

            timeTextBox.ReadOnly = true;
            timeTextBox.Text = variable_config.timerProgressbar.ToString();

			expantionTextBox.ReadOnly = true;
			expantionTextBox.Text = variable_config.GetexpansionFile.ToString();

			pathSAPtextBox.ReadOnly = true;
			pathSAPtextBox.Text = variable_config.directorySAP;
		}

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка сохранения файла конфигурации");
            }
        }

		private void uploadDirTextBox_DoubleClick(object sender, EventArgs e) => uploadDirTextBox.ReadOnly = false;

		private void connStringTextBox_DoubleClick(object sender, EventArgs e) => connStringTextBox.ReadOnly = false;

		private void yearTextBox_DoubleClick(object sender, EventArgs e) => yearTextBox.ReadOnly = false;

		private void monthTextBox_DoubleClick(object sender, EventArgs e) => monthTextBox.ReadOnly = false;

		private void timeTextBox_DoubleClick(object sender, EventArgs e) => timeTextBox.ReadOnly = false;

		private void connectionBaseTextBox_DoubleClick_1(object sender, EventArgs e) => connectionBaseTextBox.ReadOnly = false;

		private void expantionTextBox_DoubleClick(object sender, EventArgs e) => expantionTextBox.ReadOnly = false;

		private void pathSAPtextBox_DoubleClick_1(object sender, EventArgs e) => pathSAPtextBox.ReadOnly = false;

		private void uploadDirTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				AddUpdateAppSettings("dirUploadFiles", uploadDirTextBox.Text);
				uploadDirTextBox.ReadOnly = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				uploadDirTextBox.Undo();
				uploadDirTextBox.ClearUndo();
				uploadDirTextBox.ReadOnly = true;
			}
		}

		private void connStringTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUpdateAppSettings("Load_bank_files.Properties.Settings.localConn", connStringTextBox.Text);
                connStringTextBox.ReadOnly = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                connStringTextBox.Undo();
                connStringTextBox.ClearUndo();
                connStringTextBox.ReadOnly = true;
            }
        }

        private void yearTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUpdateAppSettings("year", yearTextBox.Text);
                yearTextBox.ReadOnly = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                yearTextBox.Undo();
                yearTextBox.ClearUndo();
                yearTextBox.ReadOnly = true;
            }
        }

        private void monthTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUpdateAppSettings("month", monthTextBox.Text);
                monthTextBox.ReadOnly = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                monthTextBox.Undo();
                monthTextBox.ClearUndo();
                monthTextBox.ReadOnly = true;
            }
        }

        private void timeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUpdateAppSettings("timerProgressbar", timeTextBox.Text);
                timeTextBox.ReadOnly = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                timeTextBox.Undo();
                timeTextBox.ClearUndo();
                timeTextBox.ReadOnly = true;
            }
        }

		private void connectionBaseTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddUpdateAppSettings("ConnStrg", connectionBaseTextBox.Text);
                connectionBaseTextBox.ReadOnly = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                connectionBaseTextBox.Undo();
                connectionBaseTextBox.ClearUndo();
                connectionBaseTextBox.ReadOnly = true;
            }
        }

		private void expantionTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				AddUpdateAppSettings("expansionFile", expantionTextBox.Text);
				expantionTextBox.ReadOnly = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				expantionTextBox.Undo();
				expantionTextBox.ClearUndo();
				expantionTextBox.ReadOnly = true;
			}
		}

		private void pathSAPtextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				AddUpdateAppSettings("directorySAP", pathSAPtextBox.Text);
				pathSAPtextBox.ReadOnly = true;
				try
				{
					if (!Directory.Exists(variable_config.directorySAP))
					{
						DirectoryInfo d_sap = Directory.CreateDirectory(variable_config.directorySAP);
					}
				}
				catch (Exception b)
				{
					MessageBox.Show(b.ToString());
				}

			}
			else if (e.KeyCode == Keys.Escape)
			{
				pathSAPtextBox.Undo();
				pathSAPtextBox.ClearUndo();
				pathSAPtextBox.ReadOnly = true;
			}
		}
	}
}
