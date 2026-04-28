using Aacademy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aacademy
{
	public partial class StudentForm : HumanForm
	{
		internal Models.Student student;
		public StudentForm()
		{
			InitializeComponent();

			tbLastName.Text = "Жук";
			tbFirstName.Text = "Василий";
			tbMiddleName.Text = "Петрович";
			dtpBirthDate.Text = "24.10.1977";
			tbEmail.Text = "bazilik_spb@mail.ru";
			tbPhone.Text = "7(911)024-56-78";

			DataTable groups = DataBase.Connector.Select("SELECT * FROM Groups"); //Получаем DataTable.
			cbGroup.DataSource = groups;
			cbGroup.DisplayMember = "group_name";
			cbGroup.ValueMember = "group_id";
		}
		public StudentForm(int id) : this() 
		{
			DataTable data = DataBase.Connector.Select("*", "Students", $"stud_id={id}");
			student = new Models.Student(data.Rows[0].ItemArray);
			human = student;
			Extract();
			cbGroup.SelectedValue = student.group;
		}
		/*protected override void buttonOK_Click(object sender, EventArgs e)
		{
			DataBase.Connector.Insert
				(
				"Students",
				"last_name,first_name,middle_name,birth_date,email,phone,[group]",
				$"{}"
		*/
		protected override void ButtonOK_Click(object sender, EventArgs e)
		{
			base.ButtonOK_Click(sender, e);

			student = new Models.Student(human,Convert.ToInt32(cbGroup.SelectedValue));
			DataBase.Connector.Insert("Students", $"{student.GetNames()}", $"{student.GetValues()}");
			//try
			//{
			//	DataBase.Connector.Insert
			//		(
			//		"Students",
			//		"last_name,first_name,middle_name,birth_date,email,phone,[group]",
			//		$"{tbLastName.Text},{tbFirstName.Text},{tbMiddleName.Text},{dtpBirthDate.Value.ToString("dd-MM-yyyy")},{tbEmail.Text},{tbPhone.Text},{cbGroup.SelectedValue}"
			//		);
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK);
			//}
		}
	}
}
