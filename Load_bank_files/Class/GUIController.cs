using Load_bank_files.Class.config;
using System.Windows.Forms;

namespace Load_bank_files.Class.GUI
{
    public static class GUIController
    {
        private static Form _instance;
        public static void setForm(Form f)
        {
            _instance = f;
        }
        public static void startButtonEnabled(bool enabled)
        {
            Button B = (Button)_instance.Controls["RunButton"];
            B.BeginInvoke(new MethodInvoker(() => B.Enabled = enabled));
            B.BeginInvoke(new MethodInvoker(() => B.Update()));
        }
        public static void countFilesTextBox(string TextList)
        {
            TextBox B = (TextBox)_instance.Controls["selectFilesTextBox"];
            B.BeginInvoke(new MethodInvoker(() => B.Visible = true));
            if (B.InvokeRequired)
                B.BeginInvoke(new MethodInvoker(() => B.Update()));
            else 
            B.BeginInvoke(new MethodInvoker(() => B.Text = TextList));
			if (TextList == "Clear")
			{
				B.BeginInvoke(new MethodInvoker(() => B.Clear()));
				B.BeginInvoke(new MethodInvoker(() => B.Text = string.Empty));
			}

		}
        public static void countFileslistbox()
        {
            ListBox B = (ListBox)_instance.Controls["countlistBox"];
            B.BeginInvoke(new MethodInvoker(() => B.Visible = true));
            if (B.InvokeRequired)
                B.BeginInvoke(new MethodInvoker(() => B.Update()));
            else
                B.BeginInvoke(new MethodInvoker(() => B.Items.Clear()));
        }
        public static void progressBar()
        {
            ProgressBar P = (ProgressBar)_instance.Controls["threadProgressBar"];
            P.BeginInvoke(new MethodInvoker(() => P.Maximum = 10));
        }
		public static void openDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = variable_config.dirUploadFiles;
			openFileDialog.Filter = variable_config.GetexpansionFile;
			openFileDialog.FilterIndex = 2;
			openFileDialog.Multiselect = true;
			openFileDialog.RestoreDirectory = true;
		}

		//public static void circularProgress(bool enabled)
		//{
		//	CircularIndeterminateProgress.CircularIndeterminateProgress c = (CircularIndeterminateProgress.CircularIndeterminateProgress)_instance.Controls["circularProgressMain"];

		//	//c.BeginInvoke(new MethodInvoker(() => c.IndicatorType = CircularIndeterminateProgress.CircularIndeterminateProgress.INDICATORTYPES.PULSED));
		//}

		
	}
}
