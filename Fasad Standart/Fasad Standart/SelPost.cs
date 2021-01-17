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
    public partial class SelPost : Form
    {
        public static string connectionstring = Properties.Settings.Default.fasad_standartConnectionString;

        public SelPost()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Clientere clientere = new Clientere();
            clientere.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
