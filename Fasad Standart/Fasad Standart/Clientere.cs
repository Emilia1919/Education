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
    public partial class Clientere : Form
    {
        public Clientere()
        {
            InitializeComponent();
        }

        private void КлиентыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.клиентыBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fasad_standartDataSet);

        }

        private void Clientere_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fasad_standartDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.fasad_standartDataSet.Клиенты);

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
            клиентыBindingSource.Filter = "[Id клиента] = \'" + textBox1.Text + "\'";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = "ФИО LIKE '%" + textBox2.Text + "%'";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = "Телефон = \'" + textBox3.Text + "\'";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SelClients selClients = new SelClients();
            selClients.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.клиентыTableAdapter.Update(this.fasad_standartDataSet.Клиенты);
            MessageBox.Show("Изменения внесены в таблицу", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            клиентыBindingSource.Filter = null;
        }
    }
}
