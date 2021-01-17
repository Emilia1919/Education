using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fasad_Standart
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void СотрудникиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.сотрудникиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

        }

        private void Staff_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fasad_standartDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.fasad_standartDataSet.Сотрудники);

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Choice choice = new Choice();
            choice.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            сотрудникиBindingSource.Filter = "[Id сотрудника] = \'" + textBox1.Text + "\'";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            сотрудникиBindingSource.Filter = "ФИО LIKE '%" + textBox2.Text + "%'";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            сотрудникиBindingSource.Filter = "Телефон = \'" + textBox3.Text + "\'";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Update(this.fasad_standartDataSet.Сотрудники);
            MessageBox.Show("Изменения внесены в таблицу", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            сотрудникиBindingSource.Filter = null;
        }
    }
}
