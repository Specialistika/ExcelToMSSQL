using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Load_bank_files.Forms
{
	public partial class AddDelShopForm : Form
	{
		private static AddDelShopForm AddDelShop = null;
		public AddDelShopForm()
		{
			InitializeComponent();
		}
		public static AddDelShopForm GetInstance()
		{
			if (AddDelShop == null)
				AddDelShop = new AddDelShopForm();
			return AddDelShop;
		}
	



	}
}
