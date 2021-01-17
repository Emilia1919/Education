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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void ТоварыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.товарыBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fasad_standartDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.fasad_standartDataSet.Товары);

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

        private void Button9_Click(object sender, EventArgs e)
        {
            this.товарыTableAdapter.Update(this.fasad_standartDataSet);
            MessageBox.Show("Изменения внесены в таблицу", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            SelProducts selProducts = new SelProducts();
            selProducts.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = "[Id товара] = \'" + textBox1.Text + "\'";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = "[Наименование] LIKE '%" + textBox2.Text + "%'";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = "[Стоимость] >=" + textBox3.Text + "AND [Стоимость] <=" + textBox4.Text;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = "[Тип покрытия] LIKE '%" + textBox6.Text + "%'";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = "[Текстура покрытия] LIKE '%" + textBox5.Text + "%'";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = "[Цвет] LIKE '%" + textBox7.Text + "%'";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            товарыBindingSource.Filter = null;
        }
    }
}
