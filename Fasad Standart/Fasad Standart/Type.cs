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
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }

        private void Вид_товараBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.вид_товараBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);
        }

        private void Type_Load(object sender, EventArgs e)
        {
            this.вид_товараTableAdapter.Fill(this.fasad_standartDataSet.Вид_товара);
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

        private void Вид_товараBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.вид_товараBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            Choice choice = new Choice();
            choice.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            вид_товараBindingSource.Filter = "[Id вида продукции] = \'" + textBox1.Text + "\'";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            вид_товараBindingSource.Filter = "Наименование LIKE '%" + textBox2.Text + "%'";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            вид_товараBindingSource.Filter = null;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.вид_товараTableAdapter.Update(this.fasad_standartDataSet.Вид_товара);
            MessageBox.Show("Изменения внесены в таблицу", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
