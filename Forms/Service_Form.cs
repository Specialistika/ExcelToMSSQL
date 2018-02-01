using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Load_bank_files.Forms
{
    public partial class Service_Form : Form
    {
        private static Service_Form _services = null;
        public string fildirectory;
        public string fildirectoryout;
        public string connectionstring;
        public string configfiledir = "Serviceinfo.ini";
        Array lines = Array.CreateInstance(typeof(string), 4);
        public static Service_Form GetInstance()
        {
            if (_services == null)
                _services = new Service_Form();

            return _services;
        }
        public Service_Form()
        {
            InitializeComponent();
        }


        private void Service_Form_Load(object sender, EventArgs e)
        {
            int i = 0;

            using (StreamReader sr = new StreamReader(configfiledir))
            {
                try
                {
                    while (true)
                    {
                        string line_text = sr.ReadLine();
                        if (line_text == "") break;
                        lines.SetValue(line_text, i);
                        i++;
                    }
                    sr.Close();
                }
                catch (Exception b)
                {
                    Console.WriteLine("Exception: " + b.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
                if (lines != null)
                {
                    path_bank.Text = Convert.ToString(lines.GetValue(0));
                    path_sap.Text = Convert.ToString(lines.GetValue(1));
                    path_con.Text = Convert.ToString(lines.GetValue(2));
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            int i = 0;
            int f = 0;
            Array.Clear(lines, 0, lines.Length);
            lines.SetValue(path_bank.Text, 0);
            lines.SetValue(path_sap.Text, 1);
            lines.SetValue(path_con.Text, 2);

            using (var stream = new FileStream(configfiledir, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write("");
                }
            }
            try
            {
                while (i<2)
                {
                    if (Directory.Exists(Convert.ToString(lines.GetValue(i)))) i++;
                    switch (i)
                    {
                        case 0:
                            for (f = 0; f <= (Bank_checkedListBox.Items.Count - 1); f++)
                            {
                                if (Bank_checkedListBox.GetItemChecked(f))
                                {
                                    DirectoryInfo d_bank = Directory.CreateDirectory(Convert.ToString(lines.GetValue(i)) + Convert.ToString(f+1));
                                }
                            }
                                break;
                        case 1:
                            DirectoryInfo d_sap = Directory.CreateDirectory(Convert.ToString(lines.GetValue(i)));
                            break;
                    }
                }
            }
            catch (Exception b)
            {
                Console.WriteLine("The process failed: {0}", b.ToString());
            } 

            using (StreamWriter sw = new StreamWriter(configfiledir, true, Encoding.ASCII))
            {
                i = 0;
                try
                {
                    while (true)
                    {
                        if (lines.GetValue(i) == null) break;
                        sw.WriteLine(Convert.ToString(lines.GetValue(i)));
                        i++;
                    }
                    sw.Close();
                }

                catch (Exception b)
                {
                    Console.WriteLine("Ошибка:" + b.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            this.Close();
        }

        private void tab_closed_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
