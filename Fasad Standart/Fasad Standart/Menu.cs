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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.Hide();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "111")
            {
                Choice choice = new Choice();
                choice.Show();
                this.Hide();
            }
            else MessageBox.Show("Неверный пароль", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
        }
    }
}
