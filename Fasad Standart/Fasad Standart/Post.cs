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
    public partial class Post : Form
    {
        public Post()
        {
            InitializeComponent();
        }

        private void Post_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fasad_standartDataSet.Должности". При необходимости она может быть перемещена или удалена.
            this.должностиTableAdapter.Fill(this.fasad_standartDataSet.Должности);

        }

        private void ДолжностиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.должностиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

        }

        private void ДолжностиBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.должностиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

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
            должностиBindingSource.Filter = "[Id должности] = \'" + textBox1.Text + "\'";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            должностиBindingSource.Filter = "Название LIKE '%" + textBox2.Text + "%'";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            должностиBindingSource.Filter = "[Оклад] >=" + textBox3.Text + "AND [Оклад] <=" + textBox4.Text;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.должностиTableAdapter.Update(this.fasad_standartDataSet.Должности);
            MessageBox.Show("Изменения внесены в таблицу", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            должностиBindingSource.Filter = null;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SelPost selpost = new SelPost();
            selpost.Show();
            this.Hide();
        }
    }
}
