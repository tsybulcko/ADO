using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;

namespace Aacademy
{
	public partial class HumanForm : Form
	{
		internal Models.Human human;
		protected HumanForm()
		{
			InitializeComponent();
			
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{

		}

		protected virtual void ButtonOK_Click(object sender, EventArgs e)
		{
			human = new Models.Human
				(
				tbLastName.Text,
				tbFirstName.Text,
				tbMiddleName.Text,
				dtpBirthDate.Value.ToString("yyyy-MM-dd"),
				tbEmail.Text,
				tbPhone.Text,
				pbPhoto.Image
				);
		}

		private void HumanForm_Load(object sender, EventArgs e)
		{

		}
	}
}
