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
    public partial class Review : Form
    {
        public Review()
        {
            InitializeComponent();
        }

        private void ОтзывыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.отзывыBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

        }

        private void Review_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fasad_standartDataSet.Отзывы". При необходимости она может быть перемещена или удалена.
            this.отзывыTableAdapter.Fill(this.fasad_standartDataSet.Отзывы);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            отзывыBindingSource.Filter = "[Id отзыва] = \'" + textBox1.Text + "\'";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            отзывыBindingSource.Filter = "[Id клиента] = \'" + textBox2.Text + "\'";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.отзывыTableAdapter.Update(this.fasad_standartDataSet.Отзывы);
            MessageBox.Show("Изменения внесены в таблицу", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            отзывыBindingSource.Filter = null;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

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
    }
}
