using Load_bank_files.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Load_bank_files.Class.GUI
{
    public static class GUIController
    {
        private static oneDayFiles _instance;
        public static void setForm(oneDayFiles f)
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

    }
}
