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
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            this.Hide();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Type type = new Type();
            type.Show();
            this.Hide();
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Hide();
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Post post = new Post();
            post.Show();
            this.Hide();
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Clientere clientere = new Clientere();
            clientere.Show();
            this.Hide();
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Review review = new Review();
            review.Show();
            this.Hide();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
